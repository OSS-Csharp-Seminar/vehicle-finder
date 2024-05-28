
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Impl
{
    public class EngineRepository : IEngineRepository
    {
        private readonly DatabaseContext _context;

        public EngineRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Engine>> GetAllEnginesAsync()
        {
            return await _context.Engines.ToListAsync();
        }

        public async Task<Engine> GetEngineByIdAsync(Guid id)
        {
            return await _context.Engines.FindAsync(id);
        }

        public async Task<Engine> AddEngineAsync(Engine engine)
        {
            _context.Engines.Add(engine);
            await _context.SaveChangesAsync();
            return engine;
        }

        public async Task<Engine> UpdateEngineAsync(Engine engine)
        {
            _context.Entry(engine).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return engine;
        }

        public async Task<bool> DeleteEngineAsync(Engine engine)
        {
            _context.Engines.Remove(engine);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

