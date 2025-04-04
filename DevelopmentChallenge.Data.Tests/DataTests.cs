using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Classes.GeometricShapes;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Utils;
using NUnit.Framework;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        #region EmptyList
        [TestCase]
        public void TestSummaryEmptyList()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                Print.PrintReport(new List<GeometricShape>(), Language.CASTELLANO));
        }

        [TestCase]
        public void TestSummaryEmptyListShapesInEnglish()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                Print.PrintReport(new List<GeometricShape>(), Language.ENGLISH));
        }

        [TestCase]
        public void SummaryTestEmptyListFormsInItalian()
        {
            Assert.AreEqual("<h1>Elenco moduli vuoti!</h1>",
                Print.PrintReport(new List<GeometricShape>(), Language.ITALIAN));
        }
        #endregion EmptyList

        #region Square
        [TestCase]
        public void SummaryTestListWithASquare()
        {
            var geometricShapes = new List<GeometricShape> { new Square(5) };    //Area: 25, Perimeter: 20

            var summary = Print.PrintReport(geometricShapes, Language.CASTELLANO);

            Assert.AreEqual("<h1>Reporte de formas</h1>1 Cuadrado | Area 25,00 | Perimetro 20,00 <br/>TOTAL:<br/>1 forma Perimetro 20,00 Area 25,00", summary);
        }

        [TestCase]
        public void SummaryTestListWithMoreSquares()
        {
            var geometricShapes = new List<GeometricShape>
            {
                new Square(5),    //Area: 25, Perimeter: 20
                new Square(1),    //Area: 1, Perimeter: 4
                new Square(3)     //Area: 9, Perimeter: 12
            };
            //TOTAL: 3 -> Area: 35, Perimeter: 36

            var summary = Print.PrintReport(geometricShapes, Language.ENGLISH);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35.00 | Perimeter 36.00 <br/>TOTAL:<br/>3 shapes Perimeter 36.00 Area 35.00", summary);
        }

        [TestCase]
        public void SummaryTestListWithMoreSquaresInItalian()
        {
            var geometricShapes = new List<GeometricShape>
            {
                new Square(5),    //Area: 25, Perimeter: 20
                new Square(1),    //Area: 1, Perimeter: 4
                new Square(3)     //Area: 9, Perimeter: 12
            };
            //TOTAL: 3 -> Area: 35, Perimeter: 36

            var summary = Print.PrintReport(geometricShapes, Language.ITALIAN);

            Assert.AreEqual("<h1>Segnalazione dei moduli</h1>3 Piazze | Zona 35,00 | Perimetro 36,00 <br/>TOTALE:<br/>3 forme Perimetro 36,00 Zona 35,00", summary);
        }
        #endregion Square

        #region MoreTypes
        [TestCase]
        public void TestSummaryListWithMoreTypes()
        {
            var geometricShapes = new List<GeometricShape>
            {
                new Square(5),                    //Area: 25, Perimeter: 20
                new Circle(3),                     //Area: 28.27, Perimeter: 18.85
                new EquilateralTriangle(4),         //Area: 6.93, Perimeter: 12
                new Square(2),                    //Area: 4, Perimeter: 8
                new EquilateralTriangle(9),         //Area: 35.07, Perimeter: 27
                new Circle(2.75m),                 //Area: 23.76, Perimeter: 17.28
                new EquilateralTriangle(4.2m),      //Area: 7.64, Perimeter: 12.6
                new Rectangle(4, 2),               //Area: 8, Perimeter: 12
                new Trapeze(10, 6, 5, 4, 3)        //Area: 40, Perimeter: 23
            };
            //TOTAL_CUADRADO: 2 -> Area: 29, Perimeter: 28
            //TOTAL_CIRCULO: 2 -> Area: 52.03, Perimeter: 36,13
            //TOTAL_TRIANGULO: 3 -> Area: 49,64, Perimeter: 51,6
            //TOTAL_RECTANGULO: 1 -> Area: 8, Perimeter: 12
            //TOTAL_TRAPECIO: 1 -> Area: 40, Perimeter: 23

            //TOTAL_FINAL: 9 -> Area: 178,67, Perimeter: 150,73

            var summary = Print.PrintReport(geometricShapes, Language.ENGLISH);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29.00 | Perimeter 28.00 <br/>2 Circles | Area 52.03 | Perimeter 36.13 <br/>3 Triangles | Area 49.64 | Perimeter 51.60 <br/>1 Rectangle | Area 8.00 | Perimeter 12.00 <br/>1 Trapeze | Area 40.00 | Perimeter 23.00 <br/>TOTAL:<br/>9 shapes Perimeter 150.73 Area 178.67",
                summary);
        }

        [TestCase]
        public void TestSummaryListWithMoreTypesInCastellano()
        {
            var geometricShapes = new List<GeometricShape>
            {
                new Square(5),
                new Circle(3),
                new EquilateralTriangle(4),
                new Square(2),
                new EquilateralTriangle(9),
                new Circle(2.75m),
                new EquilateralTriangle(4.2m),
                new Rectangle(4, 2),
                new Trapeze(10, 6, 5, 4, 3)
            };

            var summary = Print.PrintReport(geometricShapes, Language.CASTELLANO);

            Assert.AreEqual(
                "<h1>Reporte de formas</h1>2 Cuadrados | Area 29,00 | Perimetro 28,00 <br/>2 Círculos | Area 52,03 | Perimetro 36,13 <br/>3 Triángulos | Area 49,64 | Perimetro 51,60 <br/>1 Rectangulo | Area 8,00 | Perimetro 12,00 <br/>1 Trapecio | Area 40,00 | Perimetro 23,00 <br/>TOTAL:<br/>9 formas Perimetro 150,73 Area 178,67",
                summary);
        }

        [TestCase]
        public void TestSummaryListWithMoreTypesInItalian()
        {
            var geometricShapes = new List<GeometricShape>
            {
                new Square(5),
                new Circle(3),
                new EquilateralTriangle(4),
                new Square(2),
                new EquilateralTriangle(9),
                new Circle(2.75m),
                new EquilateralTriangle(4.2m),
                new Rectangle(4, 2),
                new Trapeze(10, 6, 5, 4, 3)
            };

            var summary = Print.PrintReport(geometricShapes, Language.ITALIAN);

            Assert.AreEqual(
                "<h1>Segnalazione dei moduli</h1>2 Piazze | Zona 29,00 | Perimetro 28,00 <br/>2 Cerchi | Zona 52,03 | Perimetro 36,13 <br/>3 Triangoli | Zona 49,64 | Perimetro 51,60 <br/>1 Rettangolo | Zona 8,00 | Perimetro 12,00 <br/>1 Trapezio | Zona 40,00 | Perimetro 23,00 <br/>TOTALE:<br/>9 forme Perimetro 150,73 Zona 178,67",
                summary);
        }
        #endregion MoreTypes
    }
}
