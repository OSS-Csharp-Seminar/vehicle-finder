using Domain.Entities;
using Infrastructure.Repositories;
using System.Threading.Tasks;
using VehicleFinder.Application.Interfaces;
using VehicleFinder.Infrastructure.Repositories;
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
            var engine = await _engineRepository.GetEngineByIdAsync(id);
            if (engine == null)
                throw new KeyNotFoundException("Engine not found!");

            return await _engineRepository.GetEngineByIdAsync(id);
        }

        public async Task<Engine> AddEngineAsync(Engine engine)
        {
            if (engine == null)
                throw new ArgumentNullException(nameof(engine));

            return await _engineRepository.AddEngineAsync(engine);
        }

        public async Task<Engine> UpdateEngineAsync(Engine engine)
        {
            if (engine == null)
                throw new ArgumentNullException(nameof(engine));

            var existingEngine = await _engineRepository.GetEngineByIdAsync(engine.Id);

            if (existingEngine == null)
                throw new KeyNotFoundException("Engine not found!");

            return await _engineRepository.UpdateEngineAsync(engine);
        }

        public async Task<bool> DeleteEngineAsync(Guid id)
        {
            var existingEngine = await _engineRepository.GetEngineByIdAsync(id);
            if (existingEngine == null)
            {
                return false;
            }
            return await _engineRepository.DeleteEngineAsync(existingEngine);
        }
    }
}
