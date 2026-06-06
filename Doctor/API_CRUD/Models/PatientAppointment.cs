using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_CRUD.Models
{
    public class PatientAppointment
    {
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
}