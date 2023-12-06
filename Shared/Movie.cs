using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Shared;

public class Movie
{   
    
    [Key]
    public Int64? Id { get; set; }
    
    [Required]
    public string? Title { get; set; }
    
    public decimal? Year { get; set; }
    
    public List<Star>? Stars { get; set; }
    
    public List<Director>? Directors { get; set; }
    
    public Rating? Rating { get; set; }
    [JsonIgnore]
    public List<Favourite>? Favourites { get; set; }
    [JsonIgnore]
    public List<UserRating>? UserRatings { get; set; }
    
    [JsonIgnore]
    public List<UserComment>? UserComments { get; set; }
}