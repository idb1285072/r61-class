
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_09_Work_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle();
            rect.Length = 10;
            rect.Width = 5.5;
            Console.WriteLine(rect.GetArea());
            Console.WriteLine();
            Rectangle rect2 = new Rectangle { Length = 7.5, Width = 2.5 };
            Console.WriteLine(rect2.GetArea());
            Console.WriteLine();
            Circle circle = new Circle { Radius = 3.5 };
            Console.WriteLine(circle.GetArea());
            Console.WriteLine($"{circle.Circumference():0.00}");
            Console.ReadLine();
        }
    }//Program
    #region Rectangle
    public class Rectangle
    {
        private double _length;
        private double _width;
        public double Length
        {
            get
            {
                return _length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid length");
                }
                else
                {
                    _length = value;
                }
            }
        }
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid width");
                }
                else
                {
                    _width = value;
                }
            }
        }
        public double GetArea()
        {
            return this._length * this._width;
        }
        public double Circumfrence()
        {
            return 2 * (this.Length + this.Width);
        }
    }//Rectangle
    #endregion
    #region Circle
    public class Circle
    {
        private double _radius;
        public double Radius
        {
            get { return _radius; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Radius must be non-zero +ve number");
                else _radius = value;
            }
        }
        public double GetArea()
        {
            return Math.PI * _radius * _radius;
        }
        public double Circumference()
        {
            return 2 * Math.PI * _radius;
        }
    }//Circle
    #endregion
}
