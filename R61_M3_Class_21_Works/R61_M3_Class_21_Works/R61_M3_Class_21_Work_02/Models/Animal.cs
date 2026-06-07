using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_21_Work_02.Models
{
    public enum AnimalType { Harvivore=1, Carnivore, Omnivore}
    public enum Gender { Male=1, Female}
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public AnimalType Type { get; set; }
        public Gender Gender { get; set; }
    }
}
