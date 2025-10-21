using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Models;

public class Clinic : BaseEntity
{
    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Code { get; set; } = string.Empty;

    public int FacilityId { get; set; }
    public Facility Facility { get; set; } = null!;

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
