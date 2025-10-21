using ClinicManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClinicManagement.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Facility> Facilities => Set<Facility>();
    public DbSet<Clinic> Clinics => Set<Clinic>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<AppointmentType> AppointmentTypes => Set<AppointmentType>();
    public DbSet<Appointment> Appointments => Set<Appointment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureDateAndTimeConversions(modelBuilder);

        modelBuilder.Entity<Facility>().HasIndex(f => f.Code).IsUnique();
        modelBuilder.Entity<Clinic>().HasIndex(c => new { c.Code, c.FacilityId }).IsUnique();
        modelBuilder.Entity<Patient>().HasIndex(p => new { p.PrimaryPhone, p.DateOfBirth, p.Gender, p.FacilityId }).IsUnique();

        SeedData(modelBuilder);
    }

    private static void ConfigureDateAndTimeConversions(ModelBuilder modelBuilder)
    {
        var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
            d => d.ToDateTime(TimeOnly.MinValue),
            dt => DateOnly.FromDateTime(dt));

        var dateOnlyComparer = new ValueComparer<DateOnly>(
            (d1, d2) => d1 == d2,
            d => d.GetHashCode(),
            d => d);

        var timeOnlyConverter = new ValueConverter<TimeOnly, TimeSpan>(
            t => t.ToTimeSpan(),
            ts => TimeOnly.FromTimeSpan(ts));

        var timeOnlyComparer = new ValueComparer<TimeOnly>(
            (t1, t2) => t1 == t2,
            t => t.GetHashCode(),
            t => t);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateOnly))
                {
                    property.SetValueConverter(dateOnlyConverter);
                    property.SetValueComparer(dateOnlyComparer);
                }

                if (property.ClrType == typeof(TimeOnly))
                {
                    property.SetValueConverter(timeOnlyConverter);
                    property.SetValueComparer(timeOnlyComparer);
                }
            }
        }
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        var utcNow = DateTime.UtcNow;

        var facility1 = new Facility
        {
            Id = 1,
            Name = "Downtown Medical Center",
            Code = "DMC",
            Address = "123 Main St, Springfield",
            Timezone = "UTC",
            CreatedAt = utcNow,
        };

        var facility2 = new Facility
        {
            Id = 2,
            Name = "Lakeside Family Clinic",
            Code = "LFC",
            Address = "45 Lake View Dr, Springfield",
            Timezone = "UTC",
            CreatedAt = utcNow,
        };

        modelBuilder.Entity<Facility>().HasData(facility1, facility2);

        modelBuilder.Entity<Clinic>().HasData(
            new Clinic { Id = 1, Name = "General Practice", Code = "GP", FacilityId = facility1.Id, CreatedAt = utcNow },
            new Clinic { Id = 2, Name = "Pediatrics", Code = "PED", FacilityId = facility1.Id, CreatedAt = utcNow },
            new Clinic { Id = 3, Name = "Dermatology", Code = "DERM", FacilityId = facility2.Id, CreatedAt = utcNow }
        );

        modelBuilder.Entity<AppointmentType>().HasData(
            new AppointmentType
            {
                Id = 1,
                Name = "Initial Consultation",
                Description = "First-time patient visit",
                DefaultDurationMinutes = 60,
                CreatedAt = utcNow,
            },
            new AppointmentType
            {
                Id = 2,
                Name = "Follow-up",
                Description = "Routine follow-up appointment",
                DefaultDurationMinutes = 30,
                CreatedAt = utcNow,
            },
            new AppointmentType
            {
                Id = 3,
                Name = "Procedure",
                Description = "Minor in-clinic procedure",
                DefaultDurationMinutes = 90,
                CreatedAt = utcNow,
            }
        );

        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                Id = 1,
                FirstName = "Amina",
                LastName = "Okafor",
                Gender = "Female",
                DateOfBirth = new DateOnly(1990, 5, 12),
                PrimaryPhone = "+2348012345678",
                Email = "amina.okafor@example.com",
                ContactAddress = "12 Palm Avenue, Springfield",
                FacilityId = facility1.Id,
                CreatedAt = utcNow,
            },
            new Patient
            {
                Id = 2,
                FirstName = "David",
                LastName = "Ngugi",
                Gender = "Male",
                DateOfBirth = new DateOnly(1985, 11, 3),
                PrimaryPhone = "+254701112233",
                Email = "david.ngugi@example.com",
                ContactAddress = "7 Market Road, Springfield",
                FacilityId = facility2.Id,
                CreatedAt = utcNow,
            }
        );

        modelBuilder.Entity<Appointment>().HasData(
            new Appointment
            {
                Id = 1,
                PatientId = 1,
                ClinicId = 1,
                AppointmentTypeId = 1,
                AppointmentDate = DateOnly.FromDateTime(DateTime.UtcNow.Date.AddDays(1)),
                StartTime = new TimeOnly(9, 0),
                DurationMinutes = 60,
                Status = "Scheduled",
                CreatedAt = utcNow,
            }
        );
    }
}
