using API_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API_CRUD.DAL
{
    public class HospitalDbContext:DbContext
    {
            public DbSet<Doctor> Doctors { get; set; }
            public DbSet<Patient> Patients { get; set; }
            public DbSet<Institute> Institutes { get; set; }
            public DbSet<PatientAppointment> PatientAppointments { get; set; }
            public DbSet<Designation> Designations { get; set; }
            public DbSet<Degree> Degrees { get; set; }
            public DbSet<DoctorsDegree> DoctorsDegrees { get; set; }
    }
}