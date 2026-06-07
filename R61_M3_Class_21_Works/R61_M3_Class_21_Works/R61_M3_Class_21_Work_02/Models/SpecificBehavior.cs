using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_21_Work_02.Models
{
    public class SpecificBehavior<T> : ISpecificBehavior<T>
    {
        public string GetBehavior<T1>(T1 obj) where T1 : Animal
        {
            switch (obj.Type)
            {
                case AnimalType.Harvivore:
                    return "Plant eaters, has compartmental stomach";
                case AnimalType.Carnivore:
                    return "Meat eaters, prey animal, has canine";
                case AnimalType.Omnivore:
                    return "Versatile eating behavior, most adaptive";
                default:
                    return "Unknown type";
            }
        }
    }
}
