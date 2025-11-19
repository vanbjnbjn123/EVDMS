using System;
using EVDMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.Infrastructure.Configurations;

public class PromotionConfiguration : AuditableConfiguration<Promotion>
{
    public override void Configure(EntityTypeBuilder<Promotion> builder)
    {
        base.Configure(builder);
        
        // Table name
        builder.ToTable("Promotions");
        
        // String properties
        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(e => e.Description)
            .HasMaxLength(1000);
        
        builder.Property(e => e.Code)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(e => e.Type)
            .HasMaxLength(20)
            .IsRequired();
        
        // Decimal properties
        builder.Property(e => e.DiscountPercentage)
            .HasPrecision(5, 2);
        
        builder.Property(e => e.DiscountAmount)
            .HasPrecision(18, 2);
        
        // Unique constraint on promotion code
        builder.HasIndex(e => e.Code)
            .IsUnique()
            .HasDatabaseName("IX_Promotions_Code");
        
        // Indexes for performance
        builder.HasIndex(e => e.IsActive);
        builder.HasIndex(e => new { e.StartDate, e.EndDate });
        builder.HasIndex(e => e.Type);
    }
}