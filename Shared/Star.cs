using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared;

public class Star 
{
  

    [JsonIgnore]
    [ForeignKey("Movie")]
    public Int64? MovieId { get; set; }
    [JsonIgnore]
    [ForeignKey("Person")]
    public Int64? PersonId { get; set; }
    [JsonIgnore]
    public Movie? Movie { get; set; }
    
    public Person? Person { get; set; }
}