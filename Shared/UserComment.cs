using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared;

public class UserComment
{  
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    
    [JsonIgnore]
    [ForeignKey("Movie")]
    public Int64? MovieId { get; set; }
    [ForeignKey("User")]
    [JsonIgnore]
    public int UserId { get; set; }
    
    public string? Comment { get; set; }
    
    public DateTime? CommentTime { get; set; }
    
    [JsonIgnore]
    public Movie? Movie { get; set; }
    
 
    public User? User { get; set; }
}