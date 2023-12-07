using Shared;
namespace Backend.DataAccessObjects.User;

public interface IUserInterface
{
    
    public Task<Shared.User> CreateUserAccountAsync(Shared.User user);
    public Task <Shared.User> GetLoginUserIdAsync(string mail, string password);
    public Task<Int64> GetUserIdByUsername(string username);
}