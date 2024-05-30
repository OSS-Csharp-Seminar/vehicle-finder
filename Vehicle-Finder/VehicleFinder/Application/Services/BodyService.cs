using Domain.Entities;
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
    }
}
