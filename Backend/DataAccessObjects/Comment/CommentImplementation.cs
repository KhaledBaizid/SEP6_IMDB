using Backend.EFCData;
using Microsoft.EntityFrameworkCore;
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

    public async  Task<List<UserComment>> GetCommentsByMovieId(long movieid)
    {
        var usercomments = new  List<UserComment>();
        List<Movie> movies = new List<Movie>();
        try
        {
           
            movies = await _systemContext.Movies?.Where(d=>d.Id != null && d.Id==movieid)
                .Include(u=>u.UserComments)!.ThenInclude(uc=>uc.User)
                .ToListAsync()!;
            foreach (var movie in  movies)
            {
                if (movie.UserComments != null)
                    foreach (var userComment in movie.UserComments)
                    {
                       
                        if (userComment.User != null) userComment.User.Password = null;
                        if (userComment.User != null) userComment.User.Mail = null;
                        Console.WriteLine(userComment.Comment);
                        usercomments.Add(userComment);
                    }
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
        return usercomments;
    }
}