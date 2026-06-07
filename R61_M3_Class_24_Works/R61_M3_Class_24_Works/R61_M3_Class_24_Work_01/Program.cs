// See https://aka.ms/new-console-template for more information
using R61_M3_Class_24_Work_01.Models;

Worker[] workers= new Worker[]
{
    new FixedPayWorker(1, "FIX1", "01987XXXXXX",22000, 150),
    new FixedPayWorker(2, "FIX2", "01987XXXXXX",20000, 150),
    new HourlyPaidWorker(3, "HP1", "N/A", 1200, 8),
    new HourlyPaidWorker(){ Id=4, Name="HP2", Phone="N/A", PayRate=1150, WorkHourPerDay=8}
};
SalaryImpl salary= new SalaryImpl();
foreach(Worker w in workers)
{
    Console.WriteLine(w);
    Console.WriteLine($"Salary: {salary.CalculateSalary (w)}");
}
Console.ReadLine();
