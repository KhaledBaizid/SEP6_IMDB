using System.Net.Http.Json;
using Shared;

namespace FrontendBlazorWebAssembly.Services;

public class FavouriteService : IFavouriteService
{
    
    private readonly HttpClient _httpClient;
    


    public FavouriteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task AddFavouriteMovieAsync(int userid, long movieid)
    {
        var response = await _httpClient.PostAsJsonAsync(
            $"/Favourite?userid={userid}&movieid={movieid}",
            new { } // Add your serialized object here
        );
        
        response.EnsureSuccessStatusCode(); 
       
    }

    public async Task<List<Favourite>> GetListOfFavouriteMovies(long id)
    {
        var moviesByTitle = await _httpClient.GetFromJsonAsync<List<Favourite>>($"/Favourite?id={id}");
        return moviesByTitle;
    }

    public Task DeleteFavouriteMovieAsync(int userid, long movieid)
    {
        throw new NotImplementedException();
    }
}