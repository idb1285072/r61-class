using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_12_Work_03.Models
{
    public abstract class Person
    {
       public Person() { }
        public Person(string name, DateTime dateOfBirth) 
        { 
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
        }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public abstract int Age();
    }
}
