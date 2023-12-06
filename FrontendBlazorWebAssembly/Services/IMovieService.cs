using FrontendBlazorWebAssembly.Model;
using Shared;

namespace FrontendBlazorWebAssembly.Services;

public interface IMovieService
{
    public Task<List<Movie>> GetAllMoviesByTitle(string title);
    public Task<List<Movie>> GetAllMovies();
    public Task<MovieDetails> GetMovieDetails(int Id);
    
    public  Task<List<MovieIMG>> GetAllMovieDetailsById(long? Id);
    public Task<List<MovieDetails>>GetAllMovieDetails();
}