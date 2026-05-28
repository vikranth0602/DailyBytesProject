using DailyBytesDAL.Models;
using DailyBytesDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DailyBytesDAL.Repositories.Implementations
{
    public class RatingRepository : IRatingRepository
    {
        private readonly DailyBytesDbContext _context;

        public RatingRepository(DailyBytesDbContext context)
        {
            _context = context;
        }

        public async Task AddOrUpdateRatingAsync(Rating rating)
        {
            var existingRating = await _context.Ratings
                .FirstOrDefaultAsync(r =>
                    r.UserId == rating.UserId &&
                    r.ArticleId == rating.ArticleId);

            if (existingRating != null)
            {
                existingRating.RatingValue = rating.RatingValue;
            }
            else
            {
                await _context.Ratings.AddAsync(rating);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<double> GetAverageRatingAsync(int articleId)
        {
            var ratings = await _context.Ratings
                .Where(r => r.ArticleId == articleId)
                .ToListAsync();

            if (!ratings.Any())
            {
                return 0;
            }

            return ratings.Average(r => r.RatingValue);
        }

        public async Task<Rating?> GetUserRatingAsync( int userId, int articleId )
        {
            return await _context.Ratings
                .FirstOrDefaultAsync(r =>
                    r.UserId == userId &&
                    r.ArticleId == articleId
                );
        }

    }
}