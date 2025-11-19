using System;
using EVDMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.Infrastructure.Configurations;

public class ContractConfiguration : AuditableConfiguration<Contract>
{
    public override void Configure(EntityTypeBuilder<Contract> builder)
    {
        base.Configure(builder);
        
        // Table name
        builder.ToTable("Contracts");
        
        // String properties
        builder.Property(e => e.ContractNumber)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(e => e.ContractType)
            .HasMaxLength(20)
            .IsRequired();
        
        // Unique constraint
        builder.HasIndex(e => e.ContractNumber)
            .IsUnique()
            .HasDatabaseName("IX_Contracts_ContractNumber");
        
        // Relationships
        builder.HasOne(e => e.Customer)
            .WithMany(c => c.Contracts)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Order)
            .WithOne(o => o.Contract)
            .HasForeignKey<Contract>(e => e.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Dealer)
            .WithMany(d => d.Contracts)
            .HasForeignKey(e => e.DealerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Staff)
            .WithOne(d => d.Contract)
            .HasForeignKey<Contract>(e => e.StaffId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes for performance
        builder.HasIndex(e => e.CustomerId);
        builder.HasIndex(e => e.OrderId);
        builder.HasIndex(e => e.DealerId);
        builder.HasIndex(e => e.ContractDate);
    }
}
