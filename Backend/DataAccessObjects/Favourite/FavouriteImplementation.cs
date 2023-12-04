using Backend.EFCData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccessObjects.Favourite;

public class FavouriteImplementation : IFavouriteInterface
{
    private readonly DataContext _systemContext;

    public FavouriteImplementation(DataContext systemContext)
    {
        _systemContext = systemContext;
    }

    public async Task AddFavouriteMovieAsync(int userid, long movieid)
    {
        
        try
        {
            Shared.Favourite favourite = new Shared.Favourite
            {
                UserId = userid,
                MovieId = movieid
            };
            var isFavouriteExist = await _systemContext.Favourites.FirstOrDefaultAsync(f=>f==favourite);
            if (isFavouriteExist == null)
            {
                await _systemContext.Favourites.AddAsync(favourite);
                await _systemContext.SaveChangesAsync();
                
            }
            
        }
        catch (Exception e)
        { 
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<List<Shared.Favourite>> GetListOfFavouriteMovies(long id)
    {
        try
        {
            List<Shared.Favourite> favourites = new List<Shared.Favourite>();
            favourites= await _systemContext.Favourites.Where(f=>f.UserId==id).Include(m=>m.Movie).ThenInclude(s=>s.Stars).ThenInclude(s=>s.Person)
                .Include(m=>m.Movie).ThenInclude(d=>d.Directors).ThenInclude(d=>d.Person).Include(m=>m.Movie.Rating).ToListAsync();
            return favourites;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        

    }

    public async  Task DeleteFavouriteMovieAsync(int userid, long movieid)
    {
        var deletedMovie = new Shared.Favourite
        {
            UserId = userid,
            MovieId = movieid
        };
         _systemContext.Favourites?.Attach(deletedMovie);
        _systemContext.Favourites?.Remove(deletedMovie);
        await _systemContext.SaveChangesAsync();
        
    }
}