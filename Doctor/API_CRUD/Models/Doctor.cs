using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_CRUD.Models
{
    public class Doctor
    {
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
}