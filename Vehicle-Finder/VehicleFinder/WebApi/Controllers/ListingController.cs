using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly IListingService _listingService;
        public ListingController(IListingService listingService)
        {
            _listingService = listingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Listing>>> GetAllListings()
        {
            var listings = await _listingService.GetAllListingAsync();

            return Ok(listings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Listing>> GetListingById(Guid id)
        {
            var listing = await _listingService.GetListingByIdAsync(id);

            if (listing == null)
            {
                return NotFound();
            }

            return Ok(listing);
        }

        [HttpPost]
        public async Task<ActionResult<Listing>> CreateListing(Listing listing)
        {
            var createdListing = await _listingService.CreateListingAsync(listing);
            return CreatedAtAction(nameof(GetListingById), new { id = createdListing.Id }, createdListing);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateListing(Guid id, Listing listing)
        {
            var updateListing = await _listingService.UpdateListingAsync(id, listing);
            if (updateListing == null)
            {
                return NotFound();
            }

            return Ok(updateListing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _listingService.DeleteListingAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
