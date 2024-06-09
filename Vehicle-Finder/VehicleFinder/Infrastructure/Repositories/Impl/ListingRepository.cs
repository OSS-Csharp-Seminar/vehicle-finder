using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Impl
{
    public class ListingRepository : IListingRepository
    {
        private readonly DatabaseContext _context;

        public ListingRepository(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }
        public async Task<IEnumerable<Listing>> GetAllListingsAsync()
        {
            return await _context.Listings.ToListAsync();
        }

        public async Task<Listing> GetListingById(Guid id)
        {
            return await _context.Listings.FindAsync(id);
        }
        public async Task<Listing> CreateListingAsync(Listing listing)
        {
            _context.Listings.Add(listing);
            await _context.SaveChangesAsync();
            return listing;
        }

        public async Task<Listing> UpdateListingAsync(Listing listing)
        {
            _context.Entry(listing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return listing;
        }
        public async Task<bool> DeleteListingAsync(Listing listing)
        {
            _context.Listings.Remove(listing);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
