using DailyBytesDAL.Models;

using DailyBytesDAL.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace DailyBytesDAL.Repositories.Implementations
{
    public class CommentRepository
        : ICommentRepository
    {
        private readonly DailyBytesDbContext
            _context;

        public CommentRepository(
            DailyBytesDbContext context
        )
        {
            _context = context;
        }

        //Add Comment
        #region-AddComment
        public async Task AddCommentAsync(
            Comment comment
        )
        {
            await _context.Comments
                .AddAsync(comment);

            await _context.SaveChangesAsync();
        }
        #endregion

        //Delete Comment
        #region-DeleteComment
        public async Task DeleteCommentAsync(
            int id
        )
        {
            var comment =
                await _context.Comments
                    .FindAsync(id);

            if (comment != null)
            {
                _context.Comments.Remove(comment);

                await _context.SaveChangesAsync();
            }
        }
        #endregion

        //Get Comment
        #region-GetComment
        public async Task<List<Comment>>
        GetCommentsByArticleAsync( int articleId )
        {
            return await _context.Comments
                .Include(c => c.User)
                .Where(c =>
                    c.ArticleId == articleId
                )
                .OrderByDescending(c =>
                    c.CreatedDate
                )
                .ToListAsync();
        }
        #endregion


    }
}