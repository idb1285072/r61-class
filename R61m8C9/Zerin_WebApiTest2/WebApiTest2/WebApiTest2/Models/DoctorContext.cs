using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiTest2.Models
{
    public class DoctorContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DoctorDegree> DoctorDegrees { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<PatientAppointment> PatientAppointments { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Designation> Designations { get; set; }
    }
    public class Doctor
    {
       
        public int ID { get; set; }
        public string Name { get; set; }
       // public string Degree { get; set; }
        public string Image { get; set; }
        public string InstituteName { get; set; }
        public string BMDCno { get; set; }
        [DataType(DataType.Date)]
        public DateTime EntryDAte { get; set; }
        public bool Status { get; set; }
        
        public Double Salary { get; set; }
        [ForeignKey("Designation")]
        public int DesignationID { get; set; }

        public Designation designation { get; set; }
        [ForeignKey("Institute")]
        public int InstituteID { get; set; }
        public Institute Institute { get; set; }
        public Designation Designation { get; set; }
    }

    public enum Type {Public=1,Private,Autonomous};
    
    public class Patient
    {
     
        public int ID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Contact { get; set; }
            public string Address { get; set; }
            public string Picture { get; set; }

    }

    public class DoctorDegree
    {
        public int ID { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        [ForeignKey("Degree")]
        public int DegreeId { get; set; }
        public string Institute {  get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public Degree Degree { get; set; }
        public Doctor Doctor { get; set; }
    }

    public class Institute
    {
         
        public int ID { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public Type Type { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
    }

    public class PatientAppointment
    {
       
        public int ID { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public bool Isvisited { get; set; }
        public double DoctorFee { get; set; }
        [ForeignKey("Institute")]
        public int InsTituteID { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public Institute Institute { get; set; }
    }

    public class Degree
    {
      
        public int ID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime AchievementDate { get; set; }
     }

    public class Designation
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
    }

    }