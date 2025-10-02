using Microsoft.EntityFrameworkCore;
using GiftOfTheGivers.Models;

namespace GiftOfTheGivers.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<DisasterIncident> DisasterIncidents { get; set; }
        public DbSet<ResourceDonation> ResourceDonations { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<ReliefProject> ReliefProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<DisasterIncident>()
                .HasOne(d => d.ReportedByUser)
                .WithMany()
                .HasForeignKey(d => d.ReportedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ResourceDonation>()
                .HasOne(d => d.Incident)
                .WithMany()
                .HasForeignKey(d => d.IncidentID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Volunteer>()
                .HasOne(v => v.User)
                .WithMany()
                .HasForeignKey(v => v.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Volunteer>()
                .HasOne(v => v.AssignedIncident)
                .WithMany()
                .HasForeignKey(v => v.AssignedIncidentID)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}