using Eventify.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Eventify.Models;


namespace Eventify.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ScheduleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllSchedules")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetAllSchedules()
        {
            var schedules = await _context.Schedules.ToListAsync();
            return Ok(schedules);
        }

        [HttpGet("GetScheduleById")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetScheduleById(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound("Schedule not found.");
            }
            return Ok(schedule);
        }

        [HttpPost("CreateSchedule")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> CreateSchedule(CreateScheduleDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var schedule = new Schedule
            {
                EventId = dto.EventId,
                Title = dto.Title,
                Description = dto.Description,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetScheduleById), new { id = schedule.Id }, schedule);
        }

        [HttpPut("UpdateSchedule")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateSchedule(int id, UpdateScheduleDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Schedule ID mismatch.");
            }

            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound("Schedule not found.");
            }

            schedule.Title = dto.Title;
            schedule.Description = dto.Description;
            schedule.StartTime = dto.StartTime;
            schedule.EndTime = dto.EndTime;
            schedule.UpdatedAt = DateTime.UtcNow;

            _context.Entry(schedule).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Schedule updated successfully.");
        }

        [HttpDelete("DeleteSchedule")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound("Schedule not found.");
            }

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();

            return Ok("Schedule deleted successfully.");
        }
    }
}