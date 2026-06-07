using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_24_Work_01.Models
{
    public class SalaryImpl : ISalary
    {
        public decimal CalculateSalary<T>(T worker) where T : Worker
        {
            if(worker is FixedPayWorker)
            {
                var w = worker as FixedPayWorker;
                return w == null ? 0 : w.Salary + w.MealAllowance * 30;
            }
            else
            {
                var w = (worker as HourlyPaidWorker);
                return w == null ? 0: w.WorkHourPerDay*w.PayRate*30;
            }
        }
    }
}
