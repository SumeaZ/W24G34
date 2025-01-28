using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eventify.Data;
using Eventify.Models;
using Eventify.DTOs.Registrations;

namespace Eventify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegistrationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Registration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistrations()
        {
            var registrations = await _context.Registrations.ToListAsync();
            return Ok(registrations); // Return list of registrations
        }

        // GET: api/Registration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Registration>> GetRegistration(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            return Ok(registration);
        }

        // POST: api/Registration
        [HttpPost]
        public async Task<ActionResult<Registration>> PostRegistration(CreateRegistrationDTO registrationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registration = new Registration
            {
                UserId = registrationDto.UserId,
                EventId = registrationDto.EventId,
                RegistrationDate = registrationDto.RegistrationDate,
                Status = registrationDto.Status
            };

            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();

            // After successful creation return the created registration data
            return CreatedAtAction("GetRegistration", new { id = registration.Id }, registration);
        }

        // PUT: api/Registration/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistration(int id, UpdateRegistrationDTO registrationDto)
        {
            if (id != registrationDto.Id)
            {
                return BadRequest("Registration ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registration = await _context.Registrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            // Update registration fields with DTO data
            registration.Status = registrationDto.Status;
            registration.RegistrationDate = registrationDto.RegistrationDate;

            _context.Entry(registration).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Registration/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            _context.Registrations.Remove(registration);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
