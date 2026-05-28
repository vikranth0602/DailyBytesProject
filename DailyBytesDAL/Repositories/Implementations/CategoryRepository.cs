using DailyBytesDAL.Models;
using DailyBytesDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class CategoryRepository : ICategoryRepository
{
    private readonly DailyBytesDbContext _context;

    public CategoryRepository(DailyBytesDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        try
        {
            return await _context.Categories.ToListAsync();
        }
        catch
        {
            return new List<Category>();
        }
    }
}