using Domain.Entities;

namespace VehicleFinder.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle> GetVehicleByIdAsync(Guid id);
        Task<Vehicle> CreateVehicleAsync(Vehicle vehicle);
        Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle);
        Task<bool> DeleteVehicleAsync(Guid id);
        IEnumerable<Vehicle> SearchVehicle(IEnumerable<Vehicle> vehicles, string searchString);

        IEnumerable<Vehicle> FilterVehicleByManufacturingYear(IEnumerable<Vehicle> vehicles, int? filterYearStart, int? filterYearEnd);

        IEnumerable<Vehicle> FilterVehicleByKilometeres(IEnumerable<Vehicle> vehicles, int? filterKilometersStart, int? filterKilometersEnd);

        IEnumerable<Vehicle> FilterVehicleByConsumption(IEnumerable<Vehicle> vehicles, float? filterConsumptionStart, float? filterConsumptionEnd);

        IEnumerable<Vehicle> SortVehicle(IEnumerable<Vehicle> vehicles, string sortString);
    }
}
