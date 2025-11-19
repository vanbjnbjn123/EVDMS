using System;
using Microsoft.Extensions.DependencyInjection;

namespace EVDMS.Application;

public static class DI
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DI).Assembly));

        // Register other application services here

        return services;
    }
}
