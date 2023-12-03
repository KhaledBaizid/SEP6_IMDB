using Shared;

namespace FrontendBlazorWebAssembly.Services
{
	public class LoginService : ILoginService
	{
		private readonly HttpClient httpClient;

		public LoginService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}
		public async Task<User?> Login(User user)
		{
			/*
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/loginUser", user);

            if (response.IsSuccessStatusCode)
            {
                // Read and return the User from the response
                return await response.Content.ReadFromJsonAsync<User>();
            }
            else
            {
                // Handle the error or return null, depending on your requirements
                return null;
            }*/
			User? find = users.Find(user => user.Username.Equals(user.Username));
			return await Task.FromResult(find);
		}

		private List<User> users = new(){
			new User { Username = "aaaa", Password = "1234" },
			new User { Username = "Maria", Password = "oneTwo3FOUR"},
			new User { Username = "Anne", Password = "password"}
		  };


	}
}
