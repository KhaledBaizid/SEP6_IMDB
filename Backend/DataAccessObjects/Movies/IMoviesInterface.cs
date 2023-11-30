using Shared;

namespace Backend.DataAccessObjects.Movies;

public interface IMoviesInterface
{
    public Task<List<Movie>?> GetAllMoviesAsync();
    public Task<Movie> GetMovieByTitle();
}