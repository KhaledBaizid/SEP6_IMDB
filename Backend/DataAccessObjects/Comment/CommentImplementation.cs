using Backend.EFCData;
using Shared;

namespace Backend.DataAccessObjects.Comment;

public class CommentImplementation: ICommentInterface
{
    private readonly DataContext _systemContext;

    public CommentImplementation(DataContext systemContext)
    {
        _systemContext = systemContext;
    }

    public async Task AddCommentToMovie(int userid, long movieid, string comment)
    {
        try
        {
            var userComment = new UserComment
            {
                UserId = userid,
                MovieId = movieid,
                Comment = comment,
                CommentTime = DateTime.Now.ToUniversalTime()
            };
            if (_systemContext.UserComments != null) await _systemContext.UserComments.AddAsync(userComment);
            await _systemContext.SaveChangesAsync(); 
        }
        catch (Exception e)
        { 
            Console.WriteLine(e);
            throw;
        }
        
        
    }
}