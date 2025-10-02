# 🎁 Gift Of The Givers - Disaster Management Web Application

> A comprehensive ASP.NET Core MVC application developed for **Gift Of The Givers**, Africa's largest disaster response and humanitarian relief organization. This platform enables real-time disaster incident reporting, resource coordination, and volunteer engagement via an intuitive web interface.

---

## 📚 Project Information

- 🎓 **Academic Project**: APPR6312 - Applied Programming  
- 👨‍💻 **Developer**: Thabelo Mavhaga (Student ID: ST10229039)  
- 🏛 **Institution**: [Your Institution Name]  
- 📅 **Year**: 2024  

---

## 🚀 Live Demo

- **Test Environment**: [gift-of-the-givers-test.azurewebsites.net](https://gift-of-the-givers-test.azurewebsites.net)  
- **Production Environment**: [gift-of-the-givers-prod.azurewebsites.net](https://gift-of-the-givers-prod.azurewebsites.net)

---

## ✨ Key Features

### 🔐 Authentication & User Management
- User registration & login
- Role-based access control (Admin, Volunteer, User)
- Secure password hashing with **BCrypt**
- Session & profile management

### 🚨 Disaster Incident Management
- Real-time incident reporting
- Categorization by type & severity
- Geo-location tracking
- Status lifecycle (Reported, Active, Resolved)
- Public dashboard

### 🎁 Resource Donation System
- Donation cataloging and tracking
- Status updates (Pending, Received, Distributed)
- Donor management
- Collection point coordination
- Impact reporting

### 👥 Volunteer Management
- Volunteer registration and skills assessment
- Availability scheduling
- Task assignment and monitoring
- Emergency contact storage

### 🛠️ Admin Features
- Admin dashboard
- Full user and donation management
- Volunteer assignment tools
- Analytics & reporting

---

## 🧰 Technology Stack

### Backend
- **Framework**: ASP.NET Core 8.0 MVC
- **Database**: Entity Framework Core (In-Memory for Dev, Azure SQL for Prod)
- **Authentication**: Session-based w/ BCrypt
- **Architecture**: MVC Pattern + Repository Pattern

### Frontend
- **UI Framework**: Bootstrap 5.3
- **Styling**: CSS3 + Animations
- **Icons**: Font Awesome 6.0
- **JavaScript**: ES6+ (Vanilla JS)

### DevOps & Hosting
- **Version Control**: Git + Azure Repos
- **CI/CD**: Azure DevOps Pipelines
- **Hosting**: Azure App Services
- **Database**: Azure SQL (Production)

---

## 📁 Project Structure

```text
GiftOfTheGivers/
├── Controllers/
│   ├── HomeController.cs
│   ├── AccountController.cs
│   ├── IncidentController.cs
│   ├── DonationController.cs
│   └── VolunteerController.cs
├── Models/
│   ├── User.cs
│   ├── DisasterIncident.cs
│   ├── ResourceDonation.cs
│   ├── Volunteer.cs
│   └── ReliefProject.cs
├── Views/
│   ├── Home/
│   ├── Account/
│   ├── Incident/
│   ├── Donation/
│   ├── Volunteer/
│   └── Shared/
├── Data/
│   ├── AppDbContext.cs
│   └── SeedData.cs
├── Services/
│   └── AuthService.cs
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── images/
└── Configuration/
    ├── Program.cs
    └── appsettings.json
⚙️ Quick Start
✅ Prerequisites
.NET 8 SDK

Visual Studio 2022 or VS Code

Git

🛠️ Installation
bash
Copy code
git clone https://github.com/ST10229039/Part-2-APPR.git
cd Part-2-APPR
dotnet restore
dotnet run
Open browser at:
https://localhost:7000 or http://localhost:5000

🔐 Test Accounts
Administrator
Email: admin@giftofthegivers.org

Password: admin123

Regular User
Email: test@example.com

Password: test123

🔧 Configuration
Development
In-Memory DB with seed data

Test users, incidents, and projects

Production
Azure SQL Database

SSL enforced

Env-based config

🗃️ Database Schema
Core Entities
Users: Login, roles, profiles

DisasterIncidents: Reports and tracking

ResourceDonations: Donation lifecycle

Volunteers: Registration & assignments

ReliefProjects: Active initiatives

Relationships
One-to-Many: Users → Incidents

One-to-Many: Users → Volunteers

Many-to-One: Donations → Incidents

Many-to-One: Volunteers → Projects

📈 CI/CD Pipeline – Azure DevOps
Pipeline Stages
Build & Test

Restore packages

Compile app

Run unit tests

Deploy to Test

Auto-deploy to test slot

Run smoke tests

Deploy to Production

Manual approval gates

Final deployment

Health checks

🧪 Testing Strategy
✅ Unit tests for business logic

🔁 Integration tests for database

🌐 UI tests for workflows

🛡 API endpoint testing

🧰 Code quality & performance analysis

🔍 Security scans (CSRF, input validation, auth checks)

📡 API Endpoints
🔐 Authentication
POST /Account/Login – Login

POST /Account/Register – Register

GET /Account/Logout – Logout

🆘 Incidents
GET /Incident/Index – List incidents

POST /Incident/Report – Submit incident

GET /Incident/Details/{id} – View incident

🎁 Donations
GET /Donation/Donate – Donation form

POST /Donation/Donate – Submit donation

GET /Donation/Manage – Admin panel

👥 Volunteers
GET /Volunteer/Register – Sign up

POST /Volunteer/Register – Submit form

GET /Volunteer/Opportunities – View roles

🔄 Development Workflow
Branch Strategy (GitFlow)
main: Production

develop: Staging/integration

feature/*: New features

hotfix/*: Critical fixes

release/*: Pre-release

Commit Convention
text
Copy code
feat: Add new feature
fix: Resolve bug
docs: Update documentation
refactor: Code refactor
test: Add or modify tests
chore: Non-functional updates
🎨 UI/UX Design
Design Principles
Mobile-first (Responsive)

Accessibility compliant (WCAG 2.1)

Cross-browser compatible

Experience Enhancements
Intuitive navigation

Validation feedback

Loading indicators

Consistent branding and color palette

📊 Performance Goals
Metric	Target
Page load time	< 3 seconds
Time to interactive	< 5 seconds
DB Query Performance	< 100ms
Concurrent User Support	1000+

Optimization Tactics
Caching & Indexing

Lazy-loading assets

Minified JS/CSS

CDN for static resources

🤝 Contributing
Setup for Developers
Fork this repo

Create a new feature branch

Implement and test your changes

Submit a pull request

Coding Standards
Follow C# conventions

Include XML docs

Write unit tests for features

Keep documentation updated

📄 License
This project is developed for academic purposes as part of the APPR6312 - Applied Programming course.
All rights reserved by the developer and the academic institution.

📞 Support
Developer: Thabelo Mavhaga
Student ID: ST10229039
Course: APPR6312 - Applied Programming
Institution: [Your Institution Name]

For inquiries, please contact via academic channels.

🙏 Acknowledgments
Gift Of The Givers Foundation – Project inspiration

Academic Instructors – Supervision and guidance

Microsoft – Azure tools and hosting

Open-source Community – Libraries and frameworks

yaml
Copy code

