using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using R61M6C10_EF.Models;

namespace R61M6C10_EF.ViewModels
{
    public class InstructorIndexData
    {
        public string name { get; set; }
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}