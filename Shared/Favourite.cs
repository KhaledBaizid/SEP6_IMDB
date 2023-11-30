using System.ComponentModel.DataAnnotations.Schema;

namespace Shared;

public class Favourite
{
    [ForeignKey("Movie")]
    public Int64 MovieId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    public Movie Movie { get; set; }
    public User User { get; set; }
}