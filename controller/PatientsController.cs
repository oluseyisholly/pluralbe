using ClinicManagement.Data;
using ClinicManagement.Dtos;
using ClinicManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientsController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public PatientsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatientSummaryDto>>> GetPatients(
        [FromQuery] int? facilityId,
        [FromQuery] string? search,
        CancellationToken cancellationToken
    )
    {
        var query = _dbContext
            .Patients
            .AsNoTracking()
            .Include(p => p.Facility)
            .AsQueryable();

        if (facilityId is not null)
        {
            query = query.Where(p => p.FacilityId == facilityId);
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLowerInvariant();
            query = query.Where(p =>
                p.FirstName.ToLower().Contains(normalized)
                || (p.MiddleName != null && p.MiddleName.ToLower().Contains(normalized))
                || p.LastName.ToLower().Contains(normalized)
                || p.PrimaryPhone.Contains(normalized)
                || (p.Email != null && p.Email.ToLower().Contains(normalized))
            );
        }

        var patients = await query
            .OrderBy(p => p.LastName)
            .ThenBy(p => p.FirstName)
            .Select(
                p => new PatientSummaryDto(
                    p.Id,
                    p.FullName,
                    p.Gender,
                    p.DateOfBirth,
                    p.PrimaryPhone,
                    p.Email,
                    p.FacilityId,
                    p.Facility.Name
                )
            )
            .ToListAsync(cancellationToken);

        return Ok(patients);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PatientSummaryDto>> GetPatient(int id, CancellationToken cancellationToken)
    {
        var patient = await _dbContext
            .Patients
<<<<<<< HEAD
=======
            .AsNoTracking()
>>>>>>> e537d1b281b90efbf59e6df218beba06985d48ac
            .Include(p => p.Facility)
            .Where(p => p.Id == id)
            .Select(
                p => new PatientSummaryDto(
                    p.Id,
                    p.FullName,
                    p.Gender,
                    p.DateOfBirth,
                    p.PrimaryPhone,
                    p.Email,
                    p.FacilityId,
                    p.Facility.Name
                )
            )
            .SingleOrDefaultAsync(cancellationToken);

        if (patient is null)
        {
            return NotFound();
        }

        return Ok(patient);
    }

    [HttpPost]
    public async Task<ActionResult<PatientSummaryDto>> CreatePatient(
        PatientCreateDto dto,
        CancellationToken cancellationToken
    )
    {
<<<<<<< HEAD
        var facilityExists = await _dbContext.Facilities.AnyAsync(f => f.Id == dto.FacilityId, cancellationToken);
=======
        var facilityExists = await _dbContext
            .Facilities
            .AsNoTracking()
            .AnyAsync(f => f.Id == dto.FacilityId, cancellationToken);
>>>>>>> e537d1b281b90efbf59e6df218beba06985d48ac

        if (!facilityExists)
        {
            return BadRequest($"Facility with id {dto.FacilityId} does not exist.");
        }

        var duplicate = await _dbContext
            .Patients
            .AnyAsync(
                p =>
                    p.FacilityId == dto.FacilityId
                    && p.PrimaryPhone == dto.PrimaryPhone
                    && p.DateOfBirth == dto.DateOfBirth
                    && p.Gender == dto.Gender,
                cancellationToken
            );

        if (duplicate)
        {
            return Conflict("A patient with the same phone, date of birth, gender, and facility already exists.");
        }

        var patient = new Patient
        {
            FirstName = dto.FirstName,
            MiddleName = dto.MiddleName,
            LastName = dto.LastName,
            Gender = dto.Gender,
            DateOfBirth = dto.DateOfBirth,
            PrimaryPhone = dto.PrimaryPhone,
            Email = dto.Email,
            ContactAddress = dto.ContactAddress,
            FacilityId = dto.FacilityId,
        };

        _dbContext.Patients.Add(patient);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var facilityName = await _dbContext
            .Facilities
<<<<<<< HEAD
=======
            .AsNoTracking()
>>>>>>> e537d1b281b90efbf59e6df218beba06985d48ac
            .Where(f => f.Id == patient.FacilityId)
            .Select(f => f.Name)
            .SingleAsync(cancellationToken);

        var summary = new PatientSummaryDto(
            patient.Id,
            patient.FullName,
            patient.Gender,
            patient.DateOfBirth,
            patient.PrimaryPhone,
            patient.Email,
            patient.FacilityId,
            facilityName
        );

        return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, summary);
    }
}
