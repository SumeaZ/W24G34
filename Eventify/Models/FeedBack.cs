using System.ComponentModel.DataAnnotations;
using Eventify.Models;

public class FeedBack
{
    public int FeedBackId { get; set; }

    public int EventId { get; set; }

    [Range(1, 5, ErrorMessage = "Rating should be between 1 and 5")]
    public int Rating { get; set; }

    [MaxLength(500)]
    public string? Comments { get; set; }

    public string? UserId { get; set; } 

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; } 

    // Navigation property
    public Events? Event { get; set; }
}
