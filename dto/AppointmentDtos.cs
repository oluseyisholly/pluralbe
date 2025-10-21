using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Dtos;

public record AppointmentCreateDto(
    [property: Required] int PatientId,
    [property: Required] int ClinicId,
    [property: Required] int AppointmentTypeId,
    [property: Required] DateOnly AppointmentDate,
    [property: Required] TimeOnly StartTime,
    [property: Range(15, 480)] int? DurationMinutes,
    [property: MaxLength(500)] string? Notes
);

public record AppointmentSummaryDto(
    int Id,
    DateOnly AppointmentDate,
    TimeOnly StartTime,
    int DurationMinutes,
    string Status,
    string ClinicName,
    string FacilityName,
    string AppointmentType,
    string PatientName
);
