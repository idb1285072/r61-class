using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_12_Work_03.Models
{
    public sealed class Employee : Person, IRole
    {
        private string[] roles;
        public Employee() { }
        public Employee(int id, string name, DateTime dateOfBirth, DateTime joinDate, Grade grade) : base(name, dateOfBirth)
        { 
            this.Id = id;
            this.JoinDate = joinDate;
            this.Grade = grade;
        }
        public int Id { get; set; }
        public DateTime JoinDate { get; set; }
        public Grade Grade { get; set; }
        public override int Age()
        {
            return (DateTime.Now - DateOfBirth).Days / 365;
        }
        public void AddRoles(params string[] roles)
        {
            this.roles = roles;
        }

        public string GetRoles()
        {
            return string.Join(", ", roles);
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Joined On: {JoinDate:yyyy-MM-dd}, Grade: {Grade}, Age: {Age()}" +
                $"\nRole plays:\n {GetRoles()}";
        }
    }
}
