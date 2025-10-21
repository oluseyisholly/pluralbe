using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Dtos;

public record PatientCreateDto(
    [property: Required, MaxLength(100)] string FirstName,
    [property: MaxLength(100)] string? MiddleName,
    [property: Required, MaxLength(100)] string LastName,
    [property: Required, MaxLength(20)] string Gender,
    [property: Required] DateOnly DateOfBirth,
    [property: Required, Phone, MaxLength(20)] string PrimaryPhone,
    [property: EmailAddress, MaxLength(150)] string? Email,
    [property: MaxLength(250)] string? ContactAddress,
    [property: Required] int FacilityId
);

public record PatientSummaryDto(
    int Id,
    string FullName,
    string Gender,
    DateOnly DateOfBirth,
    string PrimaryPhone,
    string? Email,
    int FacilityId,
    string FacilityName
);
