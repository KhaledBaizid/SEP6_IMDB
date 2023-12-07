using Shared;

namespace Backend.DataAccessObjects.Comment;

public interface ICommentInterface
{
    public Task AddCommentToMovie(int userid, long movieid, string comment);
}