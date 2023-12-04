using System.Net.Http.Json;
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
            string mail = user.Mail;
            string password = user.Password;


            var Response = await httpClient.GetFromJsonAsync<User>($"/User?mail={mail}&password={password}");
            return Response;
            /*
             if (httpResponse.IsSuccessStatusCode)
             {
                 // Read and return the User from the response
                 User? response = await httpResponse.Content.ReadFromJsonAsync<User>();
                 return response;
             }
             else
             {
                 // Handle the error or return null, depending on your requirements
                 return null;
             }*/
        }
    }
}