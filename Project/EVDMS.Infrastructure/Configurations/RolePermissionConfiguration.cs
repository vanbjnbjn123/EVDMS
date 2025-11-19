using System;
using EVDMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.Infrastructure.Configurations;

public class RolePermissionConfiguration : AuditableConfiguration<RolePermission>
{
    public override void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        base.Configure(builder);
        
        // Table name
        builder.ToTable("RolePermissions");

        // Has primary key
        builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });
        
        // Relationships
        builder.HasOne(rp => rp.Role)
            .WithMany(r => r.RolePermissions)
            .HasForeignKey(rp => rp.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(rp => rp.Permission)
            .WithMany(p => p.RolePermissions)
            .HasForeignKey(rp => rp.PermissionId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Indexes
        builder.HasIndex(e => e.RoleId);
        builder.HasIndex(e => e.PermissionId);
        builder.HasIndex(e => e.IsGranted);
    }
}
