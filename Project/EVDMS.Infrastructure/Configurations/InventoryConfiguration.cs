using System;
using EVDMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.Infrastructure.Configurations;

public class InventoryConfiguration : AuditableConfiguration<Inventory>
{
    public override void Configure(EntityTypeBuilder<Inventory> builder)
    {
        base.Configure(builder);
        
        // Table name
        builder.ToTable("Inventory");
        
        // // String properties
        // builder.Property(e => e.Status)
        //     .HasMaxLength(20)
        //     .HasDefaultValue("Available")
        //     .IsRequired();
        
        // Composite unique constraint for dealer + product
        builder.HasIndex(e => new { e.DealerId, e.ProductId })
            .HasDatabaseName("IX_Inventory_Dealer_Product");

        // Relationships
        builder.HasOne(e => e.Dealer)
            .WithMany(d => d.Inventories)
            .HasForeignKey(e => e.DealerId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasOne(e => e.Manufacturer)
            .WithMany(m => m.Inventories)
            .HasForeignKey(e => e.ManufacturerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Product)
            .WithMany(p => p.Inventories)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes for performance
        builder.HasIndex(e => e.DealerId);
        builder.HasIndex(e => e.ProductId);
        // builder.HasIndex(e => e.Status);
        builder.HasIndex(e => e.QuantityInStock);
    }
}
