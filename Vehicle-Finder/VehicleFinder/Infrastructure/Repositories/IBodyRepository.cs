using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IBodyRepository
    {
        Task<IEnumerable<Body>> GetAllBodiesAsync();
        Task<Body> GetBodyByIdAsync(Guid id);
        Task<Body> AddBodyAsync(Body body);
        Task<Body> UpdateBodyAsync(Body body);
        Task<bool> DeleteBodyAsync(Body body);
    }
}
