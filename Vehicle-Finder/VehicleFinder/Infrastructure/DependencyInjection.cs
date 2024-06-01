using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infrastructure.Persistence;
using VehicleFinder.Infrastructure.Repositories;
using VehicleFinder.Infrastructure.Repositories.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Impl;
using VehicleFinder.Infrastructure.Repositories.Impl;

namespace VehicleFinder.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("VehicleFinderDB")));

            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IEngineRepository, EngineRepository>();
            services.AddScoped<IBodyRepository, BodyRepository>();
            services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
