using Shared;
namespace Backend.DataAccessObjects.User;

public interface IUserInterface
{
    
    public Task<long> CreateUserAccountAsync(Shared.User user);
    public Task <long> GetLoginUserIdAsync(string mail, string password);
}