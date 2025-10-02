📋 Project Overview
A comprehensive ASP.NET Core MVC web application developed for Gift Of The Givers, Africa's largest disaster response and humanitarian relief organization. This platform facilitates disaster management, resource coordination, and volunteer engagement through an intuitive web interface.

🎓 Academic Project: APPR6312 - Applied Programming
👨‍💻 Developer: ST10229039 - Thabelo Mavhaga
📅 Date: 2024

🚀 Live Demo
Test Environment: https://gift-of-the-givers-test.azurewebsites.net

Production Environment: https://gift-of-the-givers-prod.azurewebsites.net

✨ Features
🔐 Authentication & User Management
User registration and login system

Role-based access control (Admin, Volunteer, User)

Secure password hashing with BCrypt

Session management and profile management

🚨 Disaster Incident Management
Real-time incident reporting system

Incident categorization by type and severity

Geographical location tracking

Status tracking (Reported, Active, Resolved)

Public incident dashboard

🎁 Resource Donation System
Donation item cataloging and tracking

Donation status management (Pending, Received, Distributed)

Donor information management

Collection point coordination

Impact reporting

👥 Volunteer Management
Volunteer registration and skills assessment

Availability scheduling

Task assignment and tracking

Volunteer performance monitoring

Emergency contact management

🛠️ Administrative Features
Comprehensive admin dashboard

User management system

Donation tracking and management

Volunteer assignment coordination

System analytics and reporting

🛠️ Technology Stack
Backend
Framework: ASP.NET Core 8.0 MVC

Authentication: Session-based with BCrypt

Database: Entity Framework Core + In-Memory DB (Development)

Architecture: MVC Pattern with Repository Pattern

Frontend
UI Framework: Bootstrap 5.3.0

Icons: Font Awesome 6.0

Styling: Custom CSS with CSS3 animations

JavaScript: Vanilla JS with modern ES6+ features

DevOps & Infrastructure
Version Control: Git with Azure Repos

CI/CD: Azure DevOps Pipelines

Hosting: Azure App Services

Database: Azure SQL Database (Production)

📁 Project Structure
text
GiftOfTheGivers/
├── Controllers/                 # MVC Controllers
│   ├── HomeController.cs       # Landing and dashboard
│   ├── AccountController.cs    # Authentication
│   ├── IncidentController.cs   # Disaster management
│   ├── DonationController.cs   # Donation system
│   └── VolunteerController.cs  # Volunteer management
├── Models/                     # Data Models
│   ├── User.cs                # User accounts
│   ├── DisasterIncident.cs    # Incident tracking
│   ├── ResourceDonation.cs    # Donation management
│   ├── Volunteer.cs           # Volunteer data
│   └── ReliefProject.cs       # Project management
├── Views/                      # Razor Views
│   ├── Home/                  # Landing pages
│   ├── Account/               # Auth pages
│   ├── Incident/              # Incident views
│   ├── Donation/              # Donation views
│   ├── Volunteer/             # Volunteer views
│   └── Shared/                # Layout and partials
├── Data/                      # Data Access Layer
│   ├── AppDbContext.cs        # Database context
│   └── SeedData.cs            # Initial data seeding
├── Services/                  # Business Logic
│   └── AuthService.cs         # Authentication service
├── wwwroot/                   # Static Assets
│   ├── css/
│   ├── js/
│   └── images/
└── Configuration/
    ├── Program.cs             # App configuration
    └── appsettings.json       # Application settings
🚀 Quick Start
Prerequisites
.NET 8.0 SDK

Visual Studio 2022 or VS Code

Git

Installation Steps
Clone the Repository

bash
git clone https://github.com/ST10229039/Part-2-APPR.git
cd Part-2-APPR
Restore Dependencies

bash
dotnet restore
Run the Application

bash
dotnet run
Access the Application

Open your browser to: https://localhost:7000 or http://localhost:5000

Default Test Accounts
Administrator Account:

Email: admin@giftofthegivers.org

Password: admin123

Role: Full system access

Regular User Account:

Email: test@example.com

Password: test123

Role: Standard user permissions

🔧 Configuration
Development Environment
The application uses an in-memory database for development with pre-seeded data including:

Sample disaster incidents

Relief projects

Test user accounts

Volunteer opportunities

Production Environment
Azure SQL Database

Azure App Service hosting

Environment-specific configuration

SSL enforcement

