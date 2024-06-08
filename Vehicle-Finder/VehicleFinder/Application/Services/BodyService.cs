using Domain.Entities;
using Domain.Enums;
using Infrastructure.Repositories;
using VehicleFinder.Application.Interfaces;

namespace Application.Services
{
    public class BodyService : IBodyService
    {
        private readonly IBodyRepository _bodyRepository;

        public BodyService(IBodyRepository bodyRepository)
        {
            _bodyRepository = bodyRepository;
        }

        public async Task<IEnumerable<Body>> GetAllBodiesAsync()
        {
            return await _bodyRepository.GetAllBodiesAsync();
        }

        public async Task<Body> GetBodyByIdAsync(Guid id)
        {
            var body = await _bodyRepository.GetBodyByIdAsync(id);
            if (body == null)
                throw new KeyNotFoundException("Body not found!");

            return await _bodyRepository.GetBodyByIdAsync(id);
        }

        public async Task<Body> AddBodyAsync(Body body)
        {
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return await _bodyRepository.AddBodyAsync(body);
        }

        public async Task<Body> UpdateBodyAsync(Guid id, Body body)
        {
            var existingBody = await _bodyRepository.GetBodyByIdAsync(id);
            if (existingBody == null)
            {
                return null;
            }

            existingBody = body;

            return await _bodyRepository.UpdateBodyAsync(existingBody);
            
        }

        public async Task<bool> DeleteBodyAsync(Guid id)
        {
            var existingBody = await _bodyRepository.GetBodyByIdAsync(id);
            if (existingBody == null)
            {
                return false;
            }
            return await _bodyRepository.DeleteBodyAsync(existingBody);
        }

        public IEnumerable<Body> FilterBody(IEnumerable<Body> bodies, int? filterStart, int? filterEnd, string filterString)
        {
            if (string.IsNullOrWhiteSpace(filterString) || !filterStart.HasValue && !filterEnd.HasValue)
                return bodies;

            switch (filterString)
            {
                case "DoorCount":
                    if (filterStart.HasValue)
                        bodies = bodies.Where(b => b.DoorCount >= filterStart);
                    if (filterEnd.HasValue)
                        bodies = bodies.Where(b => b.DoorCount <= filterEnd);
                    break;
                case "SeatCount":
                    if (filterStart.HasValue)
                        bodies = bodies.Where(b => b.SeatCount >= filterStart);
                    if (filterEnd.HasValue)
                        bodies = bodies.Where(b => b.SeatCount <= filterEnd);
                    break;
                default:
                    break;
            }

            return bodies;
        }

        public IEnumerable<Body> FilterBodyByAcType(IEnumerable<Body> bodies, AcTypes? filterAcType)
        {
            if (filterAcType.HasValue)
            {
                bodies = bodies.Where(b => b.AcType == filterAcType.Value);
            }

            return bodies;
        }

        public IEnumerable<Body> FilterBodyByEquipment(IEnumerable<Body> bodies, CarEquipement? filterEquipment)
        {
            if (filterEquipment.HasValue)
            {
                bodies = bodies.Where(b => b.Equipment == filterEquipment.Value);
            }

            return bodies;
        }

        public IEnumerable<Body> FilterBodyByBodyShape(IEnumerable<Body> bodies, CarBodyShape? filterBodyShape)
        {
            if (filterBodyShape.HasValue)
            {
                bodies = bodies.Where(b => b.BodyShape == filterBodyShape.Value);
            }

            return bodies;
        }
        public IEnumerable<Body> SortBody(IEnumerable<Body> bodies, string sortString)
        {
            switch (sortString)
            {
                case "DoorCountAsc":
                    return bodies.OrderBy(b => b.DoorCount);
                case "DoorCountDesc":
                    return bodies.OrderByDescending(b => b.DoorCount);
                case "SeatCountAsc":
                    return bodies.OrderBy(b => b.SeatCount);
                case "SeatCountDesc":
                    return bodies.OrderByDescending(b => b.SeatCount);
                case "AcTypeAsc":
                    return bodies.OrderBy(b => b.AcType);
                case "AcTypeDesc":
                    return bodies.OrderByDescending(b => b.AcType);
                case "EquipmentAsc":
                    return bodies.OrderBy(b => b.Equipment);
                case "EquipmentDesc":
                    return bodies.OrderByDescending(b => b.Equipment);
                case "BodyShapeAsc":
                    return bodies.OrderBy(b => b.BodyShape);
                case "BodyShapeDesc":
                    return bodies.OrderByDescending(b => b.BodyShape);
                default:
                    return bodies.OrderBy(b => b.Id);
            }
        }
    }
}
