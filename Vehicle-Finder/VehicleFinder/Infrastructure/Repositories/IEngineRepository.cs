using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IEngineRepository
    {
        Task<IEnumerable<Engine>> GetAllEnginesAsync();
        Task<Engine> GetEngineByIdAsync(Guid id);
        Task<Engine> AddEngineAsync(Engine engine);
        Task<Engine> UpdateEngineAsync(Engine engine);
        Task<bool> DeleteEngineAsync(Engine engine);
    }
}
