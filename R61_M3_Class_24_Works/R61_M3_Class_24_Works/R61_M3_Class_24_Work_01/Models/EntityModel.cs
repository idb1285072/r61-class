using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_24_Work_01.Models
{
    public abstract class Worker
    {
        public Worker() { }
        public Worker(int id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }

        public int Id {  get; set; }
        public string Name { get; set; } = default!;
        public string Phone {  get; set; }=default!;
       
    }
    public class FixedPayWorker : Worker
    {
        public FixedPayWorker() { }
        public FixedPayWorker(int id, string name, string phone,decimal salary, decimal mealAllowance):base(id, name, phone)
        {
            Salary = salary;
            MealAllowance = mealAllowance;
        }

        public decimal Salary { get; set; }
        public decimal MealAllowance { get; set; }
        public override string ToString()
        {
            return $"{Name}, {Phone}";
        }
    }
    public class HourlyPaidWorker : Worker
    {
        public HourlyPaidWorker() { }
        public HourlyPaidWorker (int id, string name, string phone, decimal payRate, int workHourPerDay):base(id, name, phone)
        {
            this.PayRate = payRate;
            this.WorkHourPerDay = workHourPerDay;
        }
        public decimal PayRate { get; set; }
        public int WorkHourPerDay {  get; set; }

        public override string ToString()
        {
            return $"{Name}, {Phone}";
        }
    }
}
