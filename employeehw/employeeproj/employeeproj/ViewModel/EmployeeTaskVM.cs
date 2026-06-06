using employeeproj.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace employeeproj.ViewModel
{
    public class EmployeeTaskVM
    {
        public int Id { get; set; }
        public int EmployeeTaskId { get; set; }
       
        public int EmployeeId { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime ActualSubmitDate { get; set; }
        public bool Status { get; set; }
        public string Notes { get; set; }

    }
}
