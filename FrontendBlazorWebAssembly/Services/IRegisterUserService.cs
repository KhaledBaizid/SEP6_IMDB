using Shared;

namespace FrontendBlazorWebAssembly.Services
{
    public interface IRegisterUserService
    {
        Task<User> RegisterUser(User user);
    }
}
