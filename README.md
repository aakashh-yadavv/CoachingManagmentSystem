Coaching Management System API
A Coaching Management System REST API built using ASP.NET Core Web API.
This project manages Students, Courses, Batches, Fees, Attendance, and provides Dashboard insights.
🚀 Features
👨‍🎓 Student Management
📚 Course & Batch Management
💰 Fees Management (Partial / Paid / Pending)
🧾 Auto Fee Calculation (Paid, Remaining, Status)
🗑 Soft Delete
📊 Dashboard Summary
🔍 Pagination & Search
🔐 Clean Architecture (Service Layer Pattern)
🧠 Key Concepts Implemented
RESTful API Design
Entity Relationships (One-to-Many)
DTO Pattern
Business Logic in Service Layer
Error Handling
Database Migrations
Swagger Testing
🛠 Tech Stack
ASP.NET Core Web API
Entity Framework Core
SQL Server
C#
Swagger UI
📂 Project Structure
Plain text
Controllers
Services
Models
DTOs
Data (DbContext)
🔥 API Highlights
📌 Dashboard API
Total Students
Total Courses
Total Batches
Total Fees Collected
Today Attendance
📌 Fees Logic
Auto calculation of Remaining Amount
Auto Status Update
Prevent Overpayment
Prevent Duplicate Full Payment# CoachingManagment
