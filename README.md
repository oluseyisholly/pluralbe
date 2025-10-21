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

## Troubleshooting

- If you previously worked on the ecommerce version of this project, remove the old `Migrations/` folder and clean any cached build outputs before running `dotnet build`. The current in-memory setup does not require those migration classes and the stale files can cause compiler errors about missing namespaces or Npgsql references. The project file now explicitly excludes `Migrations/` from compilation to prevent these legacy files from blocking the build, but deleting them keeps your workspace tidy.
