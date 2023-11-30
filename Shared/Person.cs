using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared;

public class Person
{   
    
    [Key]
    public Int64 Id { get; set; }

    [Required]
    public string Name { get; set; }

    public decimal? Birth { get; set; }

    public List<Star> StarredMovies { get; set; }
    public List<Director> DirectedMovies { get; set; }
}