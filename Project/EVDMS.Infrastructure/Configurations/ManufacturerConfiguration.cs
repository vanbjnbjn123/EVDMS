using System;
using EVDMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.Infrastructure.Configurations;

public class ManufacturerConfiguration : AuditableConfiguration<Manufacturer>
{
    public override void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        base.Configure(builder);
        
        // Table name
        builder.ToTable("Manufacturers");
        
        // String properties
        builder.Property(e => e.ManufacturerName)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(e => e.ManufacturerCode)
            .HasMaxLength(20)
            .IsRequired();
        
        builder.Property(e => e.BrandName)
            .HasMaxLength(100)
            .IsRequired();
        
        // Relationships
        builder.HasMany(e => e.UserOrganizations)
            .WithOne(uo => uo.Manufacturer)
            .HasForeignKey(uo => uo.ManufacturerId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Unique constraints
        builder.HasIndex(e => e.ManufacturerCode)
            .IsUnique()
            .HasDatabaseName("IX_Manufacturers_ManufacturerCode");
        
        // Indexes for performance
        builder.HasIndex(e => e.ManufacturerName);
        builder.HasIndex(e => e.BrandName);
    }
}