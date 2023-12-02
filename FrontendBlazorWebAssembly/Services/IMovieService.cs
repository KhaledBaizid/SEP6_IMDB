using Shared;

namespace FrontendBlazorWebAssembly.Services;

public interface IMovieService
{
    public Task<List<Movie>> GetAllMoviesByTitle(string title);
    public Task<List<Movie>> GetAllMovies(); 
}