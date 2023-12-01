
using Microsoft.AspNetCore.Mvc;

namespace Backend.DataAccessObjects.Favourite;

public interface IFavouriteInterface
{
    public Task AddFavouriteMovieAsync(Shared.Favourite favourite);

}