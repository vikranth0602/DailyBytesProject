using DailyBytesDAL.Models;

namespace DailyBytesDAL.Repositories.Interfaces
{
    public interface IBookmarkRepository
    {
        Task AddAsync(Bookmark bookmark);

        Task RemoveAsync(int userId, int articleId);

        Task<IEnumerable<Bookmark>> GetUserBookmarksAsync(int userId);
        Task<bool> ExistsAsync(int userId, int articleId);
    }
}