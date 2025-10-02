using GiftOfTheGivers.Models;
using GiftOfTheGivers.Data;
using Microsoft.EntityFrameworkCore;

namespace GiftOfTheGivers.Services
{
    public interface IAuthService
    {
        Task<User> RegisterUser(User user, string password);
        Task<User> AuthenticateUser(string email, string password);
        bool VerifyPassword(string password, string passwordHash);
    }

    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterUser(User user, string password)
        {
            // Check if user already exists
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                throw new Exception("User with this email already exists.");
            }

            // Hash password
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> AuthenticateUser(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user != null && VerifyPassword(password, user.PasswordHash))
            {
                return user;
            }

            return null;
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}