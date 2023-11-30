using System.ComponentModel.DataAnnotations.Schema;

namespace Shared;

public class UserRating
{
    
    
    [ForeignKey("Movie")]
    public Int64 MovieId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    public float RatingValue { get; set; }

    public Movie Movie { get; set; }
    public User User { get; set; }
}