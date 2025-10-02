using GiftOfTheGivers.Models;

namespace GiftOfTheGivers.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            // Clear existing data
            context.Users.RemoveRange(context.Users);
            context.ReliefProjects.RemoveRange(context.ReliefProjects);
            context.DisasterIncidents.RemoveRange(context.DisasterIncidents);
            context.ResourceDonations.RemoveRange(context.ResourceDonations);
            context.Volunteers.RemoveRange(context.Volunteers);
            context.SaveChanges();

            // Add initial admin user
            var adminUser = new User
            {
                UserID = 1,
                Name = "Admin User",
                Email = "admin@giftofthegivers.org",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                Role = "Admin",
                Phone = "+27 123 456 7890",
                Address = "123 Admin Street, Johannesburg",
                DateCreated = DateTime.Now
            };
            context.Users.Add(adminUser);

            // Add regular test user
            var testUser = new User
            {
                UserID = 2,
                Name = "Test User",
                Email = "test@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test123"),
                Role = "User",
                Phone = "+27 111 222 3333",
                Address = "456 Test Street, Cape Town",
                DateCreated = DateTime.Now
            };
            context.Users.Add(testUser);

            context.SaveChanges();

            // Add sample relief projects
            var project1 = new ReliefProject
            {
                ProjectID = 1,
                Name = "KZN Flood Relief 2024",
                Description = "Emergency relief for communities affected by floods in KwaZulu-Natal. Providing food, shelter, and medical assistance to affected families.",
                Location = "KwaZulu-Natal",
                StartDate = new DateTime(2024, 1, 15),
                Status = "Active",
                ProjectType = "Emergency",
                Budget = 5000000,
                TargetBeneficiaries = 10000
            };

            var project2 = new ReliefProject
            {
                ProjectID = 2,
                Name = "Winter Warmth Campaign",
                Description = "Providing warm clothing, blankets, and heating equipment to vulnerable communities during winter months.",
                Location = "Nationwide",
                StartDate = new DateTime(2024, 5, 1),
                Status = "Planning",
                ProjectType = "Development",
                Budget = 2000000,
                TargetBeneficiaries = 5000
            };

            var project3 = new ReliefProject
            {
                ProjectID = 3,
                Name = "Medical Outreach Program",
                Description = "Mobile medical clinics providing healthcare services to remote and underserved communities.",
                Location = "Eastern Cape",
                StartDate = new DateTime(2024, 3, 1),
                Status = "Active",
                ProjectType = "Medical",
                Budget = 1500000,
                TargetBeneficiaries = 3000
            };

            context.ReliefProjects.AddRange(project1, project2, project3);

            // Add sample disaster incidents
            var incident1 = new DisasterIncident
            {
                IncidentID = 1,
                Title = "KZN Floods - Emergency Response",
                Description = "Severe flooding affecting multiple communities in KwaZulu-Natal. Widespread damage to infrastructure and homes.",
                Location = "Durban, KwaZulu-Natal",
                DisasterType = "Flood",
                Severity = "High",
                PeopleAffected = 5000,
                IncidentDate = new DateTime(2024, 1, 15),
                ReportedDate = DateTime.Now.AddDays(-5),
                Status = "Active",
                ReportedByUserID = 1
            };

            var incident2 = new DisasterIncident
            {
                IncidentID = 2,
                Title = "Western Cape Fire Relief",
                Description = "Wildfires affecting residential areas in Cape Town. Multiple families displaced and in need of assistance.",
                Location = "Cape Town, Western Cape",
                DisasterType = "Fire",
                Severity = "Medium",
                PeopleAffected = 1000,
                IncidentDate = new DateTime(2024, 1, 10),
                ReportedDate = DateTime.Now.AddDays(-3),
                Status = "Active",
                ReportedByUserID = 1
            };

            var incident3 = new DisasterIncident
            {
                IncidentID = 3,
                Title = "Gauteng Storm Damage",
                Description = "Severe thunderstorms causing power outages and structural damage across Johannesburg.",
                Location = "Johannesburg, Gauteng",
                DisasterType = "Storm",
                Severity = "Medium",
                PeopleAffected = 2000,
                IncidentDate = new DateTime(2024, 1, 8),
                ReportedDate = DateTime.Now.AddDays(-1),
                Status = "Under Review",
                ReportedByUserID = 2
            };

            context.DisasterIncidents.AddRange(incident1, incident2, incident3);

            // Add sample resource donations
            var donation1 = new ResourceDonation
            {
                DonationID = 1,
                DonorName = "John Smith",
                DonorEmail = "john.smith@email.com",
                ItemType = "Food",
                ItemName = "Non-perishable food items",
                Quantity = 50,
                Description = "Canned goods, rice, and pasta for flood victims",
                DonationDate = DateTime.Now.AddDays(-2),
                Status = "Pending",
                PreferredDropoffLocation = "Durban Central Warehouse",
                IncidentID = 1
            };

            var donation2 = new ResourceDonation
            {
                DonationID = 2,
                DonorName = "Sarah Johnson",
                DonorEmail = "sarahj@email.com",
                ItemType = "Clothing",
                ItemName = "Winter jackets and blankets",
                Quantity = 100,
                Description = "Warm clothing for winter campaign",
                DonationDate = DateTime.Now.AddDays(-1),
                Status = "Received",
                PreferredDropoffLocation = "Cape Town Distribution Center",
                IncidentID = 2
            };

            var donation3 = new ResourceDonation
            {
                DonationID = 3,
                DonorName = "Mike Davis",
                DonorEmail = "mike.davis@email.com",
                ItemType = "Medical Supplies",
                ItemName = "First aid kits and medications",
                Quantity = 25,
                Description = "Basic medical supplies for outreach program",
                DonationDate = DateTime.Now,
                Status = "Pending",
                PreferredDropoffLocation = "Port Elizabeth Clinic",
                IncidentID = 3
            };

            context.ResourceDonations.AddRange(donation1, donation2, donation3);

            // Add sample volunteers
            var volunteer1 = new Volunteer
            {
                VolunteerID = 1,
                UserID = 2,
                Skills = "First Aid, Counseling, Logistics",
                Availability = "Weekends and Evenings",
                PreferredLocation = "KwaZulu-Natal",
                HasTransport = true,
                EmergencyContact = "+27 111 222 3333",
                Status = "Active",
                RegistrationDate = DateTime.Now.AddDays(-10),
                AssignedIncidentID = 1,
                AssignmentNotes = "Assigned to flood relief operations"
            };

            var volunteer2 = new Volunteer
            {
                VolunteerID = 2,
                UserID = 1,
                Skills = "Management, Coordination, Fundraising",
                Availability = "Full-time",
                PreferredLocation = "Nationwide",
                HasTransport = true,
                EmergencyContact = "+27 123 456 7890",
                Status = "Active",
                RegistrationDate = DateTime.Now.AddDays(-30),
                AssignedIncidentID = 2,
                AssignmentNotes = "Coordinating fire relief efforts"
            };

            context.Volunteers.AddRange(volunteer1, volunteer2);

            context.SaveChanges();

            Console.WriteLine("Database seeded successfully with sample data!");
        }
    }
}