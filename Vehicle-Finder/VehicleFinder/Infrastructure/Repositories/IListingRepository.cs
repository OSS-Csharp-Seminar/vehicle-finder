using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IListingRepository
    {
        Task<IEnumerable<Listing>> GetAllListingsAsync();
        Task<Listing> GetListingById(Guid id);
        Task<Listing> CreateListingAsync(Listing listing);
        Task<Listing> UpdateListingAsync(Listing listing);
        Task<bool> DeleteListingAsync(Listing listing);
    }
}
