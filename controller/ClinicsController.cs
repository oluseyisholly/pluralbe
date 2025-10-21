using ClinicManagement.Data;
using ClinicManagement.Dtos;
using ClinicManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Controllers;

[ApiController]
[Route("api/clinics")]
public class ClinicsController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public ClinicsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClinicSummaryDto>>> GetClinics(
        [FromQuery] int? facilityId,
        CancellationToken cancellationToken
    )
    {
        var query = _dbContext
            .Clinics
            .Include(c => c.Facility)
            .AsQueryable();

        if (facilityId is not null)
        {
            query = query.Where(c => c.FacilityId == facilityId);
        }

        var clinics = await query
            .OrderBy(c => c.Name)
            .Select(c => new ClinicSummaryDto(c.Id, c.Name, c.Code, c.FacilityId, c.Facility.Name))
            .ToListAsync(cancellationToken);

        return Ok(clinics);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ClinicSummaryDto>> GetClinic(int id, CancellationToken cancellationToken)
    {
        var clinic = await _dbContext
            .Clinics
            .Include(c => c.Facility)
            .Where(c => c.Id == id)
            .Select(c => new ClinicSummaryDto(c.Id, c.Name, c.Code, c.FacilityId, c.Facility.Name))
            .SingleOrDefaultAsync(cancellationToken);

        if (clinic is null)
        {
            return NotFound();
        }

        return Ok(clinic);
    }

    [HttpPost]
    public async Task<ActionResult<ClinicSummaryDto>> CreateClinic(
        ClinicCreateDto dto,
        CancellationToken cancellationToken
    )
    {
        var facilityExists = await _dbContext.Facilities.AnyAsync(f => f.Id == dto.FacilityId, cancellationToken);

        if (!facilityExists)
        {
            return BadRequest($"Facility with id {dto.FacilityId} does not exist.");
        }

        var clinic = new Clinic
        {
            Name = dto.Name,
            Code = dto.Code,
            FacilityId = dto.FacilityId,
        };

        _dbContext.Clinics.Add(clinic);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var facilityName = await _dbContext
            .Facilities
            .Where(f => f.Id == clinic.FacilityId)
            .Select(f => f.Name)
            .SingleAsync(cancellationToken);

        var summary = new ClinicSummaryDto(clinic.Id, clinic.Name, clinic.Code, clinic.FacilityId, facilityName);
        return CreatedAtAction(nameof(GetClinic), new { id = clinic.Id }, summary);
    }
}
