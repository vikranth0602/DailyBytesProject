using DailyBytesDAL.Models;

using DailyBytesDAL.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace DailyBytesDAL.Repositories.Implementations
{
    public class BookmarkRepository
        : IBookmarkRepository
    {
        private readonly DailyBytesDbContext _context;

        public BookmarkRepository( DailyBytesDbContext context)
        {
            _context = context;
        }

        //AddBookmark
        #region-AddBookmark
        public async Task AddAsync(
            Bookmark bookmark)
        {
            await _context.Bookmarks
                .AddAsync(bookmark);

            await _context.SaveChangesAsync();
        }
        #endregion

        //RemoveBookmark
        #region-RemoveBookmark
        public async Task RemoveAsync(
            int userId,
            int articleId)
        {
            var bookmark =
                await _context.Bookmarks
                .FirstOrDefaultAsync(b =>
                    b.UserId == userId &&
                    b.ArticleId == articleId);

            if (bookmark != null)
            {
                _context.Bookmarks.Remove(bookmark);

                await _context.SaveChangesAsync();
            }
        }
        #endregion

        //Bookmark exists or not
        #region-BookmarkExistsorNot
        public async Task<bool> ExistsAsync(
            int userId,
            int articleId)
        {
            return await _context.Bookmarks
                .AnyAsync(b =>
                    b.UserId == userId &&
                    b.ArticleId == articleId);
        }
        #endregion

        //GetBookmark
        #region-GetBookmarks
        public async Task<IEnumerable<Bookmark>>
        GetUserBookmarksAsync(int userId)
        {
            return await _context.Bookmarks

                        .Include(b => b.Article)

                        .ThenInclude(a => a.Category)

                        .Where(b => b.UserId == userId)

                        .ToListAsync();
        }
        #endregion

    }
}