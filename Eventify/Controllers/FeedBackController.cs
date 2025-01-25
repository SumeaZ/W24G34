using Eventify.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Eventify.Models;



namespace Eventify.Controllers
{
    [ApiController]
    [Route("api")]
    public class FeedbackController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GetAllFeedbacks
        [HttpGet("GetAllFeedbacks")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetAllFeedbacks()
        {
            var feedbacks = await _context.FeedBacks.ToListAsync();
            return Ok(feedbacks);
        }

        // GET: api/GetFeedbackById?id=1
        [HttpGet("GetFeedbackById")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            var feedbackItem = await _context.FeedBacks.FindAsync(id);

            if (feedbackItem == null)
            {
                return NotFound("Feedback not found.");
            }

            return Ok(feedbackItem);
        }

        // POST: api/CreateFeedback
        [HttpPost("CreateFeedback")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> CreateFeedback(CreateFeedBackDTO feedbackDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feedbackItem = new FeedBack
            {
                UserId = feedbackDto.UserId,
                EventId = feedbackDto.EventId,
                Rating = feedbackDto.Rating,
                Comments = feedbackDto.Comments,
                CreatedAt = DateTime.UtcNow
            };

            _context.FeedBacks.Add(feedbackItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFeedbackById), new { id = feedbackItem.FeedBackId }, feedbackItem);
        }

        [HttpPut("UpdateFeedbackById")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateFeedbackById(int id, UpdateFeedBackDTO feedbackDto)
        {
            if (id != feedbackDto.FeedbackId)
            {
                return BadRequest("Feedback ID mismatch.");
            }

            var existingFeedback = await _context.FeedBacks.FindAsync(id);
            if (existingFeedback == null)
            {
                return NotFound("Feedback not found.");
            }

            existingFeedback.Rating = feedbackDto.Rating;
            existingFeedback.Comments = feedbackDto.Comments;
            existingFeedback.UpdatedAt = DateTime.UtcNow;  

            _context.Entry(existingFeedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(id))
                {
                    return NotFound("Feedback not found.");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Feedback updated successfully.");
        }


        [HttpDelete("DeleteFeedBackById")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteFeedbackById(int id)
        {
            var feedbackItem = await _context.FeedBacks.FindAsync(id);
            if (feedbackItem == null)
            {
                return NotFound("Feedback not found.");
            }

            _context.FeedBacks.Remove(feedbackItem);
            await _context.SaveChangesAsync();

            return Ok("Feedback deleted successfully.");
        }

        private bool FeedbackExists(int id)
        {
            return _context.FeedBacks.Any(f => f.FeedBackId == id);
        }



    }
}
