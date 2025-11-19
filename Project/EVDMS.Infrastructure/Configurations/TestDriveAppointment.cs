using System;
using EVDMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EVDMS.Infrastructure.Configurations;

public class TestDriveAppointmentConfiguration : AuditableConfiguration<TestDriveAppointment>
{
    public override void Configure(EntityTypeBuilder<TestDriveAppointment> builder)
    {
        base.Configure(builder);
        
        // Table name
        builder.ToTable("TestDriveAppointments");
        
        // String properties
        builder.Property(e => e.Status)
            .HasMaxLength(20)
            .HasDefaultValue("Scheduled")
            .IsRequired();
        
        builder.Property(e => e.Notes)
            .HasMaxLength(1000);
        
        // Relationships
        builder.HasOne(e => e.Customer)
            .WithMany(c => c.TestDriveAppointments)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Product)
            .WithMany(p => p.TestDriveAppointments)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Dealer)
            .WithMany(d => d.TestDriveAppointments)
            .HasForeignKey(e => e.DealerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes for performance
        builder.HasIndex(e => e.CustomerId);
        builder.HasIndex(e => e.ProductId);
        builder.HasIndex(e => e.DealerId);
        builder.HasIndex(e => e.Status);
        builder.HasIndex(e => e.ScheduledDate);
        builder.HasIndex(e => new { e.ScheduledDate, e.Status });
    }
}
