using ClinicManagement.Data;
using ClinicManagement.Dtos;
using ClinicManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Controllers;

[ApiController]
[Route("api/appointment-types")]
public class AppointmentTypesController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public AppointmentTypesController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppointmentTypeSummaryDto>>> GetAppointmentTypes(
        CancellationToken cancellationToken
    )
    {
        var types = await _dbContext
            .AppointmentTypes
            .OrderBy(t => t.Name)
            .Select(t => new AppointmentTypeSummaryDto(t.Id, t.Name, t.Description, t.DefaultDurationMinutes))
            .ToListAsync(cancellationToken);

        return Ok(types);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AppointmentTypeSummaryDto>> GetAppointmentType(
        int id,
        CancellationToken cancellationToken
    )
    {
        var type = await _dbContext
            .AppointmentTypes
            .Where(t => t.Id == id)
            .Select(t => new AppointmentTypeSummaryDto(t.Id, t.Name, t.Description, t.DefaultDurationMinutes))
            .SingleOrDefaultAsync(cancellationToken);

        if (type is null)
        {
            return NotFound();
        }

        return Ok(type);
    }

    [HttpPost]
    public async Task<ActionResult<AppointmentTypeSummaryDto>> CreateAppointmentType(
        AppointmentTypeCreateDto dto,
        CancellationToken cancellationToken
    )
    {
        var appointmentType = new AppointmentType
        {
            Name = dto.Name,
            Description = dto.Description,
            DefaultDurationMinutes = dto.DefaultDurationMinutes,
        };

        _dbContext.AppointmentTypes.Add(appointmentType);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var summary = new AppointmentTypeSummaryDto(
            appointmentType.Id,
            appointmentType.Name,
            appointmentType.Description,
            appointmentType.DefaultDurationMinutes
        );

        return CreatedAtAction(nameof(GetAppointmentType), new { id = appointmentType.Id }, summary);
    }
}
