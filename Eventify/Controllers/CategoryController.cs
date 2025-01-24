using Eventify.Data;
using Eventify.Models;
    using Eventify.DTOs.Categories.Input;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Eventify.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("GetAllCategories")]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("GetCategoryById")]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return NotFound("Category not found.");

            return Ok(category);
        }


        [HttpPost("CreateCategory")]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO createCategoryDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = new Category
            {
                Name = createCategoryDTO.Name,
                Description = createCategoryDTO.Description
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }


        [HttpPut("UpdateCategory")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDTO updateCategoryDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound("Category not found.");

            category.Name = updateCategoryDTO.Name;
            category.Description = updateCategoryDTO.Description;

            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("DeleteCategory")]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound("Category not found.");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //private bool CategoryExists(int id)
        //{
        //    return _context.Categories.Any(c => c.Id == id);
        //}
    }
}
