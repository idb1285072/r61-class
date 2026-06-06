using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mastercrud.Models
{
    public class DbModel
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

            // A Patient can have many Appointments
            public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

           
        }

        public class Appointment
        {
            public int Id { get; set; }

            [Required, StringLength(50)]
            public string Location { get; set; }

            [Required, DataType(DataType.Currency)]
            public decimal Fee { get; set; }

            // Foreign keys to Patient and Doctor
            [Required, ForeignKey(nameof(Patient))]
            public int PatientId { get; set; }

            [Required, ForeignKey(nameof(Doctor))]
            public int DoctorId { get; set; }

            // Navigation properties
            public virtual Patient Patient { get; set; }
            public virtual Doctor Doctor { get; set; }
        }

        public class Doctor
        {
            public int Id { get; set; }

            [Required, StringLength(50)]
            public string Name { get; set; }

            // A Doctor can have many Appointments
            public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
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
}
