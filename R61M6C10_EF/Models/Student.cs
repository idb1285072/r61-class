using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace R61M6C10_EF.Models
{
    public class Student
    {
        public int ID { get; set; }
        [StringLength(20)]
        [Required]
        public string LastName { get; set; }
        [StringLength(20,ErrorMessage ="Please provide Mid name within 20 characters.")]
        [Column("FirstName")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime EnrollmentDate { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {

                return $"{FirstMidName},{LastName}";
            }
        }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}