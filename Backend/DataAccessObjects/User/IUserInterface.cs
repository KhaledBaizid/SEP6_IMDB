using Shared;
namespace Backend.DataAccessObjects.User;

public interface IUserInterface
{
    
    public Task<long> CreateUserAccountAsync(Shared.User user);
}