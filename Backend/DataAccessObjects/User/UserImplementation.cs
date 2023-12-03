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

    public async Task<Shared.User> CreateUserAccountAsync(Shared.User user)
    {
        try
        {
           
                var userMail = await _systemContext.Users.FirstOrDefaultAsync(e=>e.Mail==user.Mail);
                var userUsername = await _systemContext.Users.FirstOrDefaultAsync(e=>e.Username==user.Username);
                if (userMail is null)
                {
                    if (userUsername is null)
                    {
                        await _systemContext.Users.AddAsync(user);
                        await _systemContext.SaveChangesAsync();
                        var userFound = await _systemContext.Users.FirstAsync(u => u.Mail == user.Mail);
                        userFound.Password = null;
                        return userFound;
                    }

                    return new Shared.User{Id=-2,Mail = "anymail123456123@ggg.com",Username = "anyusername156446"};
                }

               // Shared.User usernotfound;
                return new Shared.User{Id=-1,Mail = "anymail123456123@ggg.com",Username = "anyusername156446"};
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
        
    }

    public async Task<Shared.User> GetLoginUserIdAsync(string mail, string password)
    {
        try
        {
            if (_systemContext.Users != null)
            {
                var findUser = await _systemContext.Users.FirstOrDefaultAsync(e=>e.Mail==mail);
                if (findUser is not null && findUser.Password==password)
                {
                    findUser.Password = null;
                    return findUser;
                }
            }

            Shared.User user1;
            return user1 =new Shared.User{Id=-1,Mail = "anymail123456123@ggg.com",Username = "anyusername156446"};
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}