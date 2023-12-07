using FrontendBlazorWebAssembly.Model;
using Shared;

namespace FrontendBlazorWebAssembly.Services;

public interface IFavouriteService
{
    public Task AddFavouriteMovieAsync(int userid, long movieid);
    public Task<List<Favourite>> GetListOfFavouriteMovies(long id);

    public  Task<List<MovieIMG?>> GetAllMovieDetailsById(long? Id);
    public Task DeleteFavouriteMovieAsync(int userid, long movieid);
}