using Domain.Entities;
using Infrastructure.Repositories;
using VehicleFinder.Application.Interfaces;
using VehicleFinder.Infrastructure.Repositories.Interfaces;

namespace Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IEngineRepository _engineRepository;

        public VehicleService(IVehicleRepository vehicleRepository, IEngineRepository engineRepository)
        {
            _vehicleRepository = vehicleRepository;
            _engineRepository = engineRepository;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _vehicleRepository.GetAllVehiclesAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(Guid id)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            if (vehicle == null)
                throw new KeyNotFoundException("Vehicle not found!");

            return vehicle;
        }

        public async Task<Vehicle> CreateVehicleAsync(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            if (vehicle.Engine != null)
            {
                var createdEngine = await _engineRepository.AddEngineAsync(vehicle.Engine);
                vehicle.Engine = createdEngine;
                vehicle.EngineId = createdEngine.Id;
            }
            else if (vehicle.EngineId.HasValue)
            {
                var existingEngine = await _engineRepository.GetEngineByIdAsync(vehicle.EngineId.Value);
                if (existingEngine == null)
                    throw new KeyNotFoundException("Engine not found!");

                vehicle.Engine = existingEngine;
            }

            return await _vehicleRepository.AddVehicleAsync(vehicle);
        }

        public async Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            var existingVehicle = await _vehicleRepository.GetVehicleByIdAsync(vehicle.Id);

            if (existingVehicle == null)
                throw new KeyNotFoundException("Vehicle not found!");

            return await _vehicleRepository.UpdateVehicleAsync(vehicle);
        }

        public async Task<bool> DeleteVehicleAsync(Guid id)
        {
            var existingVehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            if (existingVehicle == null)
            {
                return false;
            }
            return await _vehicleRepository.DeleteVehicleAsync(existingVehicle);
        }
    }
}
