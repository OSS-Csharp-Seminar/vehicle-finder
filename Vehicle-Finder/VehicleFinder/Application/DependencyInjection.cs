using Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using VehicleFinder.Application.Interfaces;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IEngineService, EngineService>();

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
