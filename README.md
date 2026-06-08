ParkSmart Backend
Description
ParkSmart Backend is a REST API built with ASP.NET Core and Clean Architecture principles. The application manages parking areas, parking spots, and parking sessions.

Technologies
ASP.NET Core
Entity Framework Core
SQL Server
MediatR
Swagger
Clean Architecture
Features
Manage parking areas
Manage parking spots
Manage parking sessions
RESTful API endpoints
Swagger documentation
Project Structure
ParkSmart.API
ParkSmart.Application
ParkSmart.Domain
ParkSmart.Infrastructure
ParkSmart.Tests
Running the Project
Clone the repository
Update the database connection string
Run database migrations
Start the application
dotnet run
API Documentation
Swagger UI is available when the application is running.

Author
Hager Sayed

Architecture Diagram
flowchart TD
    React[React Frontend] --> API[ParkSmart.API]
    API --> Application[ParkSmart.Application]
    Application --> Domain[ParkSmart.Domain]
    Application --> Infrastructure[ParkSmart.Infrastructure]
    Infrastructure --> DB[(SQL Database)]

    Domain --> ParkingArea[ParkingArea]
    Domain --> ParkingSpot[ParkingSpot]
    Domain --> ParkingSession[ParkingSession]
