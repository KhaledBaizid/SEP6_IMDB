using System.Net.Http.Json;
using FrontendBlazorWebAssembly.Model;
using Newtonsoft.Json;
using Shared;

namespace FrontendBlazorWebAssembly.Services;

public class FavouriteService : IFavouriteService
{
    
    private readonly HttpClient _httpClient;
    
    private readonly string apiKey = "ea418978922172b44d557675397841d3";

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

    public async Task<List<MovieIMG?>> GetAllMovieDetailsById(long? Id)
    {
        // Use the injected _httpClient instead of creating a new one
        try
        {
            string movieId = "tt" + Id;
            string apiUrl = $"https://api.themoviedb.org/3/movie/{movieId}?api_key={apiKey}";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                MovieIMG movieDetails = JsonConvert.DeserializeObject<MovieIMG>(json);

                if (movieDetails.poster_path != null)
                {
                    string baseImageUrl = "https://image.tmdb.org/t/p/";
                    string posterUrl = $"{baseImageUrl}w185/{movieDetails.poster_path}";
                    movieDetails.poster_path = posterUrl;
                    movieDetails.id = movieId;
                    Console.WriteLine("Poster URL: " + posterUrl);
                    var m = new MovieIMG { id = movieId, poster_path = posterUrl };

                    // You might want to return a list since the method signature specifies List<MovieIMG>
                    return new List<MovieIMG> { m };
                }
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }

        // Return an empty list if something goes wrong
        return new List<MovieIMG>();
    }


    public async Task DeleteFavouriteMovieAsync(int userid, long movieid)
    {
        var response = await _httpClient.DeleteAsync($"/Favourite?userid={userid}&movieid={movieid}");

        response.EnsureSuccessStatusCode();
    }
}