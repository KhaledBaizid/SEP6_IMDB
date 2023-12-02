using Backend.DataAccessObjects.Favourite;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class FavouriteController : ControllerBase
{
    private IFavouriteInterface _favouriteInterface;

    public FavouriteController(IFavouriteInterface favouriteInterface)
    {
        _favouriteInterface = favouriteInterface;
    }
    [EnableCors] 
    [HttpPost]
    public async Task<ActionResult> AddMovieToFavourite(int userid, long movieid)
    {
        try
        {
            await _favouriteInterface.AddFavouriteMovieAsync(userid,movieid);
            return StatusCode(200);
        }
        catch (Exception e)
        {
            return   StatusCode(500, e.Message);
        }
    }
    [EnableCors]
    [HttpGet]
    public async Task<ActionResult<List<Favourite>>> GetTheFavouriteListOfMoviesByUserID(long id)
    {
        try
        {
           return StatusCode(200,await _favouriteInterface.GetListOfFavouriteMovies(id));
            
        }
        catch (Exception e)
        {
            return   StatusCode(500, e.Message);
        }
    }
}