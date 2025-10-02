using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class ReliefProject
    {
        [Key]
        public int ProjectID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Planning";

        [StringLength(50)]
        public string ProjectType { get; set; } // Emergency, Development, Medical, etc.

        public decimal Budget { get; set; }

        public int TargetBeneficiaries { get; set; }

        // Collection navigation properties
        public ICollection<Volunteer> Volunteers { get; set; } = new List<Volunteer>();
        public ICollection<ResourceDonation> Donations { get; set; } = new List<ResourceDonation>();
    }
}
