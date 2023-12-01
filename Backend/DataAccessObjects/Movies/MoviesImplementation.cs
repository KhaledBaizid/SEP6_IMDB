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
                .Include(r=>r.Rating).Take(100)
                .ToListAsync()!;
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
            movies = await _systemContext.Movies?.Where(d=>d.Title != null && d.Title.ToLower().Contains(title)).Include(s=>s.Stars)!.ThenInclude(s=>s.Person)
                .Include(d=>d.Directors)!.ThenInclude(d=>d.Person)
                .Include(r=>r.Rating).Take(100)
                .ToListAsync()!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
        return movies;
    }
}