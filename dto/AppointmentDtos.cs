using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Dtos
{
    public class AppointmentCreateDto
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public int ClinicId { get; set; }

        [Required]
        public int AppointmentTypeId { get; set; }

        [Required]
        public DateOnly AppointmentDate { get; set; }

        [Required]
        public TimeOnly StartTime { get; set; }

        [Range(15, 480)]
        public int? DurationMinutes { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }
    }

    public class AppointmentSummaryDto
    {
        public int Id { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public int DurationMinutes { get; set; }
        public string Status { get; set; } = string.Empty;
        public string ClinicName { get; set; } = string.Empty;
        public string FacilityName { get; set; } = string.Empty;
        public string AppointmentType { get; set; } = string.Empty;
        public string AppointmentTypeName { get; set; } = string.Empty;

        public string PatientName { get; set; } = string.Empty;
    }
}
