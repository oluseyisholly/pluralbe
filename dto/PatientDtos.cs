using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Dtos
{
    // ✅ Input DTO: Use class for proper validation and model binding
    public class PatientCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? MiddleName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Gender { get; set; } = string.Empty;

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        [Phone]
        [MaxLength(20)]
        public string PrimaryPhone { get; set; } = string.Empty;

        [EmailAddress]
        [MaxLength(150)]
        public string? Email { get; set; }

        [MaxLength(250)]
        public string? ContactAddress { get; set; }

        [Required]
        public int FacilityId { get; set; }
    }

    // ✅ Output DTO: Use record for read-only API responses
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
}
