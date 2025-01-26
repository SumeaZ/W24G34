using System;
using System.ComponentModel.DataAnnotations;

namespace Eventify.DTOs.Registrations
{
    public class CreateRegistrationDTO
    {
        [Required(ErrorMessage = "UserId is required.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "EventId is required.")]
        public int EventId { get; set; }

        [Required(ErrorMessage = "RegistrationDate is required.")]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [MaxLength(20, ErrorMessage = "Status cannot be over 20 characters.")]
        public Status Status { get; set; }
    }
}
