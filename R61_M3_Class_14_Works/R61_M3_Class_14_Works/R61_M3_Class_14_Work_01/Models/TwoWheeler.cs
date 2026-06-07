namespace R61_M3_Class_14_Work_01.Models
{
    public class TwoWheeler : Vehicle, IExterriorDegn
    {
        string[] features;
        public TwoWheeler(){}
        public TwoWheeler(string modelNo, int yearMake, VehicleType vehicleType, int numberOfGear, int cc): base(modelNo, yearMake, vehicleType)
        {
                this.NumberOfGear = numberOfGear;
                this.CC=cc;
        }
        public int NumberOfGear{ get;set;}
        public int CC {get;set;}

       

        public override string Details(){
            return $"{ModelNo}, {YearMake}\n{CC} cc, {NumberOfGear} gear";
        }
        public void AddExteriorFeatures(params string[] features)
        {
            this.features = features;
        }
        public string GetExteriorFeatures()
        {
            return string.Join(",", this.features);
        }
    }
}