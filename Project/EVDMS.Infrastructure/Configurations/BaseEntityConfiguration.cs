using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EVDMS.Core.Entities;

namespace EVDMS.Infrastructure.Configurations;

public class EntityBaseConfiguration<T> : AuditableConfiguration<T> where T : EntityBase
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);
        // Primary Key
        builder.HasKey(e => e.Id);
        
        // Configure Id as GUID with PostgreSQL default
        builder.Property(e => e.Id)
            .HasDefaultValueSql("gen_random_uuid()") // PostgreSQL
            .IsRequired();
    }
}