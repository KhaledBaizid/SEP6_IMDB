using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared;

public class Favourite
{   
  
    [JsonIgnore]
    [ForeignKey("Movie")]
    public Int64? MovieId { get; set; }
    [JsonIgnore]
    [ForeignKey("User")]
    public int? UserId { get; set; }
    
    public Movie? Movie { get; set; }
    [JsonIgnore]
    public User? User { get; set; }
}