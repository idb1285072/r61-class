using R61_M3_Class_12_Work_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_12_Work_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee { Id = 1, Name="E1", DateOfBirth=new DateTime(1999, 7, 12),JoinDate=DateTime.Parse("2021-01-01"), Grade=Grade.M1  };
            e1.AddRoles("Report Generation", "Create Surveys", "Analyse Suvers");
            Console.WriteLine(e1);
            Console.ReadLine();
        }
    }
}
