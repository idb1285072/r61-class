using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static R61_M3_Class_13_Work_02.Program;

namespace R61_M3_Class_13_Work_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] people = {
                new Person{ Name="Abul", Contact="01710XXXXXX", Address="Mirpur, Dhaka"},
                new Person{ Name="Babaul", Contact="01710XXXXXX", Address="Mirpur, Dhaka"},
                 new Person{ Name="Kabul", Contact="01710XXXXXX", Address="Mirpur, Dhaka"},
            };
            PrintUtil<Person> util = new PrintUtil<Person>();
            foreach (Person person in people)
            {
                util.PrintInfo(person);
            }
            Console.ReadLine();
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Info()
        {
            return $"{Name}, {Contact}\n{Address}";
        }
    }
    public class PrintUtil <T>  where T : Person, new()
    {
        public void PrintInfo(T obj)
        {
            Console.WriteLine(obj.Info());

        }
    }
}
