
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Impl
{
    public class BodyRepository : IBodyRepository
    {
        private readonly DatabaseContext _context;

        public BodyRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Body>> GetAllBodiesAsync()
        {
            return await _context.Bodies.ToListAsync();
        }

        public async Task<Body> GetBodyByIdAsync(Guid id)
        {
            return await _context.Bodies.FindAsync(id);
        }

        public async Task<Body> AddBodyAsync(Body body)
        {
            _context.Bodies.Add(body);
            await _context.SaveChangesAsync();
            return body;
        }

        public async Task<Body> UpdateBodyAsync(Body body)
        {
            _context.Entry(body).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return body;
        }

        public async Task<bool> DeleteBodyAsync(Body body)
        {
            _context.Bodies.Remove(body);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

