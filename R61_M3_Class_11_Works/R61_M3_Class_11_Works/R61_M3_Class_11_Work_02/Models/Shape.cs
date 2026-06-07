using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_11_Work_02.Models
{
    public interface IShape
    {
        double Area();
    }
    public class Rectangle : IShape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public double Area()
        {
            return Length * Width;
        }



        public override string ToString()
        {
            return $"{Length}X{Width} Rectangle";
        }
    }
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public override string ToString()
        {
            return $"{Radius}r Circle";
        }
    }
    public class Triangle : IShape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public double Area()
        {
            double s = (A + B + C) / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }
        public override string ToString()
        {
            return $"{A}X{B}X{C} Triangle";
        }
    }
}
