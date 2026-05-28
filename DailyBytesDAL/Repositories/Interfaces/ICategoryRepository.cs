using DailyBytesDAL.Models;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
}