using Backend.EFCData;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Backend.DataAccessObjects.Movies;

public class MoviesImplementation: IMoviesInterface
{
    private readonly DataContext _systemContext;

    public MoviesImplementation(DataContext systemContext)
    {
        _systemContext = systemContext;
    }
    
    
    public async Task<List<Movie>?> GetAllMoviesAsync()
    {
        List<Movie> movies = new List<Movie>();
        try
        {
            movies = await _systemContext.Movies?.Include(s=>s.Stars)!.ThenInclude(s=>s.Person)
                .Include(d=>d.Directors)!.ThenInclude(d=>d.Person)
                .Include(r=>r.Rating)
                .Include(u=>u.UserComments)!.ThenInclude(uc=>uc.User)
                .Take(100)
                .ToListAsync()!;
            foreach (var movie in  movies)
            {
                if (movie.UserComments != null)
                    foreach (var userComment in movie.UserComments)
                    {
                        if (userComment.User != null) userComment.User.Password = null;
                        if (userComment.User != null) userComment.User.Mail = null;
                    }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
        return movies;
        
    }

    public async Task<List<Movie>?> GetMoviesByTitleAsync(string title)
    {
        List<Movie> movies = new List<Movie>();
        try
        {
            movies = await _systemContext.Movies?.Where(d=>d.Title != null && d.Title.ToLower().Contains(title.ToLower())).Include(s=>s.Stars)!.ThenInclude(s=>s.Person)
                .Include(d=>d.Directors)!.ThenInclude(d=>d.Person)
                .Include(r=>r.Rating).
                 Include(r=>r.Rating).Include(u=>u.UserComments)!.ThenInclude(uc=>uc.User).Take(100)
                .ToListAsync()!;
            foreach (var movie in  movies)
            {
                if (movie.UserComments != null)
                    foreach (var userComment in movie.UserComments)
                    {
                        if (userComment.User != null) userComment.User.Password = null;
                        if (userComment.User != null) userComment.User.Mail = null;
                    }
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
        return movies;
    }
}