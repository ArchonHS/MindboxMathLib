using MindboxMathLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace MindboxMathLib_Tests
{
    public class CircleTests
    {
        [Fact]
        public void CircleRadiusCantBeLessOrEqualToZero()
        {
            Assert.Throws<ArgumentException>(() => new Circle(-1));

            Assert.Throws<ArgumentException>(() => new Circle(0));
        }

        [Theory]
        [InlineData(2, 12.57)]
        [InlineData(5, 78.54)]
        [InlineData(7.5, 176.71)]
        [InlineData(10, 314.16)]
        [InlineData(1.25, 4.91)]
        public void GetCircleArea(double radius, double expected)
        {
            IShape circle = new Circle(radius);

            double area = circle.GetArea();

            Assert.Equal(expected, area);
        }

        [Theory]
        [InlineData(2, 12.566, 3)] 
        [InlineData(5, 78.5398, 4)] 
        [InlineData(7.5, 176.71459, 5)] 
        [InlineData(10, 314.15927, 5)] 
        [InlineData(1.25, 4.909, 3)] 
        public void GetCircleAreaOverloaded(double radius, double expected, int digits)
        {
            IShape circle = new Circle(radius);

            double area = circle.GetArea(digits);

            Assert.Equal(expected, area, digits);
        }
    }
}
