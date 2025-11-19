using System;
using EVDMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.Infrastructure.Configurations;

public class UserRoleConfiguration : AuditableConfiguration<UserRole>
{
    public override void Configure(EntityTypeBuilder<UserRole> builder)
    {
        base.Configure(builder);

        // Table name
        builder.ToTable("UserRoles");
        
        // Has primary key
        builder.HasKey(ur => new { ur.UserId, ur.RoleId });
        
        // Relationships
        builder.HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Indexes
        builder.HasIndex(e => e.UserId);
        builder.HasIndex(e => e.RoleId);
        builder.HasIndex(e => e.IsActive);
        builder.HasIndex(e => e.AssignedAt);
    }
}
