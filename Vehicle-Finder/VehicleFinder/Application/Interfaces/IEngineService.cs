using Domain.Entities;

namespace VehicleFinder.Application.Interfaces
{
    public interface IEngineService
    {
        Task<IEnumerable<Engine>> GetAllEnginesAsync();
        Task<Engine> GetEngineByIdAsync(Guid id);
        Task<Engine> AddEngineAsync(Engine engine);
        Task<Engine> UpdateEngineAsync(Engine engine);
        Task<bool> DeleteEngineAsync(Guid id);

    }
}
