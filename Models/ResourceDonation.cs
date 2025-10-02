using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class ResourceDonation
    {
        [Key]
        public int DonationID { get; set; }

        [Required(ErrorMessage = "Donor name is required")]
        [StringLength(100)]
        public string DonorName { get; set; }

        [Required(ErrorMessage = "Donor email is required")]
        [EmailAddress]
        public string DonorEmail { get; set; }

        [Required(ErrorMessage = "Item type is required")]
        [StringLength(100)]
        public string ItemType { get; set; } // Food, Clothing, Medical Supplies, etc.

        [Required(ErrorMessage = "Item name is required")]
        [StringLength(200)]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public DateTime DonationDate { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string Status { get; set; } = "Pending";

        [StringLength(255)]
        public string? PreferredDropoffLocation { get; set; }

        // Link to incident (optional)
        public int? IncidentID { get; set; }
        public DisasterIncident? Incident { get; set; }
    }
}
