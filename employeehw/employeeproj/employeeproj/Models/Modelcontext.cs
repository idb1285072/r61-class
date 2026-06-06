using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace employeeproj.Models
{
    public class Modelcontext:DbContext
    {
        public Modelcontext(DbContextOptions<Modelcontext>op):base(op) { }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Details> Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTask>().HasData
                (
                    new EmployeeTask { Id = 1, TaskName = "MVC" },
                    new EmployeeTask { Id = 2, TaskName = "API" },
                    new EmployeeTask { Id = 3, TaskName = "React" },
                    new EmployeeTask { Id = 4, TaskName = "Angular" },
                    new EmployeeTask { Id = 5, TaskName = "MAUI" }
                );
        }
    }

    public class EmployeeTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        
    }

    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Picture { get; set; }
        public string PhoneNo { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        public bool MaritalStatus { get; set; }
        
        public List<Details> Details { get; set; }=new List<Details>();
    }

   
    public class Details
    {
        public int Id { get; set; }
        [ForeignKey(nameof(EmployeeTask))]
        public int EmployeeTaskId { get; set; }
        [ForeignKey(nameof(Employee))]
        public int EmployeeId   { get; set; }

        [DataType(DataType.Date)]
        public DateTime AssignDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime SubmitDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ActualSubmitDate { get; set; }
        public bool Status { get; set; }
        public string Notes { get; set; }
        [ValidateNever]
        public EmployeeTask EmployeeTask { get; set; }
        [ValidateNever]
        public Employee Employee { get; set; }
    }
}
