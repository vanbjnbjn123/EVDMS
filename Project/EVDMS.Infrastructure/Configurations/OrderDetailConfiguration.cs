using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EVDMS.Core.Entities;

namespace EVDMS.Infrastructure.Configuration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => od.OrderId);
            
            // Configure properties
            builder.Property(od => od.Quantity)
                .IsRequired();
            
            builder.Property(od => od.BasePrice)
                .HasPrecision(18, 2)
                .IsRequired();
            
            builder.Property(od => od.LineTotal)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(od => od.DiscountAmount)
                .HasPrecision(18, 2);
            
            // Configure relationships
            builder.HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}