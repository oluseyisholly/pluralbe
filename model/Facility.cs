using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Models;

public class Facility : BaseEntity
{
    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Code { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? Address { get; set; }

    public ICollection<Clinic> Clinics { get; set; } = new List<Clinic>();
    public ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
