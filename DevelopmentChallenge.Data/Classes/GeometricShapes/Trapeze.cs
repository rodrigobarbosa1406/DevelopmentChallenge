namespace DevelopmentChallenge.Data.Classes.GeometricShapes
{
    public sealed class Trapeze : GeometricShape
    {
        public decimal LargerBase { get; private set; }
        public decimal SmallerBase { get; private set; }
        public decimal Height { get; private set; }
        public decimal Side1 { get; private set; }
        public decimal Side2 { get; private set; }

        public Trapeze(decimal largerBase, decimal smallerBase, decimal height, decimal side1, decimal side2)
        {
            LargerBase = largerBase;
            SmallerBase = smallerBase;
            Height = height;
            Side1 = side1;
            Side2 = side2;
        }

        public override void CalculateArea() =>
            Area = ((LargerBase + SmallerBase) * Height) / 2;

        public override void CalculatePerimeter() =>
            Perimeter = LargerBase + SmallerBase + Side1 + Side2;
    }
}