using R61_M3_Class_21_Work_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_21_Work_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal a = new Animal {  Name="Tiger", Age=5, Gender=Gender.Male, Type= AnimalType.Carnivore };
            GenericBehavior<Animal> gh = new GenericBehavior<Animal>();
            Console.WriteLine(gh.GetBahivior<Animal>(a));
            SpecificBehavior<Animal> sh = new SpecificBehavior<Animal>();
            Console.WriteLine(sh.GetBehavior<Animal>(a));
            Console.ReadLine();
        }
    }
}
