using System.Diagnostics;
using Eventify.Data;
using Eventify.DTOs.User.Input;
using Eventify.DTOs.User.Output;
using Eventify.Interface;
using Eventify.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Eventify.Controllers
{
    [ApiController] 
    [Route("api")]
    public class UserController : ControllerBase
    {
        
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly ITokenRepository _tokenRepo;
        private readonly ITokenService _tokenService;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext context, ITokenRepository tokenRepo, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _tokenRepo = tokenRepo;
            _tokenService = tokenService;   
        }


        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO registerDto)
        {
            var user = new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("User registered successfully");
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDTO.Email);
            if (user == null) return Unauthorized("Invalid Username!");

            var rolesResult = await _userManager.GetRolesAsync(user);
            var role = "User";
            if (rolesResult.Count != 0)
            {
                role = "Admin";
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if (!result.Succeeded) return Unauthorized("Username not found and/or password incorrect!");

            var refreshToken = _tokenService.GenerateRefreshToken(user);

            //Add associated refresh token to user.
            //If user already has refresh token, this overwrites it.
            await _tokenRepo.AddRefreshToken(refreshToken);

            return Ok
            (
                new LoggedInDTO
                {
                    accessToken = _tokenService.CreateToken(user, role),
                    refreshToken = refreshToken.Token
                }
            );

        }


        [HttpPost("AdminCreate")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> AdminCreate(CreateUserDTO createUserDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                //Create new user model
                var user = new User
                {
                    FirstName = createUserDto.FirstName,
                    LastName = createUserDto.LastName,
                    Email = createUserDto.Email,
                    UserName = createUserDto.Email
                };

                //Create user using CreateAsync
                var createdUser = await _userManager.CreateAsync(user, createUserDto.Password);
                if (!createdUser.Succeeded) return StatusCode(500, createdUser.Errors);

                if (createUserDto.IsAdmin)
                {
                    var adminResult = await _userManager.AddToRoleAsync(user, "Admin");
                    if (adminResult.Succeeded)
                    {
                        return Ok(UserMapper.ToGetUserDTO(user, "Admin"));
                    }

                    return StatusCode(500, "User created without admin role");
                }

                return Ok(UserMapper.ToGetUserDTO(user, "User"));

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet("GetAllUser")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetAllUser()
        {
          
            var users = await _userManager.Users.ToListAsync();
            var usersDto = new List<GetUserDTO>();
            foreach (var user in users)
            {
                var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                var userDto = UserMapper.ToGetUserDTO(user, isAdmin ? "Admin" : "User");
                usersDto.Add(userDto);
            }

            return Ok(usersDto);
        }


        [HttpGet("GetUserById")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetUserById(string userId)
        {

            if (!ModelState.IsValid) return BadRequest("Id cannot be empty");
        
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return StatusCode(404, "User does not exist!");
            }

            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (isAdmin)
            {
                return Ok(UserMapper.ToGetUserDTO(user, "Admin"));
            }
            return Ok(UserMapper.ToGetUserDTO(user, "User"));
        }



        [HttpPut("UpdateUserById")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateUserById(string id, UpdateUserDTO updateUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != updateUserDto.Id)
            {
                return BadRequest("The user ID in the URL does not match the ID in the request body.");
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            user.Email = updateUserDto.Email;
            user.UserName = updateUserDto.Email; 

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                return BadRequest(updateResult.Errors);
            }

            return Ok("User updated successfully.");
        }


        [HttpDelete("DeleteUserById")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteUserById(string id)
        {
            
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest("Failed to delete the user.");
            }

            return Ok("User deleted successfully.");
        }







    }
}
