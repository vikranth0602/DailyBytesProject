using DailyBytesDAL.Models;
using DailyBytesDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net; // Requires BCrypt.Net-Next package

namespace DailyBytesDAL.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DailyBytesDbContext _context;

        public UserRepository(DailyBytesDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> RegisterAsync(User user)
        {
            // Hash the password before saving to the database [1]
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> ValidateUserAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            // Use BCrypt to verify the plain-text password against the stored hash [1, 2]
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }

            return user;
        }
    }
}