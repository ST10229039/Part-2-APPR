using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftOfTheGivers.Models;
using GiftOfTheGivers.Data;

namespace GiftOfTheGivers.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Console.WriteLine($"Registration attempt for: {model.Email}");

                    // Check if email already exists
                    var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                    if (existingUser != null)
                    {
                        ModelState.AddModelError("Email", "This email address is already registered.");
                        return View(model);
                    }

                    // Check terms agreement
                    if (!model.AgreeToTerms)
                    {
                        ModelState.AddModelError("AgreeToTerms", "You must agree to the terms and conditions.");
                        return View(model);
                    }

                    // Create new user from ViewModel
                    var newUser = new User
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Phone = model.Phone,
                        Address = model.Address,
                        Role = "User", // Default role
                        DateCreated = DateTime.Now,
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password) // Hash the password
                    };

                    // Add to database
                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync();

                    Console.WriteLine($"User registered successfully: {newUser.UserID} - {newUser.Email}");

                    // Set session
                    HttpContext.Session.SetInt32("UserID", newUser.UserID);
                    HttpContext.Session.SetString("UserName", newUser.Name);
                    HttpContext.Session.SetString("UserRole", newUser.Role);
                    HttpContext.Session.SetString("UserEmail", newUser.Email);

                    TempData["SuccessMessage"] = "Registration successful! Welcome to Gift Of The Givers.";
                    return RedirectToAction("Index", "Home");
                }

                // If ModelState is invalid, return to form with errors
                Console.WriteLine("ModelState invalid - returning to form");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation error: {error.ErrorMessage}");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during registration: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                ModelState.AddModelError("", "An error occurred during registration. Please try again.");
                return View(model);
            }
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                    if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                    {
                        // Set session
                        HttpContext.Session.SetInt32("UserID", user.UserID);
                        HttpContext.Session.SetString("UserName", user.Name);
                        HttpContext.Session.SetString("UserRole", user.Role);
                        HttpContext.Session.SetString("UserEmail", user.Email);

                        TempData["SuccessMessage"] = $"Welcome back, {user.Name}!";
                        return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError("", "Invalid email or password.");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during login: {ex.Message}");
                ModelState.AddModelError("", "An error occurred during login. Please try again.");
                return View(model);
            }
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["SuccessMessage"] = "You have been logged out successfully.";
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Profile
        public async Task<IActionResult> Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                TempData["ErrorMessage"] = "Please log in to view your profile.";
                return RedirectToAction("Login");
            }

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction("Login");
            }

            return View(user);
        }
    }
}