﻿using System.ComponentModel.DataAnnotations;

namespace Eventify.DTOs.User.Output
{
    public class GetUserDTO
    {
        public string? Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "First name should be at least 2 characters")]
        [MaxLength(20, ErrorMessage = "First name cannot be over 20 characters")]
        public string? FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Last name should be at least 2 characters")]
        [MaxLength(20, ErrorMessage = "Last name cannot be over 20 characters")]
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }


    }
}
