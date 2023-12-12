using System.Security.Claims;
using CurrieTechnologies.Razor.SweetAlert2;
using FrontendBlazorWebAssembly.Authentication;
using FrontendBlazorWebAssembly.Model;
using FrontendBlazorWebAssembly.Services;
using Microsoft.AspNetCore.Components;
using Shared;

namespace FrontendBlazorWebAssembly.Pages;

public class FavouriteBase : ComponentBase
{
    public List<Favourite> displayFavouriteMovies { get; set; } = new();
    public List<Favourite> displayFavouriteMovies1 { get; set; } = new();
    public List<Movie> ListOfMoviesByTitle { get; set; } = new();
    public List<MovieIMG> MoviesFromApiTMDB { get; set; } = new();
    public int userId { get; set; }
    [Inject] public IMovieService _MovieService { get; set; }
    [Inject] protected IFavouriteService IFavouriteService { get; set; }
    [Inject] protected IAuthManager authManager { get; set; }
    [Inject] protected SweetAlertService MySweetAlertService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    public int userIdFromCache { get; set; }
    public string title { get; set; }
    public Movie? SelectedMovie { get; set; } = new Movie(); // Property to store the selected movie

    /*
    protected override async Task OnInitializedAsync()
    {
        userId = await authManager.GetUserId();

        long theUserID = userId;

        if (!string.IsNullOrWhiteSpace(title))
        {
            ListOfMoviesByTitle = await _MovieService.GetAllMoviesByTitle(title);
        }
        else
        {
            displayFavouriteMovies1 = await IFavouriteService.GetListOfFavouriteMovies(theUserID);


            var tasks = displayFavouriteMovies1.Select(async movies =>
            {
                //  int MovieId = Convert.ToInt32(movies.Id);
                var details = await IFavouriteService.GetAllMovieDetailsById(movies.Movie.Id);
                MoviesFromApiTMDB.AddRange(details);
            });

            await Task.WhenAll(tasks);
        }

        displayFavouriteMovies = displayFavouriteMovies1;
    }
    */
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
          //  userId = await authManager.GetUserId();

            long theUserID = userId; //this is problem because when u refresh your browser you variable will be set to null so u canot get the GetListOfFavouriteMovies by null.
                                     //you have to save the user id in cashes and get it from there.
                                     //again problem because when u refresh your browser you variable will be set to null
                                     
            userIdFromCache = await authManager.GetUserIdFromCache();
            
            int theuserIdFromCache = userIdFromCache;
            
            if (!string.IsNullOrWhiteSpace(title))
            {
                ListOfMoviesByTitle = await _MovieService.GetAllMoviesByTitle(title);
            }
            else
            {
                displayFavouriteMovies1 = await IFavouriteService.GetListOfFavouriteMovies(theuserIdFromCache);

                var tasks = displayFavouriteMovies1.Select(async movies =>
                {
                    try
                    {
                        var details = await IFavouriteService.GetAllMovieDetailsById(movies.Movie.Id);
                        MoviesFromApiTMDB.AddRange(details);
                    }
                    catch (Exception ex)
                    {
                        // Handle details retrieval error for a specific movie
                        Console.WriteLine($"Error fetching details for movie {movies.Movie.Id}: {ex.Message}");
                    }
                });

                await Task.WhenAll(tasks);
            }

            displayFavouriteMovies = displayFavouriteMovies1;
        }
        catch (Exception ex)
        {
            // Handle any other initialization error
            Console.WriteLine($"Initialization error: {ex.Message}");
        }
    }

    public string getimage(long? id)
    {
        Console.WriteLine(id);
        string movieid = "tt" + id;
        var movieDetails = MoviesFromApiTMDB.Find(e => e.id == movieid);
        if (movieDetails != null)
        {
            var url = movieDetails.poster_path;
            return url;
        }

        //  var t = await "https://image.tmdb.org/t/p/w342//v4QfYZMACODlWul9doN9RxE99ag.jpg".ToString();
        return null;
    }

    
    public async Task ShowAlert()
    {
        //  var result = await JSRuntime.InvokeAsync<bool>("confirm", "You are not logged in to see the details! If you want to login click OK?");

        // OR use SweetAlertService
        var result = await MySweetAlertService.FireAsync(new SweetAlertOptions
        {
            Title = "You are not logged in",
            Text = "do you have an account ?",
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
        if (firstRender)
        {
            // Retrieve the current authentication state
            ClaimsPrincipal principal = await authManager.GetAuthAsync();

            // Invoke the OnAuthStateChanged delegate with the current authentication state
            authManager.OnAuthStateChanged?.Invoke(principal);
        }
    }

    public async Task SearchOnInput(ChangeEventArgs e)
    {
        long theUserID = userIdFromCache;
        // Update the title property with the input value
        title = e.Value.ToString();
        if (string.IsNullOrWhiteSpace(title))
        {
            displayFavouriteMovies = await IFavouriteService.GetListOfFavouriteMovies(theUserID);
        }

        // If title is not empty, filter favorite movies based on the input title
        displayFavouriteMovies = displayFavouriteMovies.FindAll(favorite => title != null && (favorite.Movie.Title?.Contains(title, StringComparison.OrdinalIgnoreCase) ?? false))
            .ToList();
    }
    
    public async Task ShowSuccessMessage()
    {
        var result = await MySweetAlertService.FireAsync(new SweetAlertOptions
        {
            Title = "Success",
            Text = "You have successfully deleted an item!",
            Icon = SweetAlertIcon.Success,
            ConfirmButtonText = "OK"
        });

        // You can add additional logic here based on user interaction if needed
    }
    public async Task Delete(long movieId)
    {
        int theUserID = userIdFromCache;
        
        
        try
        {
            await IFavouriteService.DeleteFavouriteMovieAsync(theUserID, movieId);
            ShowSuccessMessage();
            displayFavouriteMovies = await IFavouriteService.GetListOfFavouriteMovies(theUserID);
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        
       
        
        
    }
}