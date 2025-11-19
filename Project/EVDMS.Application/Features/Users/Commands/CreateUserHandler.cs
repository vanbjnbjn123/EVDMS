using System;
using EVDMS.Application.Interfaces;
using EVDMS.Application.Features.Users.Commands;

namespace EVDMS.Application.Features.Users.Commands;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    public CreateUserHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Check for existing user, validate data, hash password, etc.
        bool userExists = await _unitOfWork.Repository<User>().ExistsAsync(u => u.Username == request.Username);
        if (userExists)
        {
            throw new InvalidOperationException("User with the same username or email already exists.");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            Email = request.Email,
            PasswordHash = _passwordHasher.HashPassword(request.Password),
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            DateOfBirth = request.DateOfBirth?.ToUniversalTime(),
            Gender = request.Gender,
            Address = request.Address
        };

        await _unitOfWork.Repository<User>().AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return user.Id;
    }
}
