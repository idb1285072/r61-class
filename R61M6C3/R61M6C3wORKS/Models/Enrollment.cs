using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace R61M6C3wORKS.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        [ForeignKey("Student")]
        public int StdId { get; set; }
        [DataType(DataType.Date),Required]

        public DateTime EnrolledDate { get; set; }
        public virtual Course Course { get; set; }
        public virtual  Student Student { get; set; }

    }
}