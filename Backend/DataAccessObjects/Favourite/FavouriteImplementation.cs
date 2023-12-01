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

    public async Task AddFavouriteMovieAsync(Shared.Favourite favourite)
    {
        
        try
        {
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
}