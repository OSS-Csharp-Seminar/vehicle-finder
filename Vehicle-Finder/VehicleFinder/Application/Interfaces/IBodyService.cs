using Domain.Entities;
using Domain.Enums;

namespace VehicleFinder.Application.Interfaces
{
    public interface IBodyService
    {
        Task<IEnumerable<Body>> GetAllBodiesAsync();
        Task<Body> GetBodyByIdAsync(Guid id);
        Task<Body> AddBodyAsync(Body body);
        Task<Body> UpdateBodyAsync(Guid id, Body body);
        Task<bool> DeleteBodyAsync(Guid id);
        IEnumerable<Body> FilterBody(IEnumerable<Body> bodies, int? filterBodyStart, int? filterBodyEnd, string filterString);
        IEnumerable<Body> FilterBodyByAcType(IEnumerable<Body> bodies, AcTypes? filterAcType);
        IEnumerable<Body> FilterBodyByEquipment(IEnumerable<Body> bodies, CarEquipement? filterEquipment);
        IEnumerable<Body> FilterBodyByBodyShape(IEnumerable<Body> bodies, CarBodyShape? filterBodyShape);
        IEnumerable<Body> SortBody(IEnumerable<Body> bodies, string sortString);
    }
}
