using System;
using System.ComponentModel.DataAnnotations;

namespace Eventify.DTOs.Registrations
{
    public class UpdateRegistrationDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }  
    }

    public enum Status
    {
        Pending,
        Confirmed,
        Canceled
    }
}
