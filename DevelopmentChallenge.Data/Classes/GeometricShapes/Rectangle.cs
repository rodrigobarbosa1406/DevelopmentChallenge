namespace DevelopmentChallenge.Data.Classes.GeometricShapes
{
    public sealed class Rectangle : GeometricShape
    {
        public decimal Base { get; private set; }
        public decimal Height { get; private set; }

        public Rectangle(decimal @base, decimal altura)
        {
            Base = @base;
            Height = altura;
        }

        public override void CalculateArea() =>
            Area = Base * Height;

        public override void CalculatePerimeter() =>
            Perimeter = 2 * (Base + Height);
    }
}