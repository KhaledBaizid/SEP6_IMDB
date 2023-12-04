using FrontendBlazorWebAssembly.Services;
using Microsoft.AspNetCore.Components;
using Shared;

namespace FrontendBlazorWebAssembly.Pages
{
    public class RegistrationPageBase : ComponentBase
    {
        [Inject] public IRegisterUserService RegisterService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        public User user { get; set; } = new User();

        public string confirmPassword;

        public string errorMessage;

  



        public async Task RegisterUserHandler()
        {
            try
            {

                if (user.Password.Equals(confirmPassword))
                {
                    
                    // Call the RegisterUser service with the user object
                    var registeredUser = await RegisterService.RegisterUser(user);

                    
                    if (registeredUser != null)
                    {
                        // Registration successful, navigate to another URL
                        NavigationManager.NavigateTo("/login"); // Change "/successPage" to the desired URL
                    }
                    else
                    {
                        // Registration failed
                        errorMessage = "Registration failed. Please try again."; // Set your error message
                    }
                    
                    
                }
                
            }
            catch (Exception ex)
            {
                // Handle other exceptions if needed
                errorMessage = $"An error occurred: {ex.Message}";
            }
        }
    }
}
