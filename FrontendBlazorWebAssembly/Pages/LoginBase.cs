using FrontendBlazorWebAssembly.Authentication;
using Microsoft.AspNetCore.Components;
using Shared;

namespace FrontendBlazorWebAssembly.Pages
{
	public class LoginBase : ComponentBase
	{
		public User? user { get; set; } = new User();


		public string errorMessage;

		[Inject] protected IAuthManager authManager { get; set; }
		[Inject] public NavigationManager NavigationManager { get; set; }




		public async Task LoginUserHandler()
		{
			try
			{
				if (user != null)
				{
					// Call the IAuthManager service with the user object
					await authManager.LoginAsync(user);

					NavigationManager.NavigateTo("/");
				}
				else
				{
					errorMessage = "Please make sure your mail and password are correct.";
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
