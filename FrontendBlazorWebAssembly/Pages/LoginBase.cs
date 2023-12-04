using FrontendBlazorWebAssembly.Authentication;
using Microsoft.AspNetCore.Components;
using Shared;

namespace FrontendBlazorWebAssembly.Pages
{
	public class LoginBase : ComponentBase
	{
		public User? User { get; set; } = new User();


		public string errorMessage;

		[Inject] protected IAuthManager authManager { get; set; }
		[Inject] public NavigationManager NavigationManager { get; set; }




		public async Task LoginUserHandler()
		{
			try
			{

				// Call the IAuthManager service with the user object
				await authManager.LoginAsync(User);
				
				NavigationManager.NavigateTo("/movies");

				/*
                string msg = authManager.msgToUser();




                if (msg.Equals("PasswordCorrect"))
                {
                    // Registration successful, navigate to another URL
                    NavigationManager.NavigateTo("/login"); // Change "/successPage" to the desireds URL
                }
                else
                {
                    // Registration failed
                    errorMessage = "Registration failed. Please try again."; // Set your error message
                }
                */
				/*
                if (registeredUser != null)
                {
                    // Registration successful, navigate to another URL
                    NavigationManager.NavigateTo("/login"); // Change "/successPage" to the desireds URL
                }
                else
                {
                    // Registration failed
                    errorMessage = "Registration failed. Please try again."; // Set your error message
                }*/
			}
			catch (Exception ex)
			{
				// Handle other exceptions if needed
				errorMessage = $"An error occurred: {ex.Message}";
			}
		}
	}
}
