using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_14_Work_01.Models
{
    public sealed class Car : FourWheeler
    {
        public Car() { }
        public Car(string modelNo, int yearMake, VehicleType vehicleType, int numberOfGear, int cc, int numberOfDoors):base(modelNo, yearMake, vehicleType, numberOfGear, cc)
        { 
            this.NumberOfDoors = numberOfDoors;
        }
        public int NumberOfDoors {  get; set; }
        public override string Details()
        {
            return $"{base.Details()}, {NumberOfDoors} doors";
        }
    }
}
