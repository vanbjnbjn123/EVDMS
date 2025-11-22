using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EVDMS.Core.Entities;

namespace EVDMS.Infrastructure.Configurations;

public class UserOrganizationConfiguration : AuditableConfiguration<UserOrganization>
{
    public override void Configure(EntityTypeBuilder<UserOrganization> builder)
    {
        base.Configure(builder);

        // Table name
        builder.ToTable("UserOrganizations");
        
        // Has primary key
        builder.HasKey(uo => uo.UserId);
        
        // String properties
        builder.Property(uo => uo.OrganizationType)
            .HasMaxLength(50)
            .IsRequired();
        
        // Relationships
        builder.HasOne(uo => uo.User)
            .WithMany(u => u.UserOrganizations)
            .HasForeignKey(uo => uo.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(uo => uo.Dealer)
            .WithMany(u => u.UserOrganizations)
            .HasForeignKey(uo => uo.DealerId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Indexes for performance
        builder.HasIndex(uo => uo.UserId);
        builder.HasIndex(uo => uo.DealerId);
        builder.HasIndex(uo => uo.OrganizationType);
    }
}