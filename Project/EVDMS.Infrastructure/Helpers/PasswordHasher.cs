using System;
using Konscious.Security.Cryptography;
using System.Text;
using EVDMS.Application.Interfaces;
using System.Security.Cryptography;

namespace EVDMS.Infrastructure.Helpers;

public class PasswordHasher : IPasswordHasher
{

    private const int SaltSize = 16; // 128 bit
    private const int HashSize = 32; // 256 bit
    private const int Iterations = 4;
    private const int MemorySize = 1024 * 64; // 64 MB
    private const int DegreeOfParallelism = 8; // Number of threads to use
    public string HashPassword(string password)
    {
        byte[] salt = new byte[SaltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        byte[] hash = HashPasswordByArgon2(password, salt);
        return Convert.ToBase64String(hash);
    }

    public bool VerifyPassword(string providedPassword, string hashedPassword)
    {
        // Decode the stored hash
        byte[] combinedBytes = Convert.FromBase64String(hashedPassword);

        // Extract salt and hash
        byte[] salt = new byte[SaltSize];
        byte[] hash = new byte[HashSize];
        Array.Copy(combinedBytes, 0, salt, 0, SaltSize);
        Array.Copy(combinedBytes, SaltSize, hash, 0, HashSize);

        // Compute hash for the input password
        byte[] newHash = HashPasswordByArgon2(providedPassword, salt);

        // Compare the hashes
        return CryptographicOperations.FixedTimeEquals(hash, newHash);
    }

    private byte[] HashPasswordByArgon2(string password, byte[] salt)
    {
        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = DegreeOfParallelism,
            Iterations = Iterations,
            MemorySize = MemorySize
        };

        return argon2.GetBytes(HashSize);
    }
}
