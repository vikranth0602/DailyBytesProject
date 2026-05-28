using DailyBytesDAL.Models;

public interface IArticleRepository
{
    Task<IEnumerable<Article>> GetAllAsync();

    Task<Article> GetByIdAsync(int id);
}