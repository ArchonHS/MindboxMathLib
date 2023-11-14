using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindboxMathLib
{
    public class Circle : IShape
    {
        private readonly double _radius;

        private double? _area;

        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius can't be less or equal to 0");
            }
            _radius = radius;
        }

        public double GetArea(int digits = 2)
        {
            if (_area != null)
            {
                return (double)_area;
            }
            _area = Math.Round(Math.PI * Math.Pow(_radius, 2), digits);
            return (double)_area;
        }
    }
}
