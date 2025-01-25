using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Eventify.Models;

using System.Threading.Tasks;
using System.Linq;

namespace Eventify.Controllers
{
    [ApiController]
    [Route("api")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        [HttpGet("GetAllRoles")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }

       
        [HttpGet("GetRoleByName")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetRoleByName(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);
            if (role == null)
            {
                return NotFound("Role not found.");
            }
            return Ok(role);
        }

        
        [HttpPost("CreateRole")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> CreateRole([FromBody] Role role)
        {
            var roleExist = await _roleManager.RoleExistsAsync(role.Name);
            if (roleExist)
            {
                return BadRequest("Role already exists.");
            }

            var newRole = new IdentityRole(role.Name);
            var result = await _roleManager.CreateAsync(newRole);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return CreatedAtAction(nameof(GetRoleByName), new { name = role.Name }, newRole);
        }

       
        [HttpPut("UpdateRole")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> UpdateRole(string name, [FromBody] Role role)
        {
            var existingRole = await _roleManager.FindByNameAsync(name);
            if (existingRole == null)
            {
                return NotFound("Role not found.");
            }

            existingRole.Name = role.Name;
            var result = await _roleManager.UpdateAsync(existingRole);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Role updated successfully.");
        }

        
        [HttpDelete("DeleteRole")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteRole(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);
            if (role == null)
            {
                return NotFound("Role not found.");
            }

            var result = await _roleManager.DeleteAsync(role);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Role deleted successfully.");
        }
    }

    
}
