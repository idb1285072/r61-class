using employeeproj.Models;
using System.ComponentModel.DataAnnotations;

namespace employeeproj.ViewModel
{
    public class EmployeeVM
    {
        public int Id { get; set; }

        public string EmployeeName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string PhoneNo { get; set; }
        public bool MaritalStatus { get; set; }
        public List<EmployeeTaskVM> EmployeeTasks { get; set; }
    }
}
