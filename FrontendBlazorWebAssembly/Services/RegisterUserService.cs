using Shared;
using System.Net.Http.Json;

namespace FrontendBlazorWebAssembly.Services
{

    public class RegisterUserService : IRegisterUserService
    {


        private readonly HttpClient httpClient;

        public RegisterUserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<User> RegisterUser(User user)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/registerUser", user);

            if (response.IsSuccessStatusCode)
            {
                // Read and return the User from the response
                return await response.Content.ReadFromJsonAsync<User>();
            }
            else
            {
                // Handle the error or return null, depending on your requirements
                return null;
            }
        }
    }
}
