namespace R61_M3_Class_14_Work_01.Models
{
    public abstract class Vehicle
    {
        public Vehicle(){}
        public Vehicle(string modelNo, int yearMake, VehicleType vehicleType)
        {
            this.ModelNo=modelNo;
            this.YearMake = yearMake;
            this.VehicleType=vehicleType;
        }
        public string ModelNo {get;set;}
        public int YearMake {get;set;}
        public VehicleType VehicleType {get;set;}
        public abstract string Details();
    }
}