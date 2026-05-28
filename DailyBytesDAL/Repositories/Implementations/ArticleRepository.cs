using DailyBytesDAL.Models;
using DailyBytesDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ArticleRepository : IArticleRepository
{
    private readonly DailyBytesDbContext _context;
    public ArticleRepository(DailyBytesDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Article>> GetAllAsync()
    {
        try
        {
            return await _context.Articles
                .Include(a => a.Category)
                .ToListAsync();
        }
        catch
        {
            return new List<Article>();
        }
    }

    public async Task<Article> GetByIdAsync(int id)
    {
        try
        {
            return await _context.Articles
                .Include(a => a.Category)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        catch
        {
            return null;
        }
    }
}