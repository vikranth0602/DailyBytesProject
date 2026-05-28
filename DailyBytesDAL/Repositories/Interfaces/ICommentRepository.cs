using DailyBytesDAL.Models;

namespace DailyBytesDAL.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(Comment comment);

        Task DeleteCommentAsync(int id);

        Task<List<Comment>> GetCommentsByArticleAsync(int articleId);


    }
}