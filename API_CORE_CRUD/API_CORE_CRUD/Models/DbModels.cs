using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API_CORE_CRUD.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required, StringLength(50)]
        public string Picture { get; set; }
        public bool IsAdmited { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
    public class Appointment
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Location { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal Fee { get; set; }
        [Required, ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        [Required, ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
    }

    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Appointment> Doctors { get; set; } = new List<Appointment>();
    }

    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
