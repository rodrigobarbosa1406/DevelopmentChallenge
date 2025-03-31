namespace DevelopmentChallenge.Data.Classes.GeometricShapes
{
    public sealed class Square : GeometricShape
    {
        public decimal Side { get; private set; }

        public Square(decimal lado) =>
            Side = lado;

        public override void CalculateArea() =>
            Area = Side * Side;

        public override void CalculatePerimeter() =>
            Perimeter = Side * 4;
    }
}