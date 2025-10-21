using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Models;

public class AppointmentType : BaseEntity
{
    [Required]
    [MaxLength(120)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(250)]
    public string? Description { get; set; }

    public int DefaultDurationMinutes { get; set; } = 60;

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
