using Backend.EFCData;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Backend.DataAccessObjects.User;

public class UserImplementation : IUserInterface
{
    private readonly DataContext _systemContext;

    public UserImplementation(DataContext systemContext)
    {
        _systemContext = systemContext;
    }

    public async Task<long> CreateUserAccountAsync(Shared.User user)
    {
        try
        {
           
                var user1 = await _systemContext.Users.FirstOrDefaultAsync(e=>e.Mail==user.Mail);
                if (user1 is null)
                {  await _systemContext.Users.AddAsync(user);
                    await _systemContext.SaveChangesAsync();
                    var userFound = await _systemContext.Users.FirstAsync(u => u.Mail == user.Mail);
                    var id=(long)userFound.Id;
                    return id;
                }
                return 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
        
    }
}