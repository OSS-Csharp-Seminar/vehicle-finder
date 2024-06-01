using Domain.Entities;

namespace VehicleFinder.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
    }
}
