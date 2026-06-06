using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace R61M6C5_Security.Models
{
    public class Employee
    {
        //Scalar
        public int Id { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage ="Please provide Name")]
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public double Salary { get; set; }
        public bool Iscontinued { get; set; }
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }

        //Navigation property
        public virtual Department Department { get; set; }
    }

}