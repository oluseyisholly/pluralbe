using ClinicManagement.Data;
using ClinicManagement.Dtos;
using ClinicManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClinicManagement.Services;

public interface IAppointmentScheduler
{
    Task<Appointment> ScheduleAsync(AppointmentCreateDto dto, CancellationToken cancellationToken = default);
}

public class AppointmentScheduler : IAppointmentScheduler
{
    private readonly AppDbContext _dbContext;

    public AppointmentScheduler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Appointment> ScheduleAsync(AppointmentCreateDto dto, CancellationToken cancellationToken = default)
    {
        var clinic = await _dbContext
            .Clinics
            .AsNoTracking()
            .Include(c => c.Facility)
            .SingleOrDefaultAsync(c => c.Id == dto.ClinicId, cancellationToken);

        if (clinic is null)
        {
            throw new InvalidOperationException($"Clinic with id {dto.ClinicId} was not found.");
        }

<<<<<<< HEAD
        var patient = await _dbContext.Patients.SingleOrDefaultAsync(p => p.Id == dto.PatientId, cancellationToken);
=======
        var patient = await _dbContext
            .Patients
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == dto.PatientId, cancellationToken);
>>>>>>> e537d1b281b90efbf59e6df218beba06985d48ac

        if (patient is null)
        {
            throw new InvalidOperationException($"Patient with id {dto.PatientId} was not found.");
        }

        if (patient.FacilityId != clinic.FacilityId)
        {
            throw new InvalidOperationException("Patient belongs to a different facility than the selected clinic.");
        }

        var appointmentType = await _dbContext
            .AppointmentTypes
<<<<<<< HEAD
=======
            .AsNoTracking()
>>>>>>> e537d1b281b90efbf59e6df218beba06985d48ac
            .SingleOrDefaultAsync(a => a.Id == dto.AppointmentTypeId, cancellationToken);

        if (appointmentType is null)
        {
            throw new InvalidOperationException($"Appointment type with id {dto.AppointmentTypeId} was not found.");
        }

        var duration = dto.DurationMinutes ?? appointmentType.DefaultDurationMinutes;

        if (duration < 15 || duration > 480)
        {
            throw new InvalidOperationException("Appointment duration must be between 15 minutes and 8 hours.");
        }

        var startLocalDateTime = dto.AppointmentDate.ToDateTime(dto.StartTime);
        var endLocalDateTime = startLocalDateTime.AddMinutes(duration);

<<<<<<< HEAD
        var conflictingAppointment = await _dbContext
            .Appointments
            .Where(a => a.ClinicId == dto.ClinicId && a.AppointmentDate == dto.AppointmentDate)
            .AsEnumerable()
=======
        var sameClinicAppointments = await _dbContext
            .Appointments
            .AsNoTracking()
            .Where(a => a.ClinicId == dto.ClinicId && a.AppointmentDate == dto.AppointmentDate)
            .ToListAsync(cancellationToken);

        var conflictingAppointment = sameClinicAppointments
>>>>>>> e537d1b281b90efbf59e6df218beba06985d48ac
            .FirstOrDefault(existing => HasConflict(existing, startLocalDateTime, endLocalDateTime));

        if (conflictingAppointment is not null)
        {
            throw new InvalidOperationException(
                $"The clinic already has an appointment near the requested time (existing appointment id {conflictingAppointment.Id})."
            );
        }

        var appointment = new Appointment
        {
            PatientId = patient.Id,
            ClinicId = clinic.Id,
            AppointmentTypeId = appointmentType.Id,
            AppointmentDate = dto.AppointmentDate,
            StartTime = dto.StartTime,
            DurationMinutes = duration,
            Notes = dto.Notes,
            Status = "Scheduled",
        };

        _dbContext.Appointments.Add(appointment);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return appointment;
    }

    private static bool HasConflict(Appointment existing, DateTime requestedStart, DateTime requestedEnd)
    {
        var existingStart = existing.AppointmentDate.ToDateTime(existing.StartTime);
        var existingEnd = existingStart.AddMinutes(existing.DurationMinutes);

        // Enforce a two-hour buffer window from either direction
        var bufferStart = existingStart.AddHours(-2);
        var bufferEnd = existingStart.AddHours(2);

        var overlaps = requestedStart < existingEnd && requestedEnd > existingStart;
        var withinBuffer = requestedStart < bufferEnd && requestedEnd > bufferStart;

        return overlaps || withinBuffer;
    }
}
