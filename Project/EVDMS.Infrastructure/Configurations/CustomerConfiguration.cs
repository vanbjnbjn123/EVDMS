using System;
using EVDMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.Infrastructure.Configurations;

public class CustomerConfiguration : AuditableConfiguration<Customer>
{
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        base.Configure(builder);
        
        // Table name
        builder.ToTable("Customers");
        
        // String properties
        builder.Property(e => e.FirstName)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(e => e.LastName)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(e => e.Email)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(20);
        
        builder.Property(e => e.PostalCode)
            .HasMaxLength(20);
        
        builder.Property(e => e.Country)
            .HasMaxLength(100);
        
        builder.Property(e => e.Status)
            .HasMaxLength(20)
            .HasDefaultValue("Active")
            .IsRequired();
        
        // Unique constraints
        builder.HasIndex(e => e.Email)
            .IsUnique()
            .HasDatabaseName("IX_Customers_Email");
        
        // Indexes
        builder.HasIndex(e => new { e.FirstName, e.LastName });
        builder.HasIndex(e => e.Status);
    }
}