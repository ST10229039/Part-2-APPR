using Microsoft.AspNetCore.Mvc;
using GiftOfTheGivers.Models;
using GiftOfTheGivers.Services;
using GiftOfTheGivers.Data;

namespace GiftOfTheGivers.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly AppDbContext _context;

        public AccountController(IAuthService authService, AppDbContext context)
        {
            _authService = authService;
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
        public async Task<IActionResult> Register(User user, string password)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newUser = await _authService.RegisterUser(user, password);

                    // Set user session
                    HttpContext.Session.SetInt32("UserID", newUser.UserID);
                    HttpContext.Session.SetString("UserName", newUser.Name);
                    HttpContext.Session.SetString("UserRole", newUser.Role);
                    HttpContext.Session.SetString("UserEmail", newUser.Email);

                    TempData["SuccessMessage"] = "Registration successful! Welcome to Gift Of The Givers.";
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(user);
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Please enter both email and password.");
                return View();
            }

            var user = await _authService.AuthenticateUser(email, password);
            if (user != null)
            {
                // Set user session
                HttpContext.Session.SetInt32("UserID", user.UserID);
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetString("UserRole", user.Role);
                HttpContext.Session.SetString("UserEmail", user.Email);

                TempData["SuccessMessage"] = $"Welcome back, {user.Name}!";
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid email or password.");
            return View();
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["SuccessMessage"] = "You have been logged out successfully.";
            return RedirectToAction("Index", "Home");
        }

        // In your AccountController, add this action:

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