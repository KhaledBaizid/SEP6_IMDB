using Backend.EFCData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly DataContext _systemContext;
    //SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=C:\\Users\\baizi\\Desktop\\SEP-6\\movies.db;");


    public WeatherForecastController(ILogger<WeatherForecastController> logger,DataContext systemContext)
    {
        _logger = logger;
        _systemContext = systemContext;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        ///////////////////////////EFC Get Movies/////////////////
        
        var c = _systemContext.Movies?.Where(d=>d.Title != null && d.Title.ToLower().Contains("venom")).Include(s=>s.Stars)!.ThenInclude(s=>s.Person)
            .Include(d=>d.Directors)!.ThenInclude(d=>d.Person)
            .Include(r=>r.Rating)
            .ToList();
        if (c != null)
            foreach (var m in c)
            {
                Console.WriteLine("Title: " + m.Title);
                if (m.Rating != null)
                {
                    Console.WriteLine("Rating: " + m.Rating.RatingValue);
                    Console.WriteLine("Votes: " + m.Rating.Votes);
                }

                if (m.Stars != null)
                {
                    Console.WriteLine("Stars");
                    foreach (var s in m.Stars)
                    {
                        Console.WriteLine(s.PersonId);
                        //Console.WriteLine(_systemContext.Stars.Include(p=>p.));
                        Console.WriteLine(s.Person?.Name);
                    }

                    Console.WriteLine("Directors");
                    if (m.Directors != null)
                        foreach (var d in m.Directors)
                        {
                            Console.WriteLine(d.PersonId);
                            //Console.WriteLine(_systemContext.Stars.Include(p=>p.));
                            Console.WriteLine(d.Person?.Name);
                        }
                }

                Console.WriteLine("*****************************");
            }

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}