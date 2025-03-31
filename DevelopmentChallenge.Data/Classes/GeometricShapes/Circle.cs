using System;

namespace DevelopmentChallenge.Data.Classes.GeometricShapes
{
    public sealed class Circle : GeometricShape
    {
        public decimal Ray { get; private set; }

        public Circle(decimal lado) =>
            Ray = lado;

        public override void CalculateArea() =>
            Area = (decimal)Math.PI * (Ray * Ray);

        public override void CalculatePerimeter() =>
            Perimeter = 2 * (decimal)Math.PI * Ray;
    }
}