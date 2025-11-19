using System;
using EVDMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.Infrastructure.Configurations;

public class OrderConfiguration : AuditableConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);
        
        // Table name
        builder.ToTable("Orders");
        
        // String properties
        builder.Property(e => e.OrderNumber)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(e => e.Status)
            .HasMaxLength(20)
            .HasDefaultValue("Pending")
            .IsRequired();
        
        // Decimal properties
        builder.Property(e => e.TotalAmount)
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.Property(e => e.PaidAmount)
            .HasPrecision(18, 2);
        
        // Unique constraints
        builder.HasIndex(e => e.OrderNumber)
            .IsUnique()
            .HasDatabaseName("IX_Orders_OrderNumber");
        
        // Relationships
        builder.HasOne(e => e.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Dealer)
            .WithMany(d => d.Orders)
            .HasForeignKey(e => e.DealerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Quote)
            .WithOne(q => q.Order)
            .HasForeignKey<Quote>(e => e.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes for performance
        builder.HasIndex(e => e.CustomerId);
        builder.HasIndex(e => e.DealerId);
        builder.HasIndex(e => e.QuoteId);
        builder.HasIndex(e => e.Status);
    }
}
