using System.Diagnostics;
using Eventify.Data;
using Eventify.DTOs.User.Input;
using Eventify.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventify.Controllers
{
    [ApiController] 
    [Route("api")]
    public class UserController : ControllerBase
    {
        
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;

        }



        [HttpGet("GetUser")] 
        public IActionResult GetUser()
        {
            return Ok(new { message = "Welcome to Eventify!" });
        }



        [HttpGet("GetUserById")]
        public IActionResult GetUserById()
        {
            return Ok(new { message = "Privacy Policy" });
        }



        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                //Create User from DTO
                var user = new User
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    Email = registerDto.Email,
  
                };


                //Create user using CreateAsync
                var createdUser = await _userManager.CreateAsync(user, registerDto.Password);
                if (createdUser.Succeeded)
                {
                    return Ok("User created!");
                }
                return BadRequest(createdUser.Errors);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }

        
    }
}
