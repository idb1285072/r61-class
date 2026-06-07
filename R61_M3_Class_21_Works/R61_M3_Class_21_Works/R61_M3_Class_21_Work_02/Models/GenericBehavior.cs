using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_21_Work_02.Models
{
    public class GenericBehavior<T> : IGenericBehavior<T>
    {
        public string GetBahivior<T1>(T1 obj)
        {
            if(obj is Animal)
            {
                Animal a = obj as Animal;
                switch (a.Type)
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
            else
            {
                return "Not an animal";
            }
        }
    }
}
