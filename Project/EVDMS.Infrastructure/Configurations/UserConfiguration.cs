using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EVDMS.Core.Entities;

namespace EVDMS.Infrastructure.Configurations;

public class UserConfiguration : AuditableConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        
        // Table name
        builder.ToTable("Users");
        
        // String properties with max length
        builder.Property(e => e.Email)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(e => e.Username)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(e => e.PasswordHash)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired(false);

        builder.Property(e => e.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Gender)
            .IsRequired().HasDefaultValue(2); // Default to 'Other' if applicable

        builder.Property(e => e.Address)
            .HasMaxLength(255)
            .IsRequired(false);

        // Unique constraints
        builder.HasIndex(e => e.Email)
            .IsUnique()
            .HasDatabaseName("IX_Users_Email");
        
        builder.HasIndex(e => e.Username)
            .IsUnique()
            .HasDatabaseName("IX_Users_Username");
        
        // Additional indexes for performance
        builder.HasIndex(e => e.IsActive);
        builder.HasIndex(e => e.Username);
        builder.HasIndex(e => e.LastLoginAt);
    }
}