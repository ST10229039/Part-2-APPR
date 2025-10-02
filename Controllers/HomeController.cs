using Microsoft.AspNetCore.Mvc;
using GiftOfTheGivers.Data;
using Microsoft.EntityFrameworkCore;

namespace GiftOfTheGivers.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(AppDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var stats = new
                {
                    TotalProjects = await _context.ReliefProjects.CountAsync(),
                    ActiveIncidents = await _context.DisasterIncidents.CountAsync(i => i.Status == "Active"),
                    TotalDonations = await _context.ResourceDonations.CountAsync(),
                    ActiveVolunteers = await _context.Volunteers.CountAsync(v => v.Status == "Active")
                };

                ViewBag.Stats = stats;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading statistics");

                // Provide default stats if database is not available
                ViewBag.Stats = new
                {
                    TotalProjects = 3,
                    ActiveIncidents = 2,
                    TotalDonations = 3,
                    ActiveVolunteers = 2
                };
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}