using System;
using EVDMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.Infrastructure.Configurations;

public class PermissionConfiguration : AuditableConfiguration<Permission>
{
    public override void Configure(EntityTypeBuilder<Permission> builder)
    {
        base.Configure(builder);
        
        // Table name
        builder.ToTable("Permissions");
        
        // String properties
        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(e => e.Description)
            .HasMaxLength(500);
        
        builder.Property(e => e.Resource)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(e => e.Action)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(e => e.Code)
            .HasMaxLength(100)
            .IsRequired();
        
        // Unique constraint on permission code
        builder.HasIndex(e => e.Code)
            .IsUnique()
            .HasDatabaseName("IX_Permissions_Code");
        
        // Composite index for resource and action
        builder.HasIndex(e => new { e.Resource, e.Action })
            .HasDatabaseName("IX_Permissions_Resource_Action");
        
        // Indexes for performance
        builder.HasIndex(e => e.IsActive);
        builder.HasIndex(e => e.Resource);
    }
}
