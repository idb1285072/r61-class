using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeemaui.Models
{
    public class Details
    {
        public int Id { get; set; }
    
        public int EmployeeTaskId { get; set; }
       
        public int EmployeeId { get; set; }

       
        public DateTime AssignDate { get; set; }
       
        public DateTime SubmitDate { get; set; }
        
        public DateTime ActualSubmitDate { get; set; }
        public bool Status { get; set; }
        public string Notes { get; set; }
        public EmployeeTask EmployeeTask { get; set; }
        public Employee Employee { get; set; }
    }
}
