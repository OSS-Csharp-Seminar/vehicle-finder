using Domain.Entities;

namespace VehicleFinder.Application.Interfaces
{
    public interface IBodyService
    {
        Task<IEnumerable<Body>> GetAllBodiesAsync();
        Task<Body> GetBodyByIdAsync(Guid id);
        Task<Body> AddBodyAsync(Body body);
        Task<Body> UpdateBodyAsync(Guid id, Body body);
        Task<bool> DeleteBodyAsync(Guid id);

    }
}
