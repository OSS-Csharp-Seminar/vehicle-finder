using Domain.Entities;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Impl;
using VehicleFinder.Application.Interfaces;
using VehicleFinder.Infrastructure.Repositories.Interfaces;

namespace Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IEngineRepository _engineRepository;
        private readonly IBodyRepository _bodyRepository;
        private readonly IMaintenanceRepository _maintenanceRepository;

        public VehicleService(IVehicleRepository vehicleRepository, IEngineRepository engineRepository, IBodyRepository bodyRepository, IMaintenanceRepository maintenanceRepository)
        {
            _vehicleRepository = vehicleRepository;
            _engineRepository = engineRepository;
            _bodyRepository = bodyRepository;
            _maintenanceRepository = maintenanceRepository;
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

            if (vehicle.VehicleBody != null && vehicle.VehicleBody.Id != Guid.Empty)
            {
                var existingBody = await _bodyRepository.GetBodyByIdAsync(vehicle.VehicleBody.Id);
                if (existingBody != null)
                {
                    vehicle.VehicleBody = existingBody;
                }
            }

            if (vehicle.VehicleEngine != null && vehicle.VehicleEngine.Id != Guid.Empty)
            {
                var existingEngine = await _engineRepository.GetEngineByIdAsync(vehicle.VehicleEngine.Id);
                if (existingEngine != null)
                {
                    vehicle.VehicleEngine = existingEngine;
                }
            }

            if (vehicle.VehicleMaintenance != null && vehicle.VehicleMaintenance.Id != Guid.Empty)
            {
                var existingMaintenance = await _maintenanceRepository.GetMaintenanceByIdAsync(vehicle.VehicleMaintenance.Id);
                if (existingMaintenance != null)
                {
                    vehicle.VehicleMaintenance = existingMaintenance;
                }
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

        public IEnumerable<Vehicle> SearchVehicle(IEnumerable<Vehicle> vehicles, string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(vehicle => vehicle.Make.Contains(searchString) || vehicle.Model.Contains(searchString));
            }

            return vehicles;
        }

        public IEnumerable<Vehicle> FilterVehicleByManufacturingYear(IEnumerable<Vehicle> vehicles, int? filterYearStart, int? filterYearEnd)
        {
            if (filterYearStart.HasValue)
            {
                vehicles = vehicles.Where(vehicle => vehicle.ManufactureYear >= filterYearStart);
            }
            if (filterYearEnd.HasValue)
            {
                vehicles = vehicles.Where(vehicle => vehicle.ManufactureYear <= filterYearEnd);
            }

            return vehicles;
        }

        public IEnumerable<Vehicle> FilterVehicleByKilometeres(IEnumerable<Vehicle> vehicles, int? filterKilometersStart, int? filterKilometersEnd)
        {
            if (filterKilometersStart.HasValue)
            {
                vehicles = vehicles.Where(vehicle => vehicle.Kilometers >= filterKilometersStart);
            }
            if (filterKilometersEnd.HasValue)
            {
                vehicles = vehicles.Where(vehicle => vehicle.Kilometers <= filterKilometersEnd);
            }

            return vehicles;
        }
        public IEnumerable<Vehicle> FilterVehicleByConsumption(IEnumerable<Vehicle> vehicles, float? filterConsumptionStart, float? filterConsumptionEnd)
        {
            if(filterConsumptionStart.HasValue)
            {
                vehicles = vehicles.Where(vehicle => vehicle.Consumption >= filterConsumptionStart);
            }
            if (filterConsumptionEnd.HasValue)
            {
                vehicles = vehicles.Where(vehicle => vehicle.Consumption <= filterConsumptionEnd);
            }
            return vehicles;
        }

        public IEnumerable<Vehicle> SortVehicle(IEnumerable<Vehicle> vehicles, string sortString)
        {
            switch (sortString)
            {
                case "MakeDesc":
                    vehicles = vehicles.OrderByDescending(vehicle => vehicle.Make).ToList();
                    break;
                case "ModelAsc":
                    vehicles = vehicles.OrderBy(vehicle => vehicle.Model).ToList();
                    break;
                case "ModelDesc":
                    vehicles = vehicles.OrderByDescending(vehicle => vehicle.Model).ToList();
                    break;
                case "ManufacturingYearAsc":
                    vehicles = vehicles.OrderBy(vehicles => vehicles.ManufactureYear).ToList();
                    break;
                case "ManufacturingYearDesc":
                    vehicles = vehicles.OrderByDescending(vehicles => vehicles.ManufactureYear).ToList();
                    break;
                case "ModelYearAsc":
                    vehicles = vehicles.OrderBy(vehicles => vehicles.ModelYear).ToList();
                    break;
                case "ModelYearDesc":
                    vehicles = vehicles.OrderByDescending(vehicles => vehicles.ModelYear).ToList();
                    break;
                case "KilometersAsc":
                    vehicles = vehicles.OrderBy(vehicles => vehicles.Kilometers).ToList();
                    break;
                case "KilometersDesc":
                    vehicles = vehicles.OrderByDescending(vehicles => vehicles.Kilometers).ToList();
                    break;
                default:
                    vehicles = vehicles.OrderBy(vehicles => vehicles.Make).ToList();
                    break;
            }

            return vehicles;
        }

       
    }
}
