using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EVDMS.Infrastructure.DBContext;
using EVDMS.Application.Interfaces.Repositories;
using EVDMS.Infrastructure.Repositories;
using EVDMS.Application.Interfaces;
using EVDMS.Infrastructure.Helpers;

namespace EVDMS.Infrastructure;

public static class AddInfraConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Add Entity Framework DbContext with PostgreSQL
        services.AddDbContext<EVDMSDBContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("PostgreSQLConnection"),
                npgsqlOptions =>
                {
                    // PostgreSQL specific configurations
                    npgsqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorCodesToAdd: null);
                    
                    // Use migrations assembly if needed
                    npgsqlOptions.MigrationsAssembly(typeof(EVDMSDBContext).Assembly.FullName);
                });
            
            // Enable sensitive data logging in development
            #if DEBUG
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
            #endif
        });

        // Add Health Checks
        services.AddHealthChecks()
            .AddDbContextCheck<EVDMSDBContext>("database");

        // Register repositories and services here when they are created
        // Example:
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();

        // Add Unit of Work pattern if implemented
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Add background services for data processing
        // services.AddHostedService<DataCleanupService>();
        // services.AddHostedService<InventoryUpdateService>();

        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // Add infrastructure-specific services

        // Add caching services
        services.AddMemoryCache();
        
        // Add distributed cache if using Redis
        // services.AddStackExchangeRedisCache(options =>
        // {
        //     options.Configuration = "localhost:6379";
        // });
        
        // Add password hashing services
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        // Add email services
        // services.AddScoped<IEmailService, EmailService>();
        
        // Add file storage services
        // services.AddScoped<IFileStorageService, FileStorageService>();
        
        // Add notification services
        // services.AddScoped<INotificationService, NotificationService>();
        
        // Add audit logging services
        // services.AddScoped<IAuditService, AuditService>();

        return services;
    }
}
