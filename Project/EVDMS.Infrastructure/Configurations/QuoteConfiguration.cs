using System;
using EVDMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.Infrastructure.Configurations;

public class QuoteConfiguration : AuditableConfiguration<Quote>
{
    public override void Configure(EntityTypeBuilder<Quote> builder)
    {
        base.Configure(builder);
        
        // Table name
        builder.ToTable("Quotes");
        
        
        // String properties
        builder.Property(e => e.QuoteNumber)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(e => e.Status)
            .HasMaxLength(20)
            .HasDefaultValue("Draft")
            .IsRequired();
        
        // Decimal properties with precision
        builder.Property(e => e.BaseTotalPrice)
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.Property(e => e.TotalDiscountAmount)
            .HasPrecision(18, 2);
        
        builder.Property(e => e.TotalPrice)
            .HasPrecision(18, 2)
            .IsRequired();
        
        // Unique constraint on quote number
        builder.HasIndex(e => e.QuoteNumber)
            .IsUnique()
            .HasDatabaseName("IX_Quotes_QuoteNumber");
        
        // Relationships
        builder.HasOne(q => q.Customer)
            .WithMany(c => c.Quotes)
            .HasForeignKey(q => q.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(q => q.Product)
            .WithMany(p => p.Quotes)
            .HasForeignKey(q => q.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(q => q.Dealer)
            .WithMany(d => d.Quotes)
            .HasForeignKey(q => q.DealerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Indexes for performance
        builder.HasIndex(e => e.CustomerId);
        builder.HasIndex(e => e.ProductId);
        builder.HasIndex(e => e.DealerId);
        builder.HasIndex(e => e.Status);
    }
}
