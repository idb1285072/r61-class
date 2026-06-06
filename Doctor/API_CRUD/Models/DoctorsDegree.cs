using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_CRUD.Models
{
    public class DoctorsDegree
    {
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