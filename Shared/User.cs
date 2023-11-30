using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared;

public class User
{  
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    [JsonIgnore]
    [Required]
    public string? Mail { get; set; }
    [JsonIgnore]
    public string? Password { get; set; }
    [JsonIgnore]
    public string? Username { get; set; }
    [JsonIgnore]
    public List<Favourite>? Favourites { get; set; }
    [JsonIgnore]
    public List<UserRating>? UserRatings { get; set; }

}