using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared;

public class User
{  
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    [Required]
    public string? Mail { get; set; }

    public string? Password { get; set; }

    public string? Username { get; set; }

    public List<Favourite>? Favourites { get; set; }
    public List<UserRating>? UserRatings { get; set; }

}