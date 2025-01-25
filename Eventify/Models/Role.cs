using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Eventify.Models
{
    public class Role : IdentityRole

    {
        public string? Description { get; set; }
    }
}

