using Domain.Entities;
using Domain.Enums;
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

        public IEnumerable<Engine> SearchEngine(IEnumerable<Engine> engines, string searchString)
        {
            if(!string.IsNullOrEmpty(searchString))
            {
                engines = engines.Where(engine => engine.EngineName.Contains(searchString));
            }

            return engines;
        }

        public IEnumerable<Engine> FilterEngine(IEnumerable<Engine> engines, int? filterStart, int? filterEnd, string filterString)
        {
            if (filterString == "EnginePower")
            {
               if(filterStart.HasValue)
               {
                    engines = engines.Where(engine => engine.EnginePower >= filterStart);
               }
               if(filterEnd.HasValue)
               {
                    engines = engines.Where(engine => engine.EnginePower <= filterEnd);
               }
            }

            if (filterString == "GearCount")
            {
                if (filterStart.HasValue)
                {
                    engines = engines.Where(engine => engine.GearCount >= filterStart);
                }
                if (filterEnd.HasValue)
                {
                    engines = engines.Where(engine => engine.GearCount <= filterEnd);
                }
            }

            if (filterString == "EngineCapacity")
            {
                if (filterStart.HasValue)
                {
                    engines = engines.Where(engine => engine.EngineCapacity >= filterStart);
                }
                if (filterEnd.HasValue)
                {
                    engines = engines.Where(engine => engine.EngineCapacity <= filterEnd);
                }
            }

            if (filterString == "CylinderCount")
            {
                if (filterStart.HasValue)
                {
                    engines = engines.Where(engine => engine.CylinderCount >= filterStart);
                }
                if (filterEnd.HasValue)
                {
                    engines = engines.Where(engine => engine.CylinderCount <= filterEnd);
                }
            }

            return engines;
        }

        public IEnumerable<Engine> FilterEngineByEngineType(IEnumerable<Engine> engines, EngineType? filterEngineType)
        {
            if (filterEngineType.HasValue)
            {
                engines = engines.Where(engine => engine.EngineType == filterEngineType.Value);
            }

            return engines;
        }

        public IEnumerable<Engine> FilterEngineByShifterType(IEnumerable<Engine> engines, ShifterType? filterShifterType)
        {
            if (filterShifterType.HasValue)
            {
                engines = engines.Where(engine => engine.ShifterType == filterShifterType);
            }

            return engines;
        }

        public IEnumerable<Engine> FilterEngineByDriveType(IEnumerable<Engine> engines, EngineDriveType? filterEnginePower)
        {
            if (filterEnginePower.HasValue)
            {
                engines = engines.Where(engine => engine.DriveType == filterEnginePower);
            }

            return engines;
        }

        public IEnumerable<Engine> SortEngine(IEnumerable<Engine> engines, string sortString)
        {
            switch (sortString)
            {
                case "EngineNameDesc":
                    return engines.OrderByDescending(engine => engine.EngineName);
                case "EngineTypeAsc":
                    return engines.OrderBy(engine => engine.EngineType);
                case "EngineTypeDesc":
                    return engines.OrderByDescending(engine => engine.EngineType);
                case "EnginePowerAsc":
                    return engines.OrderBy(engine => engine.EnginePower);
                case "EnginePowerDesc":
                    return engines.OrderByDescending(engine => engine.EnginePower);
                case "ShifterAsc":
                    return engines.OrderBy(engine => engine.ShifterType).ThenBy(engine => engine.GearCount);
                case "ShifterDesc":
                    return engines.OrderByDescending(engine => engine.ShifterType).ThenByDescending(engine => engine.GearCount);
                case "DriveTypeAsc":
                    return engines.OrderBy(engine => engine.DriveType);
                case "DriveTypeDesc":
                    return engines.OrderByDescending(engine => engine.DriveType);
                case "EngineCapacityAsc":
                    return engines.OrderBy(engine => engine.EngineCapacity);
                case "EngineCapacityDesc":
                    return engines.OrderByDescending(engine => engine.EngineCapacity);
                case "CylinderCountAsc":
                    return engines.OrderBy(engine => engine.CylinderCount);
                case "CylinderCountDesc":
                    return engines.OrderByDescending(engine => engine.CylinderCount);
                default:
                    return engines.OrderBy(engine => engine.EngineName);
            }
        }
    }
}
