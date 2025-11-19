using System;
using EVDMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.Infrastructure.Configurations;

public class RoleConfiguration : AuditableConfiguration<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        base.Configure(builder);
        
        // Table name
        builder.ToTable("Roles");
        
        // String properties
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(e => e.Description)
            .HasMaxLength(500);
        
        // Unique constraint on role name
        builder.HasIndex(e => e.Name)
            .IsUnique()
            .HasDatabaseName("IX_Roles_Name");
        
        // Indexes for performance
        builder.HasIndex(e => e.IsActive);
        builder.HasIndex(e => e.IsSystemRole);

        // // Seed data
        // builder.HasData(
        //     new Role
        //     {
        //         Id = Guid.Parse("a1b2c3d4-e5f6-4789-9012-3456789abcde"),
        //         Name = "Administrator",
        //         Description = "System Administrator with full access",
        //         IsActive = true,
        //         IsSystemRole = true,
        //         CreatedAt = DateTime.UtcNow,
        //         CreatedBy = "System"
        //     },

        //     // For Dealer Management System

        //     new Role
        //     {
        //         Id = Guid.Parse("b2c3d4e5-f678-4890-1234-56789abcdef0"),
        //         Name = "Dealer Staff",
        //         Description = "Dealer role with limited access",
        //         IsActive = true,
        //         IsSystemRole = false,
        //         CreatedAt = DateTime.UtcNow,
        //         CreatedBy = "System"
        //     },


        //     new Role
        //     {
        //         Id = Guid.Parse("c3d4e5f6-7890-4901-2345-6789abcdef01"),
        //         Name = "Dealer Manager",
        //         Description = "Customer role with access to personal data",
        //         IsActive = true,
        //         IsSystemRole = false,
        //         CreatedAt = DateTime.UtcNow,
        //         CreatedBy = "System"
        //     },

        //     // For Manufacturer Management System

        //     new Role
        //     {
        //         Id = Guid.Parse("d4e5f678-8901-4901-3456-789abcdef012"),
        //         Name = "EVM Staff",
        //         Description = "EVM role with limited access",
        //         IsActive = true,
        //         IsSystemRole = false,
        //         CreatedAt = DateTime.UtcNow,
        //         CreatedBy = "System"
        //     },


        //     new Role
        //     {
        //         Id = Guid.Parse("e5f67890-9012-4901-4567-89abcdef0123"),
        //         Name = "EVM Admin",
        //         Description = "EVM Admin role with elevated access",
        //         IsActive = true,
        //         IsSystemRole = false,
        //         CreatedAt = DateTime.UtcNow,
        //         CreatedBy = "System"
        //     }

        // );
    }
}
