using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftOfTheGivers.Models;
using GiftOfTheGivers.Data;

namespace GiftOfTheGivers.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly AppDbContext _context;

        public VolunteerController(AppDbContext context)
        {
            _context = context;
        }

        // In your VolunteerController, ensure you have these actions:

        // GET: /Volunteer/Register
        public IActionResult Register()
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                TempData["ErrorMessage"] = "Please log in to register as a volunteer.";
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        // POST: /Volunteer/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Volunteer volunteer)
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                TempData["ErrorMessage"] = "Please log in to register as a volunteer.";
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                // Check if user is already registered as volunteer
                var existingVolunteer = await _context.Volunteers
                    .FirstOrDefaultAsync(v => v.UserID == userId);

                if (existingVolunteer != null)
                {
                    TempData["ErrorMessage"] = "You are already registered as a volunteer.";
                    return RedirectToAction("Profile");
                }

                volunteer.UserID = userId.Value;
                volunteer.RegistrationDate = DateTime.Now;
                volunteer.Status = "Active";

                _context.Volunteers.Add(volunteer);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Thank you for registering as a volunteer! We will contact you with opportunities.";
                return RedirectToAction("Profile");
            }

            return View(volunteer);
        }
        // GET: /Volunteer/Profile
        public async Task<IActionResult> Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                TempData["ErrorMessage"] = "Please log in to view your volunteer profile.";
                return RedirectToAction("Login", "Account");
            }

            var volunteer = await _context.Volunteers
                .Include(v => v.User)
                .Include(v => v.AssignedIncident)
                .FirstOrDefaultAsync(v => v.UserID == userId);

            if (volunteer == null)
            {
                TempData["InfoMessage"] = "You are not registered as a volunteer yet.";
                return RedirectToAction("Register");
            }

            return View(volunteer);
        }

        // GET: /Volunteer/Opportunities
        public async Task<IActionResult> Opportunities()
        {
            var activeIncidents = await _context.DisasterIncidents
                .Where(i => i.Status == "Active" || i.Status == "Reported")
                .OrderByDescending(i => i.ReportedDate)
                .ToListAsync();

            var projects = await _context.ReliefProjects
                .Where(p => p.Status == "Active" || p.Status == "Planning")
                .ToListAsync();

            ViewBag.ActiveIncidents = activeIncidents;
            ViewBag.Projects = projects;

            return View();
        }

        // GET: /Volunteer/Manage (Admin only)
        public async Task<IActionResult> Manage()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Admin")
            {
                TempData["ErrorMessage"] = "Access denied. Admin privileges required.";
                return RedirectToAction("Index", "Home");
            }

            var volunteers = await _context.Volunteers
                .Include(v => v.User)
                .Include(v => v.AssignedIncident)
                .OrderBy(v => v.Status)
                .ThenBy(v => v.RegistrationDate)
                .ToListAsync();

            return View(volunteers);
        }
    }
}