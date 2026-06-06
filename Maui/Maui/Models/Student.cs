using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;
        public DateTime AdmissionDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
    }
}
