using ClinicManagement.Data;
using ClinicManagement.Dtos;
using ClinicManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Controllers;

[ApiController]
[Route("api/appointments")]
public class AppointmentsController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IAppointmentScheduler _appointmentScheduler;

    public AppointmentsController(AppDbContext dbContext, IAppointmentScheduler appointmentScheduler)
    {
        _dbContext = dbContext;
        _appointmentScheduler = appointmentScheduler;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppointmentSummaryDto>>> GetAppointments(
        [FromQuery] DateOnly? date,
        [FromQuery] int? facilityId,
        [FromQuery] int? clinicId,
        CancellationToken cancellationToken
    )
    {
        var query = _dbContext
            .Appointments
            .AsNoTracking()
            .Include(a => a.Patient)
            .Include(a => a.Clinic)
            .ThenInclude(c => c.Facility)
            .Include(a => a.AppointmentType)
            .AsQueryable();

        if (date is not null)
        {
            query = query.Where(a => a.AppointmentDate == date);
        }

        if (facilityId is not null)
        {
            query = query.Where(a => a.Clinic.FacilityId == facilityId);
        }

        if (clinicId is not null)
        {
            query = query.Where(a => a.ClinicId == clinicId);
        }

        var appointments = await query
            .OrderBy(a => a.AppointmentDate)
            .ThenBy(a => a.StartTime)
            .Select(
                a => new AppointmentSummaryDto(
                    a.Id,
                    a.AppointmentDate,
                    a.StartTime,
                    a.DurationMinutes,
                    a.Status,
                    a.Clinic.Name,
                    a.Clinic.Facility.Name,
                    a.AppointmentType.Name,
                    a.Patient.FullName
                )
            )
            .ToListAsync(cancellationToken);

        return Ok(appointments);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AppointmentSummaryDto>> GetAppointment(int id, CancellationToken cancellationToken)
    {
        var appointment = await _dbContext
            .Appointments
            .AsNoTracking()
            .Include(a => a.Patient)
            .Include(a => a.Clinic)
            .ThenInclude(c => c.Facility)
            .Include(a => a.AppointmentType)
            .Where(a => a.Id == id)
            .Select(
                a => new AppointmentSummaryDto(
                    a.Id,
                    a.AppointmentDate,
                    a.StartTime,
                    a.DurationMinutes,
                    a.Status,
                    a.Clinic.Name,
                    a.Clinic.Facility.Name,
                    a.AppointmentType.Name,
                    a.Patient.FullName
                )
            )
            .SingleOrDefaultAsync(cancellationToken);

        if (appointment is null)
        {
            return NotFound();
        }

        return Ok(appointment);
    }

    [HttpPost]
    public async Task<ActionResult<AppointmentSummaryDto>> CreateAppointment(
        [FromBody] AppointmentCreateDto dto,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var appointment = await _appointmentScheduler.ScheduleAsync(dto, cancellationToken);

            var created = await _dbContext
                .Appointments
                .AsNoTracking()
                .Include(a => a.Patient)
                .Include(a => a.Clinic)
                .ThenInclude(c => c.Facility)
                .Include(a => a.AppointmentType)
                .Where(a => a.Id == appointment.Id)
                .Select(
                    a => new AppointmentSummaryDto(
                        a.Id,
                        a.AppointmentDate,
                        a.StartTime,
                        a.DurationMinutes,
                        a.Status,
                        a.Clinic.Name,
                        a.Clinic.Facility.Name,
                        a.AppointmentType.Name,
                        a.Patient.FullName
                    )
                )
                .SingleAsync(cancellationToken);

            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, created);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
