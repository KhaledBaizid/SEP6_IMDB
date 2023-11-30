﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared;

public class Director
{
    
   
    [ForeignKey("Movie")]
    public Int64? MovieId { get; set; }

    [ForeignKey("Person")]
    public Int64? PersonId { get; set; }

    public Movie? Movie { get; set; }
    public Person? Person { get; set; }
}