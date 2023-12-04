using FrontendBlazorWebAssembly.Services;
using Microsoft.AspNetCore.Components;
using Shared;

namespace FrontendBlazorWebAssembly.Pages;

public class MoviesBase : ComponentBase
{
    public List<Movie> displayMovies { get; set; } = new();
     

    [Inject] public IMovieService _MovieService { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        displayMovies = await _MovieService.GetAllMoviesByTitle("solo");
    }
}