using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindboxMathLib
{
    public class Triangle : IShape
    {
        private readonly double _aSide;
        private readonly double _bSide;
        private readonly double _cSide;

        private double? _area;

        public Triangle(double aSide, double bSide, double cSide)
        {
            if (aSide <= 0 || bSide <= 0 || cSide <= 0)
            {
                throw new ArgumentException("Sides can't be less or equal to 0");
            }

            if (aSide + bSide <= cSide || aSide + cSide <= bSide ||
                cSide + bSide <= aSide)
            {
                throw new ArgumentException("This triangle is invalid");
            }

            _aSide = aSide;
            _bSide = bSide;
            _cSide = cSide;
        }

        public double GetArea(int digits = 2)
        {
            if (_area != null)
            {
                return (double)_area;
            }

            var s = (_aSide + _bSide + _cSide) / 2.0;

            _area = Math.Round(Math.Sqrt(s * (s - _aSide) * (s - _bSide) * (s - _cSide)), digits);

            return (double)_area;
        }

        public bool IsRightAngled()
        {
            var values = new[] { _aSide, _cSide, _bSide };
            Array.Sort(values);

            return Math.Abs(Math.Pow(values[2], 2) - (Math.Pow(values[0], 2) + Math.Pow(values[1], 2))) < 0.01;
        }
    }
}
