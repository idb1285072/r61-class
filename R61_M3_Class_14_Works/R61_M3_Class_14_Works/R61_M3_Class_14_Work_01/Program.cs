using R61_M3_Class_14_Work_01.Models;
using R61_M3_Class_14_Work_01.Models.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_14_Work_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car() { ModelNo = "Accord v5", YearMake = 2016, VehicleType = VehicleType.Personal, CC = 3000, NumberOfGear = 4, NumberOfDoors = 4 };
            c1.AddInteriorFeatues("GPS", "Italian Leather Seat Cover");
            Console.WriteLine(c1.Details());
            Console.Write("Features: ");
            Console.WriteLine(c1.GetInteriorFeatures());
            Car c2 = new Car("Allion", 2012, VehicleType.Personal, 4, 3000, 4);
            c2.AddInteriorFeatues("A", "B", "C");
            Console.WriteLine(c2.Details());
            Console.Write("Features: ");
            Console.WriteLine(c2.GetInteriorFeatures());
            Console.WriteLine();
            MotorCycle m1 =new MotorCycle {  ModelNo="TVS", YearMake=2020, VehicleType= VehicleType.Racing, CC=1000, Milage=30, FrontBrake="Hydraulic", RearBrake="Hydraulic", NumberOfGear=6};
            m1.AddExteriorFeatures("P", "Q", "R");
            Console.WriteLine(m1.Details());
            Console.Write("Features: ");
            Console.WriteLine(m1.GetExteriorFeatures());
            MotorCycle m2 = new MotorCycle(
                "Walton", 
                2022, 
                VehicleType.Personal, 
                4, 
                125, 
                40, 
                "Hydraulic", 
                "Drum Brake");
            m2.AddExteriorFeatures("AA", "BB");
            Console.WriteLine(m2.Details());
            Console.Write("Features: ");
            Console.WriteLine(m2.GetExteriorFeatures());
            Console.WriteLine();
            //////////
            VehicleInfo vi1 = new VehicleInfo();
            Console.WriteLine(vi1.GetInfo<Car>(c1));

            Console.WriteLine(vi1.GetInfo<MotorCycle>(m1));
            Console.ReadLine();
        }
    }
}
