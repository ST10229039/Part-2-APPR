using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class Volunteer
    {
        [Key]
        public int VolunteerID { get; set; }

        // Link to User account
        public int UserID { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage = "Skills information is required")]
        [StringLength(500)]
        public string Skills { get; set; }

        [Required(ErrorMessage = "Availability is required")]
        [StringLength(200)]
        public string Availability { get; set; }

        [StringLength(100)]
        public string? PreferredLocation { get; set; }

        public bool HasTransport { get; set; }

        public string? EmergencyContact { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Active";

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        // Assigned tasks/projects
        public int? AssignedIncidentID { get; set; }
        public DisasterIncident? AssignedIncident { get; set; }

        [StringLength(500)]
        public string? AssignmentNotes { get; set; }
    }
}