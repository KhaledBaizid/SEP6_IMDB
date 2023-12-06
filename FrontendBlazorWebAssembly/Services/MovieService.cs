using System.Net;
using System.Net.Http.Json;
using FrontendBlazorWebAssembly.Model;
using Newtonsoft.Json;
using Shared;

namespace FrontendBlazorWebAssembly.Services;

public class MovieService : IMovieService
{
    private readonly HttpClient _httpClient;

    //const string _baseUrl = "https://localhost:7254";
    // public MoviesService(HttpClient httpClient) => _httpClient = httpClient;
    private readonly string apiKey = "ea418978922172b44d557675397841d3";


    public MovieService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Movie>> GetAllMoviesByTitle(string title)
    {
        var moviesByTitle = await _httpClient.GetFromJsonAsync<List<Movie>>($"/Movie/title/{title}");
        return moviesByTitle;
    }

    public async Task<List<Movie>> GetAllMovies()
    {
        var allMovies = await _httpClient.GetFromJsonAsync<List<Movie>>("/Movie");
        return allMovies;
    }

    public async Task<MovieDetails> GetMovieDetails(int Id)
    {
        var response = await _httpClient.GetAsync($"https://api.themoviedb.org/3/movie/tt{Id}?api_key={apiKey}");
        response.EnsureSuccessStatusCode();

        var movieDetails = await response.Content.ReadFromJsonAsync<MovieDetails>();
        return movieDetails;
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
                    string posterUrl = $"{baseImageUrl}w342/{movieDetails.poster_path}";
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


    public async Task<List<MovieDetails?>> GetAllMovieDetails()
    {
        var response =
            await _httpClient.GetFromJsonAsync<List<MovieDetails?>>(
                $"https://api.themoviedb.org/3/movie/?api_key={apiKey}&language=en-US&page=1");

        return response;
    }
}