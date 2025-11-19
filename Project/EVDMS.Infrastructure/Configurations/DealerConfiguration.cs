using System;
using EVDMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.Infrastructure.Configurations;

public class DealerConfiguration : AuditableConfiguration<Dealer>
{
    public override void Configure(EntityTypeBuilder<Dealer> builder)
    {
        base.Configure(builder);
        
        // Table name
        builder.ToTable("Dealers");
        
        // String properties
        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(e => e.Email)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(20);
        
        builder.Property(e => e.Tax)
            .HasMaxLength(50);
        
        // Unique constraints
        
        builder.HasIndex(e => e.Email)
            .IsUnique()
            .HasDatabaseName("IX_Dealers_Email");
        
        // Indexes
        builder.HasIndex(e => e.IsActive);
    }
}
