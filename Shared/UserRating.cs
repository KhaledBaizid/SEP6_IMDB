using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared;

public class UserRating
{
    
    
    [ForeignKey("Movie")]
    public Int64? MovieId { get; set; }

    [ForeignKey("User")]
    public int? UserId { get; set; }
    [JsonIgnore]
    public float? RatingValue { get; set; }
    [JsonIgnore]
    public Movie? Movie { get; set; }
    [JsonIgnore]
    public User? User { get; set; }
}