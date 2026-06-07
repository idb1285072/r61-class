using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_09_Work_03.Models
{
    public  class Perosn
    {
        public string FirstName{get; set;}
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; }  }
    }
}
