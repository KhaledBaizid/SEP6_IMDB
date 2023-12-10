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
    //public int userId { get; set; }

    public MovieDetails? MovieDetails { get; set; } = new MovieDetails(); // Property to store the selected movie
    public Favourite _Favourite { get; set; } = new Favourite();
  
    public bool ShowErrorMessage { get; set; }
    public string ErrorMessage { get; set; }
    public int userIdFromCache { get; set; }
    
    public string addComment { get; set; }
    
    public List<UserComment?> _ListOfComments { get; set; } = new();
    [Inject] protected ICommentService _ICommentService { get; set; }
    [Inject] public IMovieService _MovieService { get; set; }
    [Inject] protected IAuthManager authManager { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] protected IJSRuntime JSRuntime { get; set; }
    

    [Inject] protected IFavouriteService IFavouriteService { get; set; }

    [Inject] protected SweetAlertService MySweetAlertService { get; set; }

    public List<Director> PersonsDirectors{ get; set; } =  new List<Director>();

    protected async override Task OnInitializedAsync()
    {
       // userId = await authManager.GetUserId();
        userIdFromCache = await authManager.GetUserIdFromCache();
        
        int theuserIdFromCache = userIdFromCache;
        // If Id is null, then it gets assigned the value "1".
        Id = Id ?? "1";

        // Get all movies
        displayMovies = await _MovieService.GetAllMovies();

        // Find the selected movie by ID
        SelectedMovie = displayMovies.FirstOrDefault(m => m.Id.ToString() == Id);

      

        int MovieId = Convert.ToInt32(Id);
 
        long MovieIdTypeLong = Convert.ToInt64(Id);
        _ListOfComments = await _ICommentService.GetCommentsByMovieId(MovieIdTypeLong);

        try
        {
            MovieDetails = await _MovieService.GetMovieDetails(MovieId);
            
          //  PersonsDirectors = SelectedMovie.Directors.FindAll(director => director.MovieId == SelectedMovie.Id);
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
            userIdFromCache = await authManager.GetUserIdFromCache();
            if (userIdFromCache == 0)
            {
                ShowAlert();
                
            }
             
        }
    }

    public async Task ShowSuccessMessage(string text)
    {
        var result = await MySweetAlertService.FireAsync(new SweetAlertOptions
        {
            Title = "Success",
            Text = text,
            Icon = SweetAlertIcon.Success,
            ConfirmButtonText = "OK"
        });

        // You can add additional logic here based on user interaction if needed
    }

    public async Task AddToMyList()
    {
        long MovieId = (long)SelectedMovie.Id;

        if (userIdFromCache == 0)
        {
            ShowAlert();
        }
        try
        {
            await IFavouriteService.AddFavouriteMovieAsync(userIdFromCache, MovieId);
            string test = "You have successfully added an item!";
            ShowSuccessMessage(test);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    public async Task GoToMyList()
    {
        if (userIdFromCache == 0)
        {
            await ShowAlert();
            
        }
        else
        {
            await IFavouriteService.GetListOfFavouriteMovies(userIdFromCache);
            NavigationManager.NavigateTo("/movies/favourite");
        }
       
     
    }
    public async Task AddComment()
    {
        long MovieIdTypeLong = Convert.ToInt64(Id);
        _ICommentService.AddCommentToMovie(userIdFromCache,MovieIdTypeLong, addComment);
        string test = "Thanks for Your Comment";
        ShowSuccessMessage(test);
        await OnInitializedAsync();
        _ListOfComments = await _ICommentService.GetCommentsByMovieId(MovieIdTypeLong);
        addComment = "";

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