using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_10_Work_02.Models
{
    public abstract class Shape
    {
        public abstract double Area();
    }
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public override double Area()
        {
            return Length * Width;
        }
    }
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double Area()
        {
            return Math.PI*Radius*Radius;
        }
    }
    public class Triangle : Shape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public override double Area()
        {
            double s = (A + B + C) / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }
    }
}
