using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Dtos
{
    // ✅ Input DTO: Use class for binding and validation
    public class FacilityCreateDto
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Code { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Address { get; set; }
    }

    // ✅ Output DTO: record is fine for responses
    public record FacilitySummaryDto(int Id, string Name, string Code, string? Address);

    // ✅ Input DTO: Use class for validation and model binding
    public class ClinicCreateDto
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Code { get; set; } = string.Empty;

        [Required]
        public int FacilityId { get; set; }
    }

    // ✅ Output DTO
    public record ClinicSummaryDto(
        int Id,
        string Name,
        string Code,
        int FacilityId,
        string FacilityName
    );

    // ✅ Input DTO
    public class AppointmentTypeCreateDto
    {
        [Required]
        [MaxLength(120)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Description { get; set; }

        [Required]
        [Range(15, 480)]
        public int DefaultDurationMinutes { get; set; }
    }

    // ✅ Output DTO
    public record AppointmentTypeSummaryDto(
        int Id,
        string Name,
        string? Description,
        int DefaultDurationMinutes
    );
}
