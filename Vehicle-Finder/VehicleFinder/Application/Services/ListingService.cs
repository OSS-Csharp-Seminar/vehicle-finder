using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Impl;
using System;
using VehicleFinder.Infrastructure.Repositories.Interfaces;

namespace Application.Services
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public ListingService(IListingRepository listingRepository, IVehicleRepository vehicleRepository)
        {
            _listingRepository = listingRepository;
            _vehicleRepository = vehicleRepository;
        }
        public async Task<IEnumerable<Listing>> GetAllListingAsync()
        { 
            return await _listingRepository.GetAllListingsAsync();
        }
        public async Task<Listing> GetListingByIdAsync(Guid guid)
        {
            var listing = await _listingRepository.GetListingById(guid);
            if (listing == null)
            {
                throw new KeyNotFoundException("Listing not found.");
            }
            return listing;
        }
        public async Task<Listing> CreateListingAsync(Listing listing) 
        {
            if(listing == null)
            {
                throw new ArgumentNullException(nameof(listing));
            }

            if (listing.Vehicle != null && listing.Vehicle.Id != Guid.Empty)
            {
                var existingVehicle = await _vehicleRepository.GetVehicleByIdAsync(listing.Vehicle.Id);
                if (existingVehicle != null)
                {
                    listing.Vehicle = existingVehicle;
                }
            }

            return await _listingRepository.CreateListingAsync(listing);
        }
        public async Task<Listing> UpdateListingAsync(Guid id, Listing listing)
        {
            if (listing == null)
                throw new ArgumentNullException(nameof(listing));

            var existingVehicle = await _listingRepository.GetListingById(listing.Id);

            if (existingVehicle == null)
                throw new KeyNotFoundException("Vehicle not found!");

            return await _listingRepository.UpdateListingAsync(listing);
        }

        public async Task<bool> DeleteListingAsync(Guid id)
        {
            var listing = await _listingRepository.GetListingById(id);
            if (listing == null)
            {
                throw new ArgumentNullException("Listing not found while attempting to delete it!");
            }
            return await _listingRepository.DeleteListingAsync(listing);
        }
        public IEnumerable<Listing> SearchListings(IEnumerable<Listing> listings, string? searchString) //potencijalno treba biti primjer za ostale search-ove, zbog NULL provjere i toLower
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                listings = listings.Where(listing =>
                    (listing.Title != null && listing.Title.ToLower().Contains(searchString)) ||
                    (listing.Description != null && listing.Description.ToLower().Contains(searchString)));
            }

            return listings;
        }

        public IEnumerable<Listing> FilterListingByDate(IEnumerable<Listing> listings, DateTime? dateTimeStart, DateTime? dateTimeEnd)
        {
            if(!dateTimeStart.HasValue)
            {
                listings = listings.Where(listing => listing.PostDatetime >= dateTimeStart);
            }
            if(!dateTimeEnd.HasValue)
            {
                listings = listings.Where(listing => listing.PostDatetime <= dateTimeEnd);
            }

            return listings;
        }

        public IEnumerable<Listing> FilterListingsByPrice(IEnumerable<Listing> listings, decimal? filterPriceStart, decimal? filterPriceEnd)
        {
            if (!filterPriceStart.HasValue)
            {
                listings = listings.Where(listing => listing.Price >= filterPriceStart);
            }
            if (!filterPriceEnd.HasValue)
            {
                listings = listings.Where(listing => listing.Price <= filterPriceEnd);
            }

            return listings;
        }
        public IEnumerable<Listing> SortListing(IEnumerable<Listing> listings, string sortString)
        {
            switch (sortString)
            {
                case "PriceAsc":
                    listings = listings.OrderBy(listing => listing.Price).ToList();
                    break;
                case "PriceDesc":
                    listings = listings.OrderByDescending(listing => listing.Price).ToList();
                    break;
                case "PostDateTimeAsc":
                    listings = listings.OrderBy(listing => listing.PostDatetime).ToList();
                    break;
                case "PostDateTimeDesc":
                    listings = listings.OrderByDescending(listing => listing.PostDatetime).ToList();
                    break;
                case "TitleAsc":
                    listings = listings.OrderBy(listing => listing.Title).ToList();
                    break;
                case "TitleDesc":
                    listings = listings.OrderByDescending(listing => listing.Title).ToList();
                    break;
                default:
                    listings = listings.OrderBy(listing => listing.Title).ToList();
                    break;
            }

            return listings;
        }



    }
}
