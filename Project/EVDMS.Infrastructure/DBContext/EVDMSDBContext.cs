using System;
using Microsoft.EntityFrameworkCore;
using EVDMS.Core.Entities;
using EVDMS.Infrastructure.Configurations;

namespace EVDMS.Infrastructure.DBContext;

public class EVDMSDBContext : DbContext
{
    public EVDMSDBContext(DbContextOptions<EVDMSDBContext> options) : base(options)
    {
    }

    // Core Entities
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    
    // Business Entities
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Dealer> Dealers { get; set; }
    
    // Product Management
    public DbSet<Product> Products { get; set; }
    public DbSet<Inventory> Inventory { get; set; }
    
    // Dealer Workflow Entities
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    
    // Customer Management
    public DbSet<TestDriveAppointment> TestDriveAppointments { get; set; }
    
    // Marketing and Promotions
    public DbSet<Promotion> Promotions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Apply all configurations from the Configurations folder
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        
        // Or apply individual configurations if needed:
        // modelBuilder.ApplyConfiguration(new UserConfiguration());
        // modelBuilder.ApplyConfiguration(new ProductConfiguration());
        // modelBuilder.ApplyConfiguration(new RoleConfiguration());
        // modelBuilder.ApplyConfiguration(new PermissionConfiguration());
        // modelBuilder.ApplyConfiguration(new QuoteConfiguration());
        // modelBuilder.ApplyConfiguration(new OrderConfiguration());
        // modelBuilder.ApplyConfiguration(new ContractConfiguration());
        // modelBuilder.ApplyConfiguration(new InventoryConfiguration());
        // modelBuilder.ApplyConfiguration(new TestDriveAppointmentConfiguration());
        // modelBuilder.ApplyConfiguration(new PromotionConfiguration());
    }
}
