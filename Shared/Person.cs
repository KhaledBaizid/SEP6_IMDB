using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared;

public class  Person
{   
    
    [Key]
    public Int64? Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
    
    public decimal? Birth { get; set; }
    [JsonIgnore]
    public List<Star>? StarredMovies { get; set; }
    [JsonIgnore]
    public List<Director>? DirectedMovies { get; set; }
}