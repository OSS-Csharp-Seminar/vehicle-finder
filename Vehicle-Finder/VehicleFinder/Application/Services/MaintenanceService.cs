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

        public IEnumerable<Maintenance> SearchMaintenance(IEnumerable<Maintenance> maintenances, string searchString)
        {
            if(!string.IsNullOrEmpty(searchString))
            {
                maintenances = maintenances.Where(maintenance => maintenance.FullDetails.Contains(searchString) || maintenance.BasicDetails.Contains(searchString));
            }

            return maintenances;
        }

        public IEnumerable<Maintenance> FilterMaintenanceCost(IEnumerable<Maintenance> maintenances, float? filterCostStart, float? filterCostEnd, string filterString)
        {
            if(filterString == "BasicCost")
            {
                if (filterCostStart.HasValue) 
                {
                    maintenances = maintenances.Where(maintenance => maintenance.BasicCost >= filterCostStart);
                }
                if (filterCostEnd.HasValue)
                {
                    maintenances = maintenances.Where(maintenance => maintenance.BasicCost <= filterCostEnd);
                }
            }
            if (filterString == "FullCost")
            {
                if (filterCostStart.HasValue)
                {
                    maintenances = maintenances.Where(maintenance => maintenance.FullCost >= filterCostStart);
                }
                if (filterCostEnd.HasValue)
                {
                    maintenances = maintenances.Where(maintenance => maintenance.FullCost <= filterCostEnd);
                }
            }

            return maintenances;
        }

        public IEnumerable<Maintenance> SortMaintenance(IEnumerable<Maintenance> maintenances, string sortString)
        {
            switch (sortString)
            {
                case "BasicCostAsc":
                    return maintenances.OrderBy(m => m.BasicCost);
                case "BasicCostDesc":
                    return maintenances.OrderByDescending(m => m.BasicCost);
                case "FullCostAsc":
                    return maintenances.OrderBy(m => m.FullCost);
                case "FullCostDesc":
                    return maintenances.OrderByDescending(m => m.FullCost);
                case "BasicDetailsAsc":
                    return maintenances.OrderBy(m => m.BasicDetails);
                case "BasicDetailsDesc":
                    return maintenances.OrderByDescending(m => m.BasicDetails);
                case "FullDetailsAsc":
                    return maintenances.OrderBy(m => m.FullDetails);
                case "FullDetailsDesc":
                    return maintenances.OrderByDescending(m => m.FullDetails);
                default:
                    return maintenances.OrderBy(m => m.Id);
            }
        }
    }
}
