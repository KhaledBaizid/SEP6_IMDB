using CurrieTechnologies.Razor.SweetAlert2;
using FrontendBlazorWebAssembly.Authentication;
using FrontendBlazorWebAssembly.Model;
using FrontendBlazorWebAssembly.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shared;

namespace FrontendBlazorWebAssembly.Pages;

public class DetailsBase : ComponentBase
{
    [Parameter] public string Id { get; set; }
    public List<Movie?> displayMovies { get; set; } = new();
    public Movie? SelectedMovie { get; set; } = new Movie(); // Property to store the selected movie
    public int userId { get; set; }
    public MovieDetails? MovieDetails { get; set; } = new MovieDetails(); // Property to store the selected movie
    public Favourite _Favourite { get; set; } = new Favourite();
  
    public bool ShowErrorMessage { get; set; }
    public string ErrorMessage { get; set; }

    [Inject] public IMovieService _MovieService { get; set; }
    [Inject] protected IAuthManager authManager { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] protected IJSRuntime JSRuntime { get; set; }
    

    [Inject] protected IFavouriteService IFavouriteService { get; set; }

    [Inject] protected SweetAlertService MySweetAlertService { get; set; }

    protected async override Task OnInitializedAsync()
    {
        userId = await authManager.GetUserId();
        // If Id is null, then it gets assigned the value "1".
        Id = Id ?? "1";

        // Get all movies
        displayMovies = await _MovieService.GetAllMovies();

        // Find the selected movie by ID
        SelectedMovie = displayMovies.FirstOrDefault(m => m.Id.ToString() == Id);

        int MovieId = Convert.ToInt32(Id);

        try
        {
            MovieDetails = await _MovieService.GetMovieDetails(MovieId);
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            ShowErrorMessage = true;
            ErrorMessage = "An error occurred while fetching movie details.";
            Console.WriteLine($"Exception: {ex}");
        }

        if (SelectedMovie == null)
        {
            // Handle the case where the movie with the specified ID is not found
            // Set flag and message to display on the current page
            ShowErrorMessage = true;
            ErrorMessage = "Movie not found";
        }

        if (MovieDetails == null)
        {
            // Handle the case where the movie with the specified ID is not found
            // Set flag and message to display on the current page
            ShowErrorMessage = true;
            ErrorMessage = "Movie not found";
        }
    }


    public async Task ShowAlert()
    {
        //  var result = await JSRuntime.InvokeAsync<bool>("confirm", "You are not logged in to see the details! If you want to login click OK?");

        // OR use SweetAlertService
        var result = await MySweetAlertService.FireAsync(new SweetAlertOptions
        {
            Title = "You are not logged in",
            Text = "do u have an account ?",
            Icon = SweetAlertIcon.Warning,
            ShowCancelButton = true,
            ConfirmButtonText = "yes",
            CancelButtonText = "No"
        });

        if (result.IsConfirmed)
        {
            // User clicked "Yes"
            // Navigate to another URL
            NavigationManager.NavigateTo("/Login");
        }
        else
        {
            // User clicked "No" or closed the dialog
            // Handle accordingly or do nothing
        }
    }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            if (userId == 0)
            {
                ShowAlert();
            }
        }
    }

    public async Task ShowSuccessMessage()
    {
        var result = await MySweetAlertService.FireAsync(new SweetAlertOptions
        {
            Title = "Success",
            Text = "You have successfully added an item!",
            Icon = SweetAlertIcon.Success,
            ConfirmButtonText = "OK"
        });

        // You can add additional logic here based on user interaction if needed
    }

    public async Task AddToMyList()
    {
        long MovieId = (long)SelectedMovie.Id;

        if (userId == 0)
        {
            ShowAlert();
        }
        try
        {
            await IFavouriteService.AddFavouriteMovieAsync(userId, MovieId);
            ShowSuccessMessage();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    public async Task GoToMyList()
    {
        if (userId == 0)
        {
            await ShowAlert();
        }
       
        await IFavouriteService.GetListOfFavouriteMovies(userId);
        NavigationManager.NavigateTo("/favourite");
    }

    /*
     private async Task ShowAlertLogin()
     {
         var result = await JSRuntime2.InvokeAsync<bool>("confirm", "You are not logged in to see the details! If you want to login click OK?");
         
         if (result)
         {
             // Navigate to another URL
             NavigationManager.NavigateTo("/Login");
         }
         else
         {
             // User clicked "Cancel" - Do something else or just return
             // For example, you can display another message or perform another action
             Console.WriteLine("User clicked Cancel");
         }
     }
   */
}