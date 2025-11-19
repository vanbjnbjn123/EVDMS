using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EVDMS.Core.Entities;

namespace EVDMS.Infrastructure.Configurations;

public class AuditableConfiguration<T> : IEntityTypeConfiguration<T> where T : Auditable
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        // Created At with PostgreSQL default
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("NOW()") // PostgreSQL
            .IsRequired();

        // Updated At
        builder.Property(e => e.UpdatedAt)
            .IsRequired(false);

        // Version for concurrency control (PostgreSQL uses xmin for optimistic concurrency)
        // For PostgreSQL, we'll use a simple integer version field instead of byte array
        builder.Property(e => e.Version)
            .IsConcurrencyToken();

        // Soft Delete
        builder.Property(e => e.IsDeleted)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.DeletedAt)
            .IsRequired(false);

        // Global query filter to exclude soft-deleted records
        builder.HasQueryFilter(e => !e.IsDeleted);

        // Index for performance on common queries
        builder.HasIndex(e => e.IsDeleted);
        builder.HasIndex(e => e.CreatedAt);
    }
}
