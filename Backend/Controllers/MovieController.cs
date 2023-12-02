using Backend.DataAccessObjects.Movies;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]

public class MovieController : ControllerBase
{
    private IMoviesInterface _moviesInterface;


    public MovieController(IMoviesInterface moviesInterface)
    {
        _moviesInterface = moviesInterface;
    }
    [EnableCors]
    [HttpGet]
    
    public async Task<ActionResult<List<Movie>?>>GetAllMoviesAsync()
    {
        try
        {
            return StatusCode(200,await _moviesInterface.GetAllMoviesAsync()); 
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
        
    }
    [EnableCors]
    [HttpGet]
    [Route("title")]
    public async Task<ActionResult<List<Movie>>> GetMoviesByTitleAsync(string title)
    {
        try
        {
            return StatusCode(200,await _moviesInterface.GetMoviesByTitleAsync(title)); 
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}