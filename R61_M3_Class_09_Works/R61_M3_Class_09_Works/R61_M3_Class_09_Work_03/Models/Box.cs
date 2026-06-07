using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_09_Work_03.Models
{
    public class Box
    {
        //1
        private double _length;
        private double _width;
        //3
        public Box() { }
        public Box(double l, double w) 
        { 
            this.Length = l;
            this.Width = w;
        }
        //2
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
        //4
        public double GetArea()
        {
            return this._length * this._width;
        }
        public double Circumfrence()
        {
            return 2 * (this.Length + this.Width);
        }
    }
}
