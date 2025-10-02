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
        private readonly ILogger<AuthService> _logger;

        public AuthService(AppDbContext context, ILogger<AuthService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<User> RegisterUser(User user, string password)
        {
            try
            {
                _logger.LogInformation("Starting user registration for: {Email}", user.Email);

                // Check if user already exists
                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email.ToLower() == user.Email.ToLower());

                if (existingUser != null)
                {
                    throw new Exception("User with this email already exists.");
                }

                // Set default values
                user.Role = string.IsNullOrEmpty(user.Role) ? "User" : user.Role;
                user.DateCreated = DateTime.Now;

                // Hash password
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
                _logger.LogInformation("Password hashed successfully for: {Email}", user.Email);

                // Add user to database
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                _logger.LogInformation("User saved to database with ID: {UserId}", user.UserID);

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering user: {Email}", user.Email);
                throw;
            }
        }

        public async Task<User> AuthenticateUser(string email, string password)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

                if (user != null && VerifyPassword(password, user.PasswordHash))
                {
                    _logger.LogInformation("User authenticated successfully: {Email}", email);
                    return user;
                }

                _logger.LogWarning("Authentication failed for: {Email}", email);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error authenticating user: {Email}", email);
                throw;
            }
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, passwordHash);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error verifying password");
                return false;
            }
        }
    }
}