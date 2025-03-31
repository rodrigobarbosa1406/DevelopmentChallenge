using System;

namespace DevelopmentChallenge.Data.Classes.GeometricShapes
{
    public sealed class EquilateralTriangle : GeometricShape
    {
        public decimal Side { get; private set; }

        public EquilateralTriangle(decimal lado) =>
            Side = lado;

        public override void CalculateArea() =>
            Area = ((decimal)Math.Sqrt(3) / 4) * Side * Side;

        public override void CalculatePerimeter() =>
            Perimeter = Side * 3;
    }
}