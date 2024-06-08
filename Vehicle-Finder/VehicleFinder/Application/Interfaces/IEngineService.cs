using Domain.Entities;
using Domain.Enums;

namespace VehicleFinder.Application.Interfaces
{
    public interface IEngineService
    {
        Task<IEnumerable<Engine>> GetAllEnginesAsync();
        Task<Engine> GetEngineByIdAsync(Guid id);
        Task<Engine> AddEngineAsync(Engine engine);
        Task<Engine> UpdateEngineAsync(Engine engine);
        Task<bool> DeleteEngineAsync(Guid id);

        IEnumerable<Engine> SearchEngine(IEnumerable<Engine> engines, string searchString);
        IEnumerable<Engine> FilterEngine(IEnumerable<Engine> engines, int? filterStart, int? filterEnd, string filterString);
        IEnumerable<Engine> FilterEngineByEngineType(IEnumerable<Engine> engines, EngineType? filterEngineType);
        IEnumerable<Engine> FilterEngineByShifterType(IEnumerable<Engine> engines, ShifterType? filterShifterType);
        IEnumerable<Engine> FilterEngineByDriveType(IEnumerable<Engine> engines, EngineDriveType? filterEnginePower);
        IEnumerable<Engine> SortEngine(IEnumerable<Engine> engines, string sortString);
    }
}
