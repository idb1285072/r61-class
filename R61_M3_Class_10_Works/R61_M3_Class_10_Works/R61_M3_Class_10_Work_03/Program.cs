using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_10_Work_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point();
            p1.X = 3;
            p1.Y = 4;
            Point p2 = new Point(-3, -4);
            Console.WriteLine($"Distance={p1.Distance(p2)}");
            Console.WriteLine($"Distance={p1.Distance(0,0)}");
            Console.ReadLine();
            
        }
    }//Program
    public struct Point
    {
        public Point( double x, double y)
        {
            this.X= x; 
            this.Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
        public double Distance (double x, double y)
        {
            return Math.Sqrt((this.X - x)*(this.X - x)+(this.Y-y)*(this.Y-y));
        }
        public double Distance(Point p)
        {
            return Math.Sqrt((this.X - p.X) * (this.X - p.X) + (this.Y - p.Y) * (this.Y - p.Y));
        }
    }
}
