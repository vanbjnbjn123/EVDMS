using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EVDMS.Core.Entities;

namespace EVDMS.Infrastructure.Configurations;

public class ProductConfiguration : AuditableConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);
        
        // Table name
        builder.ToTable("Products");
        
        // String properties with max length
        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(e => e.Brand)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(e => e.Model)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(e => e.VehicleType)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(e => e.ChargingType)
            .HasMaxLength(50);
        
        builder.Property(e => e.DriveType)
            .HasMaxLength(10);
        
        builder.Property(e => e.Color)
            .HasMaxLength(50);
        
        builder.Property(e => e.InteriorMaterial)
            .HasMaxLength(100);
        
        builder.Property(e => e.ImageUrl)
            .HasColumnType("text[]");
        
        // Decimal properties with precision
        builder.Property(e => e.Price)
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.Property(e => e.BatteryCapacity)
            .HasPrecision(8, 2);
        
        builder.Property(e => e.Weight)
            .HasPrecision(8, 2);
        
        builder.Property(e => e.Length)
            .HasPrecision(5, 2);
        
        builder.Property(e => e.Width)
            .HasPrecision(5, 2);
        
        builder.Property(e => e.Height)
            .HasPrecision(5, 2);
        
        // Text properties
        builder.Property(e => e.Description)
            .HasMaxLength(2000);
        
        // Indexes for performance and searching
        builder.HasIndex(e => e.Brand);
        builder.HasIndex(e => e.Model);
        builder.HasIndex(e => new { e.Brand, e.Model });
        builder.HasIndex(e => e.VehicleType);
        builder.HasIndex(e => e.Year);
        builder.HasIndex(e => e.Price);
        builder.HasIndex(e => e.IsAvailable);
        builder.HasIndex(e => e.Range);
        builder.HasIndex(e => e.BatteryCapacity);
        
        // Full-text search index for name and description (SQL Server specific)
        // builder.HasIndex(e => new { e.Name, e.Description }).HasMethod("FULLTEXT");
    }
}