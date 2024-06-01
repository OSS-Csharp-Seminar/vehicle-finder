using Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using VehicleFinder.Application.Interfaces;
using VehicleFinder.Application.Services;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IEngineService, EngineService>();
            services.AddScoped<IBodyService, BodyService>();
            services.AddScoped<IMaintenanceService, MaintenanceService>();
            services.AddScoped<IUserService, UserService>();

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
