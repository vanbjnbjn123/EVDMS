using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EVDMS.Core.Entities;

namespace EVDMS.Infrastructure.Configurations;

public class QuoteDetailConfiguration : AuditableConfiguration<QuoteDetail>
{
    public override void Configure(EntityTypeBuilder<QuoteDetail> builder)
    {
        base.Configure(builder);

        // Table name
        builder.ToTable("QuoteDetails");
        
        // Has primary key
        builder.HasKey(qd => new { qd.QuoteId, qd.ProductId });
        
        // Required properties
        builder.Property(qd => qd.Quantity)
            .IsRequired();
        
        builder.Property(qd => qd.BasePrice)
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.Property(qd => qd.LineTotal)
            .HasPrecision(18, 2)
            .IsRequired();
        
        builder.Property(qd => qd.DiscountAmount)
            .HasPrecision(18, 2);
        
        builder.Property(qd => qd.FinalLineTotal)
            .HasPrecision(18, 2)
            .IsRequired();
        
        // Pricing breakdown properties
        builder.Property(qd => qd.BasePrice)
            .HasPrecision(18, 2);
        
        // Relationships
        builder.HasOne(qd => qd.Quote)
            .WithMany(q => q.QuoteDetails)
            .HasForeignKey(qd => qd.QuoteId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(qd => qd.Product)
            .WithMany()
            .HasForeignKey(qd => qd.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Indexes for performance
        builder.HasIndex(qd => qd.QuoteId);
        builder.HasIndex(qd => qd.ProductId);
        builder.HasIndex(qd => new { qd.QuoteId, qd.ProductId });
    }
}