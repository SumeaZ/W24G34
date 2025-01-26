using Microsoft.AspNetCore.Mvc;
using Eventify.Data;
using Eventify.Models;
using Eventify.DTOs.Venues.Input;
using Microsoft.EntityFrameworkCore;

namespace Eventify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VenueController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Venue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venue>>> GetVenues()
        {
            try
            {
                var venues = await _context.Venues.ToListAsync();
                return Ok(venues);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Venue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venue>> GetVenue(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            if (venue == null)
            {
                return NotFound();
            }
            return Ok(venue);
        }

        // POST: api/Venue
        [HttpPost]
        public async Task<ActionResult<Venue>> PostVenue(CreateVenueDTO venueDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var venue = new Venue
            {
                Name = venueDto.Name,
                Address = venueDto.Address,
                Capacity = venueDto.Capacity,
                ContactInfo = venueDto.ContactInfo,
                EventId = venueDto.EventId
            };

            _context.Venues.Add(venue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenue", new { id = venue.Id }, venue);
        }

        // PUT: api/Venue/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenue(int id, UpdateVenueDTO venueDto)
        {
            if (id != venueDto.Id)
            {
                return BadRequest("Venue ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var venue = await _context.Venues.FindAsync(id);
            if (venue == null)
            {
                return NotFound();
            }

            venue.Name = venueDto.Name;
            venue.Address = venueDto.Address;
            venue.Capacity = venueDto.Capacity;
            venue.ContactInfo = venueDto.ContactInfo;
            venue.EventId = venueDto.EventId;

            _context.Entry(venue).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();  
        }

        // DELETE: api/Venue/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenue(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            if (venue == null)
            {
                return NotFound();
            }

            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();

            return NoContent();  
        }
    }
}
