
using Microsoft.AspNetCore.Mvc;

namespace Backend.DataAccessObjects.Favourite;

public interface IFavouriteInterface
{
    public Task AddFavouriteMovieAsync(int userid, long movieid);
    public Task<List<Shared.Favourite>> GetListOfFavouriteMovies(long id);

}