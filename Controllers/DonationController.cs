using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftOfTheGivers.Models;
using GiftOfTheGivers.Data;

namespace GiftOfTheGivers.Controllers
{
    public class DonationController : Controller
    {
        private readonly AppDbContext _context;

        public DonationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Donation/Donate
        public async Task<IActionResult> Donate()
        {
            // Pass active incidents for donation targeting
            var activeIncidents = await _context.DisasterIncidents
                .Where(i => i.Status == "Active" || i.Status == "Reported")
                .ToListAsync();

            ViewBag.ActiveIncidents = activeIncidents;
            return View();
        }

        // POST: /Donation/Donate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Donate(ResourceDonation donation)
        {
            if (ModelState.IsValid)
            {
                donation.DonationDate = DateTime.Now;
                donation.Status = "Pending";

                _context.ResourceDonations.Add(donation);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Thank you for your donation! We will contact you shortly to arrange collection.";
                return RedirectToAction("ThankYou");
            }

            // Reload active incidents if validation fails
            var activeIncidents = await _context.DisasterIncidents
                .Where(i => i.Status == "Active" || i.Status == "Reported")
                .ToListAsync();

            ViewBag.ActiveIncidents = activeIncidents;
            return View(donation);
        }

        // GET: /Donation/ThankYou
        public IActionResult ThankYou()
        {
            return View();
        }

        // GET: /Donation/Manage (Admin only)
        public async Task<IActionResult> Manage()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Admin")
            {
                TempData["ErrorMessage"] = "Access denied. Admin privileges required.";
                return RedirectToAction("Index", "Home");
            }

            var donations = await _context.ResourceDonations
                .Include(d => d.Incident)
                .OrderByDescending(d => d.DonationDate)
                .ToListAsync();

            return View(donations);
        }

        // POST: /Donation/UpdateStatus/5
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Admin")
            {
                return Json(new { success = false, message = "Access denied." });
            }

            var donation = await _context.ResourceDonations.FindAsync(id);
            if (donation == null)
            {
                return Json(new { success = false, message = "Donation not found." });
            }

            donation.Status = status;
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Status updated successfully." });
        }
    }
}