📊 Database Schema
Core Entities
Users: User accounts and authentication

DisasterIncidents: Disaster reports and tracking

ResourceDonations: Donation management

Volunteers: Volunteer registration and assignments

ReliefProjects: Ongoing relief operations

Relationships
One-to-Many: Users to Incidents (Reporting)

One-to-Many: Users to Volunteers

Many-to-One: Donations to Incidents

Many-to-One: Volunteers to Projects

🎯 Key Features in Detail
Disaster Reporting System
Multi-category incident classification

Real-time status updates

Geographical impact assessment

Public visibility controls

Donation Management
Item categorization (Food, Clothing, Medical, etc.)

Donation status tracking

Collection point management

Impact measurement

Volunteer Coordination
Skills-based volunteer matching

Availability scheduling

Task assignment system

Performance tracking

🔒 Security Features
Password hashing with BCrypt

Session-based authentication

Role-based authorization

Input validation and sanitization

CSRF protection

Secure headers configuration

📈 CI/CD Pipeline
Azure DevOps Pipeline Features
Automated Builds: Triggered on push to develop/main

Testing: Unit test execution and reporting

Quality Gates: Build validation before deployment

Multi-environment Deployment: Test and production stages

Artifact Management: Build artifact versioning

Pipeline Stages
Build & Test

.NET 8 SDK setup

Dependency restoration

Compilation and build

Unit test execution

Deploy to Test

Automatic deployment to test environment

Environment validation

Smoke testing

Deploy to Production

Manual approval gates

Production deployment

Health monitoring

🌐 Deployment Architecture
text
Azure DevOps Repos
        ↓
Azure Pipelines (CI/CD)
        ↓
Azure App Services
├── Test Environment
└── Production Environment
        ↓
Azure SQL Database (Production)
🧪 Testing Strategy
Test Coverage
Unit tests for business logic

Integration tests for data access

UI tests for critical user journeys

API endpoint validation

Quality Assurance
Automated testing in CI pipeline

Code quality analysis

Security vulnerability scanning

Performance benchmarking

📝 API Endpoints
Authentication
POST /Account/Login - User authentication

POST /Account/Register - User registration

GET /Account/Logout - Session termination

Incident Management
GET /Incident/Index - List all incidents

POST /Incident/Report - Create new incident

GET /Incident/Details/{id} - Incident details

Donation System
GET /Donation/Donate - Donation form

POST /Donation/Donate - Submit donation

GET /Donation/Manage - Admin donation management

Volunteer System
GET /Volunteer/Register - Volunteer registration

POST /Volunteer/Register - Submit volunteer application

GET /Volunteer/Opportunities - Available opportunities

🔄 Development Workflow
Branch Strategy (Gitflow)
main - Production releases

develop - Development integration

feature/* - Feature development

hotfix/* - Production fixes

release/* - Release preparation

Commit Convention
text
feat: add new feature
fix: resolve issue
docs: update documentation
refactor: code restructuring
test: add tests
chore: maintenance tasks
🎨 UI/UX Features
Responsive Design
Mobile-first approach

Bootstrap 5 grid system

Cross-browser compatibility

Accessibility compliance (WCAG 2.1)

User Experience
Intuitive navigation

Progressive disclosure

Loading states and feedback

Error handling and validation

Visual Design
Consistent color scheme

Typography hierarchy

Interactive elements

Professional branding

📊 Performance Metrics
Target Performance
Page load time: < 3 seconds

Time to interactive: < 5 seconds

Database query performance: < 100ms

Concurrent users: 1000+

Optimization Strategies
Efficient database indexing

Caching strategies

Asset optimization

Code minification

🤝 Contributing
Development Setup
Fork the repository

Create a feature branch

Implement changes with tests

Submit pull request

Code Standards
Follow C# coding conventions

Include XML documentation

Write unit tests for new features

Update documentation accordingly

📄 License
This project is developed for educational purposes as part of the APPR6312 Applied Programming course. All rights reserved by the developer and academic institution.

📞 Support & Contact
Developer: Thabelo Mavhaga
Student ID: ST10229039
Course: APPR6312 - Applied Programming
Institution: [Your Institution Name]

For technical support or questions about this project, please contact the developer through the institution's academic channels.

🙏 Acknowledgments
Gift Of The Givers Foundation for the inspiration

Academic Instructors for guidance and supervision

Microsoft for development tools and Azure services

Open-source community for libraries and frameworks

