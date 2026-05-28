using DailyBytesDAL.Models;

public interface IUserRepository
{
    Task<User> GetByEmailAsync(string email);
    Task<bool> CheckEmailExistsAsync(string email);
    Task<bool> RegisterAsync(User user);
    Task<User> ValidateUserAsync(string email, string password);
}