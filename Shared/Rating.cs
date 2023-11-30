using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared;

public class Rating
{
    
    [Key, ForeignKey("Movie")]
    public Int64? MovieId { get; set; }

    public double? RatingValue { get; set; }
    public Int64? Votes { get; set; }

    public Movie? Movie { get; set; }
}