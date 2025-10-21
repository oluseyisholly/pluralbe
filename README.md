# Clinic Management API

This project provides a lightweight ASP.NET Core Web API for managing clinic facilities, clinics, patients, appointment types, and appointments. It uses Entity Framework Core with an in-memory database to keep the setup simple while demonstrating the core scheduling rules required for a front-desk workflow.

## Features

- Facility and clinic management endpoints for multi-location support.
- Patient registration with duplicate detection based on phone number, gender, and date of birth within a facility.
- Appointment type catalog with configurable default durations.
- Appointment scheduling service that enforces clinic-level double-booking protection with a two-hour buffer window.
- Filterable list endpoints for patients and appointments.
- Swagger/OpenAPI documentation available in development.

## Getting Started

1. **Install dependencies**

   ```bash
   dotnet restore
   ```

2. **Run the API**

   ```bash
   dotnet run
   ```

3. **Explore the API**

   When running in development the Swagger UI is available at `https://localhost:5001/swagger` (port may vary).

The in-memory database is seeded with sample data for facilities, clinics, appointment types, patients, and an upcoming appointment so you can exercise the endpoints immediately.
