using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_21_Work_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle { Radius = 4.5 };
            Circle c2 = new Circle { Radius = 3.5 };
            Console.WriteLine(c1);
            Console.WriteLine(c2); 
            Circle bigOne = c1+c2;
            Console.WriteLine(bigOne);
            Circle smallOne = c1-c2;
            Console.WriteLine(smallOne);
            Console.WriteLine(c1==c2);
            Console.WriteLine(c2!=c1);
            Console.WriteLine(c1 > c2);
            Console.WriteLine(c1 < c2);
            c1++;
            Console.WriteLine(c1);
            --c2;
            Console.WriteLine(c2);
            double d = (double)c2;
            Console.WriteLine(d);
            Console.ReadLine();
        }
    }
    public class Circle
    {
        public double Radius { get; set; }
       
        public override string ToString()
        {
            return $"{Radius}R Circle";
        }
        public static Circle operator +(Circle left, Circle right)
        {
            return new Circle { Radius = left.Radius + right.Radius };
        }
        public static Circle operator -(Circle left, Circle right)
        {
            return new Circle { Radius = Math.Abs(left.Radius - right.Radius) };
        }
        public static bool operator ==(Circle left, Circle right)
        {
            return left.Radius == right.Radius;
        }
        public static bool operator !=(Circle left, Circle right)
        {
            return left.Radius != right.Radius;
        }
        public static bool operator >(Circle left, Circle right)
        {
            return left.Radius > right.Radius;
        }
        public static bool operator <(Circle left, Circle right)
        {
            return left.Radius < right.Radius;
        }
        public static Circle operator ++(Circle c)
        {
            return new Circle { Radius = c.Radius + 1 };
        }
        public static Circle operator --(Circle c)
        {
            return new Circle { Radius = c.Radius - 1 };
        }
        public static  implicit operator double(Circle c)
        {
            return c.Radius;
        }
    }
}
