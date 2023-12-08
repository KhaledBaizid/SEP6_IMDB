using Shared;

namespace FrontendBlazorWebAssembly.Services;

public interface ICommentService
{
    public Task AddCommentToMovie(int userid, long movieid, string comment);
    public Task<List<UserComment>> GetCommentsByMovieId(long movieid);
}