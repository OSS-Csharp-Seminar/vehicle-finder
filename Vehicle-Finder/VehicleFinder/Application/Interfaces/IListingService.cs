using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IListingService
    {
        Task<IEnumerable<Listing>> GetAllListingAsync();
        Task<Listing> GetListingByIdAsync(Guid guid);
        Task<Listing> CreateListingAsync(Listing listing);
        Task<Listing> UpdateListingAsync(Guid id, Listing listing);
        Task<bool> DeleteListingAsync(Guid id);

        IEnumerable<Listing> SearchListings(IEnumerable<Listing> listings, string searchString);

        IEnumerable<Listing> FilterListingsByPrice(IEnumerable<Listing> listings, decimal? filterPriceStart, decimal? filterPriceEnd);

        IEnumerable<Listing> FilterListingByDate(IEnumerable<Listing> listings, DateTime? dateTimeStart, DateTime? dateTimeEnd);
        IEnumerable<Listing> SortListing(IEnumerable<Listing> listings, string sortString);

    }
}
