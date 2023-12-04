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
           
            // Use PostAsJsonAsync for sending a POST request with the user object in the request body
            var response = await httpClient.PostAsJsonAsync($"/User", user);
           
            // Check if the request was successful (status code 200 OK)
            if (response.IsSuccessStatusCode)
            {
                var registeredUser = await response.Content.ReadFromJsonAsync<User>();
               
               

            
                if (registeredUser.Id == -1)
                {
                   
                    throw new Exception("Email is already in use.");
                }
                else if (registeredUser.Id == -2)
                {
                   
                    throw new Exception("Username is already in use.");
                }
                else if (registeredUser.Id > 0)
                {
                    // Registration successful, return the registered user
                    return registeredUser;
                }
                else
                {
              
                    throw new Exception($"Unexpected response from the server.");
                }
            }
            else
            {
            
                throw new Exception($"Failed to register user. Status code: {response.StatusCode}");
            }
        }
        /*
        public async Task<User> RegisterUser(User user)
        {
            
            var Response = await httpClient.GetFromJsonAsync<User>($"/User", {user});
            return Response;
              
            
            
            HttpResponseMessage response = await httpClient.PostAsJsonAsync($"/User", user);

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
        */
  
    }
}
