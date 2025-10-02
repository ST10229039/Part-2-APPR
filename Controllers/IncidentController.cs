using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftOfTheGivers.Models;
using GiftOfTheGivers.Data;

namespace GiftOfTheGivers.Controllers
{
    public class IncidentController : Controller
    {
        private readonly AppDbContext _context;

        public IncidentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Incident/Report
        public IActionResult Report()
        {
            return View();
        }

        // POST: /Incident/Report
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Report(DisasterIncident incident)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetInt32("UserID");
                if (userId == null)
                {
                    TempData["ErrorMessage"] = "Please log in to report an incident.";
                    return RedirectToAction("Login", "Account");
                }

                incident.ReportedByUserID = userId.Value;
                incident.ReportedDate = DateTime.Now;

                _context.DisasterIncidents.Add(incident);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Incident reported successfully! Our team will review it shortly.";
                return RedirectToAction("Index");
            }

            return View(incident);
        }

        // GET: /Incident/Index
        public async Task<IActionResult> Index()
        {
            var incidents = await _context.DisasterIncidents
                .Include(i => i.ReportedByUser)
                .OrderByDescending(i => i.ReportedDate)
                .ToListAsync();

            return View(incidents);
        }

        // GET: /Incident/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var incident = await _context.DisasterIncidents
                .Include(i => i.ReportedByUser)
                .FirstOrDefaultAsync(i => i.IncidentID == id);

            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }
    }
}