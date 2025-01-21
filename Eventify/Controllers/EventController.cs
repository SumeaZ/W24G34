using Eventify.Data;
using Eventify.Models;
using Eventify.DTOs.Events.Input;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Eventify.Controllers
{
    [ApiController]
    [Route("api")]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet("GetAllEvents")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _context.Events.ToListAsync();
            return Ok(events);
        }


        [HttpGet("GetEventById")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);

            if (eventItem == null)
            {
                return NotFound("Event not found.");
            }

            return Ok(eventItem);
        }


        [HttpPost("CreateEvents")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> CreateEvent(CreateEventsDTO eventDto)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventItem = new Events
            {
                EventName = eventDto.EventName,
                StartDate = eventDto.StartDate,
                EndDate = eventDto.EndDate,
                Location = eventDto.Location
            };

            _context.Events.Add(eventItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEventById), new { id = eventItem.EventsId }, eventItem);
        }


        [HttpPut("UpdateEventById")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateEventById(int id,UpdateEventsDTO eventDto)
        {
            if (id != eventDto.EventsId)
            {
                return BadRequest("Event ID mismatch.");
            }

            var existingEvent = await _context.Events.FindAsync(id);
            if (existingEvent == null)
            {
                return NotFound("Event not found.");
            }

            existingEvent.EventName = eventDto.EventName;
            existingEvent.StartDate = eventDto.StartDate;
            existingEvent.EndDate = eventDto.EndDate;
            existingEvent.Location = eventDto.Location;

            _context.Entry(existingEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound("Event not found.");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Event updated successfully.");
        }


        [HttpDelete("DeleteEventById")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteEventById(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null)
            {
                return NotFound("Event not found.");
            }

            _context.Events.Remove(eventItem);
            await _context.SaveChangesAsync();

            return Ok("Event deleted successfully.");
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventsId == id);
        }
    }
}
