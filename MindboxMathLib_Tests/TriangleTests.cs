using MindboxMathLib;
using Xunit.Abstractions;

namespace MindboxMathLib_Tests
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(1, 3, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(-1, -1, -1)]
        public void TriangleSidesCantBeLessOrEqualToZero(double aSide, double bSide, double cSide)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(aSide, bSide, cSide));
        }

        [Theory]
        [InlineData(1, 1, 3)]
        [InlineData(4, 5, 10)]
        [InlineData(8, 15, 7)]
        [InlineData(6, 10, 25)]
        [InlineData(14, 7, 6)]
        public void NotValidTriangle(double aSide, double bSide, double cSide)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(aSide, bSide, cSide));
        }

        [Theory]
        [InlineData(3, 4, 5, 6)] 
        [InlineData(5, 12, 13, 30)] 
        [InlineData(8, 15, 17, 60)] 
        public void GetTriangleArea(double sideA, double sideB, double sideC, double expectedArea)
        {
            IShape triangle = new Triangle(sideA, sideB, sideC);

            double area = triangle.GetArea();

            Assert.Equal(expectedArea, area, 2); 
        }

        [Theory]
        [InlineData(3, 4, 5, 4, 6)] 
        [InlineData(5, 12, 13, 3, 30)] 
        [InlineData(8, 15, 17, 5, 60)] 
        public void GetTriangleAreaOverloaded(double sideA, double sideB, double sideC, int digits, double expectedArea)
        {
            IShape triangle = new Triangle(sideA, sideB, sideC);

            double area = triangle.GetArea(digits);

            Assert.Equal(expectedArea, area, digits); 
        }


        [Theory]
        [InlineData(3, 4, 5)] 
        [InlineData(5, 12, 13)] 
        [InlineData(8, 15, 17)] 
        [InlineData(7, 24, 25)] 
        [InlineData(9, 40, 41)]
        public void IsRightAngledTrue(double aSide, double bSide, double cSide)
        {
            IShape triangle = new Triangle(aSide, bSide, cSide);

            var castedTriangle = Assert.IsType<Triangle>(triangle);

            Assert.True(castedTriangle.IsRightAngled());
        }

        [Theory]
        [InlineData(3, 4, 6)] 
        [InlineData(5, 8, 10)] 
        [InlineData(7, 15, 20)] 
        [InlineData(6, 7, 10)] 
        [InlineData(9, 12, 16)] 
        public void IsRightAngledFalse(double aSide, double bSide, double cSide)
        {
            IShape triangle = new Triangle(aSide, bSide, cSide);

            var castedTriangle = Assert.IsType<Triangle>(triangle);

            Assert.False(castedTriangle.IsRightAngled());
        }
    }
}