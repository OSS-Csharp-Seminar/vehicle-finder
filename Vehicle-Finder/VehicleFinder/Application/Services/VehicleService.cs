using Domain.Entities;
using VehicleFinder.Application.Interfaces;
using VehicleFinder.Infrastructure.Repositories.Interfaces;

namespace Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _vehicleRepository.GetAllVehiclesAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(Guid id)
        {
            return await _vehicleRepository.GetVehicleByIdAsync(id);
        }

        public async Task<Vehicle> CreateVehicleAsync(Vehicle vehicle)
        {
            return await _vehicleRepository.AddVehicleAsync(vehicle);
        }

        public async Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
        {
            return await _vehicleRepository.UpdateVehicleAsync(vehicle);
        }

        public async Task<bool> DeleteVehicleAsync(Guid id)
        {
            return await _vehicleRepository.DeleteVehicleAsync(id);
        }
    }
}
