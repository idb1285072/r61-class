using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace apicrud1.Models
{
    public enum Type { Public, Private };
    public class modelcontext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<PatientAppointment> PatientAppointments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<DoctorsDegree> DoctorsDegrees { get; set; }

    }
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Designation))]
        public int DesignationId { get; set; }
        public string Name { get; set; }
        public string DoctorDesignation { get; set; }
        public string Picture { get; set; }
        public string InstituteName { get; set; }
        public string RegNo { get; set; }
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }
        public string DoctorDegree { get; set; }
        public double Salary { get; set; }
        public bool IsActive { get; set; }
        public Designation Designation { get; set; }
        public virtual ICollection<PatientAppointment> PatientAppointments { get; set; }
        public virtual ICollection<DoctorsDegree> DoctorsDegrees { get; set; }
    }
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Picture { get; set; }
        public virtual ICollection<PatientAppointment> Appointments { get; set; }

    }
    public class Institute
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public Type Type { get; set; }
        public string Logo { get; set; }
    }
    public class PatientAppointment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public bool IsVisited { get; set; }
        public double DoctorFee { get; set; }
        public int InstituteId { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }


    }
    public class Designation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
    public class Degree
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DoctorsDegree> DoctorsDegrees { get; set; }
    }
    public class DoctorsDegree
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        [ForeignKey(nameof(Degree))]
        public int DegreeId { get; set; }
        public string InstituteName { get; set; }
        [DataType(DataType.Date)]
        public DateTime AchievementDate { get; set; }
        public string Grade { get; set; }
        public Doctor Doctor { get; set; }
        public Degree Degree { get; set; }
    }
}