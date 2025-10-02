using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class DisasterIncident
    {
        [Key]
        public int IncidentID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(100)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Disaster type is required")]
        [StringLength(50)]
        public string DisasterType { get; set; } // Flood, Fire, Earthquake, etc.

        [Required(ErrorMessage = "Severity level is required")]
        [StringLength(20)]
        public string Severity { get; set; } // Low, Medium, High, Critical

        public int PeopleAffected { get; set; }

        public DateTime IncidentDate { get; set; } = DateTime.Now;

        public DateTime ReportedDate { get; set; } = DateTime.Now;

        [StringLength(20)]
        public string Status { get; set; } = "Reported";

        // Foreign Key
        public int ReportedByUserID { get; set; }
        public User ReportedByUser { get; set; }
    }
}