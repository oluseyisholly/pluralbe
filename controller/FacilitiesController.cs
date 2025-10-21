using ClinicManagement.Data;
using ClinicManagement.Dtos;
using ClinicManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Controllers;

[ApiController]
[Route("api/facilities")]
public class FacilitiesController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public FacilitiesController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FacilitySummaryDto>>> GetFacilities(CancellationToken cancellationToken)
    {
        var facilities = await _dbContext
            .Facilities
            .OrderBy(f => f.Name)
            .Select(f => new FacilitySummaryDto(f.Id, f.Name, f.Code, f.Address, f.Timezone))
            .ToListAsync(cancellationToken);

        return Ok(facilities);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<FacilitySummaryDto>> GetFacility(int id, CancellationToken cancellationToken)
    {
        var facility = await _dbContext
            .Facilities
            .Where(f => f.Id == id)
            .Select(f => new FacilitySummaryDto(f.Id, f.Name, f.Code, f.Address, f.Timezone))
            .SingleOrDefaultAsync(cancellationToken);

        if (facility is null)
        {
            return NotFound();
        }

        return Ok(facility);
    }

    [HttpPost]
    public async Task<ActionResult<FacilitySummaryDto>> CreateFacility(
        FacilityCreateDto dto,
        CancellationToken cancellationToken
    )
    {
        var facility = new Facility
        {
            Name = dto.Name,
            Code = dto.Code,
            Address = dto.Address,
            Timezone = dto.Timezone,
        };

        _dbContext.Facilities.Add(facility);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var summary = new FacilitySummaryDto(facility.Id, facility.Name, facility.Code, facility.Address, facility.Timezone);
        return CreatedAtAction(nameof(GetFacility), new { id = facility.Id }, summary);
    }
}
