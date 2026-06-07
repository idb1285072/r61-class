namespace R61_M3_Class_14_Work_01.Models
{
    public sealed class MotorCycle : TwoWheeler
    {
        public MotorCycle() { }
        public MotorCycle(string modelNo, int yearMake, VehicleType vehicleType, int numberOfGear, int cc, double milage, string frontBrake, string rearBrake): base(modelNo, yearMake, vehicleType, numberOfGear, cc)
        {
            this.Milage = milage;
            this.FrontBrake = frontBrake;
            this.RearBrake = rearBrake;
        }
        public double Milage { get; set; }
        public string FrontBrake { get; set; }
        public string RearBrake {  get; set; }
        public override string Details()
        {
            return $"{base.Details()}\n{Milage} KMPL,{FrontBrake}, {RearBrake}";
        }
    }
}