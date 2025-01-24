using Microsoft.AspNetCore.Identity;

namespace Eventify.Models
{
    public class Role : IdentityRole
    {
        // Add custom properties here if necessary, like a description
        public string Description { get; set; }
    }
}

