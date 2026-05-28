using DailyBytesDAL.Models;

namespace DailyBytesDAL.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        Task AddOrUpdateRatingAsync(
            Rating rating
        );

        Task<double> GetAverageRatingAsync(
            int articleId
        );

        Task<Rating?> GetUserRatingAsync(
            int userId,
            int articleId
        );
    }
}