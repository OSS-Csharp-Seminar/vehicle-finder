using Domain.Entities;
using Infrastructure.Repositories;
using System.Threading.Tasks;
using VehicleFinder.Application.Interfaces;
using VehicleFinder.Infrastructure.Repositories.Interfaces;

namespace Application.Services
{
    public class EngineService : IEngineService
    {
        private readonly IEngineRepository _engineRepository;

        public EngineService(IEngineRepository engineRepository)
        {
            _engineRepository = engineRepository;
        }

        public async Task<IEnumerable<Engine>> GetAllEnginesAsync()
        {
            return await _engineRepository.GetAllEnginesAsync();
        }

        public async Task<Engine> GetEngineByIdAsync(Guid id)
        {
            return await _engineRepository.GetEngineByIdAsync(id);
        }

        public async Task<Engine> AddEngineAsync(Engine engine)
        {
            return await _engineRepository.AddEngineAsync(engine);
        }

        public async Task<Engine> UpdateEngineAsync(Engine engine)
        {
            return await _engineRepository.UpdateEngineAsync(engine);
        }

        public async Task<bool> DeleteEngineAsync(Guid id)
        {
            return await _engineRepository.DeleteEngineAsync(id);
        }
    }
}
