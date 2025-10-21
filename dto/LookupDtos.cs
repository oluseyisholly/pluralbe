using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Dtos;

public record FacilityCreateDto(
    [property: Required, MaxLength(150)] string Name,
    [property: Required, MaxLength(50)] string Code,
    [property: MaxLength(200)] string? Address,
    [property: Required, MaxLength(100)] string Timezone
);

public record FacilitySummaryDto(int Id, string Name, string Code, string? Address, string Timezone);

public record ClinicCreateDto(
    [property: Required, MaxLength(150)] string Name,
    [property: Required, MaxLength(50)] string Code,
    [property: Required] int FacilityId
);

public record ClinicSummaryDto(int Id, string Name, string Code, int FacilityId, string FacilityName);

public record AppointmentTypeCreateDto(
    [property: Required, MaxLength(120)] string Name,
    [property: MaxLength(250)] string? Description,
    [property: Range(15, 480)] int DefaultDurationMinutes
);

public record AppointmentTypeSummaryDto(int Id, string Name, string? Description, int DefaultDurationMinutes);
