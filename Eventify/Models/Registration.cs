using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eventify.DTOs.Registrations;

namespace Eventify.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        //[ForeignKey]
        public string? UserId { get; set; }



        [Required]
        public int EventId { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [MaxLength(20)]
        public Status Status { get; set; }
    }
}
