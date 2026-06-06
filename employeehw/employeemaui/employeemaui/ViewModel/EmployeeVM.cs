using employeemaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeemaui.ViewModel
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Picture { get; set; }
        public string PhoneNo { get; set; }
        public DateTime Birthdate { get; set; }
        public bool MaritalStatus { get; set; }
        public List<EmployeeTask> EmployeeTasks { get; set; }=new List<EmployeeTask>();
        public List<Details> Details { get; set; } = new();
    }
}
