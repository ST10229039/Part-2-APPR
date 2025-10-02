using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftOfTheGivers.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        [Display(Name = "Full Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(255, ErrorMessage = "Email cannot exceed 255 characters")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        //[Required]
        // public string PasswordHash { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        [StringLength(50)]
        public string Role { get; set; } = "User";

        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [StringLength(500, ErrorMessage = "Address cannot exceed 500 characters")]
        [Display(Name = "Physical Address")]
        public string? Address { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<DisasterIncident>? ReportedIncidents { get; set; }
        public virtual Volunteer? VolunteerProfile { get; set; }
    }
}