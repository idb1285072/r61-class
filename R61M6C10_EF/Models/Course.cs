using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace R61M6C10_EF.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        
        [Display(Name = "Course Code")]
        public int CourseID { get; set; }
        [MinLength(5),MaxLength(15)]
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
      
    }
}