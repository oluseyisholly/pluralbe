using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Models;

public class Appointment : BaseEntity
{
    [Required]
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    [Required]
    public int ClinicId { get; set; }
    public Clinic Clinic { get; set; } = null!;

    [Required]
    public int AppointmentTypeId { get; set; }
    public AppointmentType AppointmentType { get; set; } = null!;

    [Required]
    public DateOnly AppointmentDate { get; set; }

    [Required]
    public TimeOnly StartTime { get; set; }

    [Range(15, 480)]
    public int DurationMinutes { get; set; }

    [Required]
    [MaxLength(40)]
    public string Status { get; set; } = "Scheduled";

    [MaxLength(500)]
    public string? Notes { get; set; }

    public DateTime StartDateTimeUtc(string timezone)
    {
        var dateTime = AppointmentDate.ToDateTime(StartTime);
        return TimeZoneInfo.ConvertTimeToUtc(dateTime, TimeZoneInfo.FindSystemTimeZoneById(timezone));
    }
}
