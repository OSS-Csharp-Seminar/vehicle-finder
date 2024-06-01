using Domain.Entities;
using Infrastructure.Repositories;
using System.Threading.Tasks;
using VehicleFinder.Application.Interfaces;
using VehicleFinder.Infrastructure.Repositories;
using VehicleFinder.Infrastructure.Repositories.Interfaces;

namespace VehicleFinder.Application.Services
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly IMaintenanceRepository _maintenanceRepository;

        public MaintenanceService(IMaintenanceRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }

        public async Task<IEnumerable<Maintenance>> GetAllMaintenancesAsync()
        {
            return await _maintenanceRepository.GetAllMaintenancesAsync();
        }

        public async Task<Maintenance> GetMaintenanceByIdAsync(Guid id)
        {
            var maintenance = await _maintenanceRepository.GetMaintenanceByIdAsync(id);
            if (maintenance == null)
                throw new KeyNotFoundException("Maintenance not found!");

            return await _maintenanceRepository.GetMaintenanceByIdAsync(id);
        }

        public async Task<Maintenance> AddMaintenanceAsync(Maintenance maintenance)
        {
            if (maintenance == null)
                throw new ArgumentNullException(nameof(maintenance));

            return await _maintenanceRepository.AddMaintenanceAsync(maintenance);
        }

        public async Task<Maintenance> UpdateMaintenanceAsync(Guid id, Maintenance maintenance)
        {
            if (maintenance == null)
                throw new ArgumentNullException(nameof(maintenance));

            var existingMaintenance = await _maintenanceRepository.GetMaintenanceByIdAsync(id);

            if (existingMaintenance == null)
                throw new KeyNotFoundException("Maintenance not found!");

            return await _maintenanceRepository.UpdateMaintenanceAsync(maintenance);
        }

        public async Task<bool> DeleteMaintenanceAsync(Guid id)
        {
            var existingMaintenance = await _maintenanceRepository.GetMaintenanceByIdAsync(id);
            if (existingMaintenance == null)
            {
                return false;
            }
            return await _maintenanceRepository.DeleteMaintenanceAsync(existingMaintenance);
        }
    }
}
