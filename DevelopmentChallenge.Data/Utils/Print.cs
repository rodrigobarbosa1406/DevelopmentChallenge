using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Handlers;
using DevelopmentChallenge.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Utils
{
    public static class Print
    {
        public static string PrintReport(List<GeometricShape> geometricShapes, Language language)
        {
            if (!Enum.IsDefined(typeof(Language), language))
                throw new ArgumentOutOfRangeException("Language not supported");

            var selectedLanguage = LanguagesHandler.GetSelectedLanguage(language);
            var cultureInfo = LanguagesHandler.GetCultureInfo(selectedLanguage);

            var sb = new StringBuilder();

            if (!geometricShapes.Any())
            {
                var emptyListMessage = TextGetter.GetEmptyListMessage(selectedLanguage);

                sb.Append($"<h1>{emptyListMessage}</h1>");
            }
            else
            {
                #region Header
                var reportTitle = TextGetter.GetReportTitle(selectedLanguage);

                sb.Append($"<h1>{reportTitle}</h1>");
                #endregion Header

                #region Lines
                var areaText = TextGetter.GetAreaText(selectedLanguage);
                var perimeterText = TextGetter.GetPerimeterText(selectedLanguage);

                geometricShapes.ForEach(f =>
                {
                    f.CalculateArea();
                    f.CalculatePerimeter();
                });

                var shapeTypes = geometricShapes.Select(gs => gs.GetType().Name).Distinct().ToList();

                shapeTypes.ForEach(shapeType =>
                {
                    var currentShapeTypeList = geometricShapes.Where(gs => gs.GetType().Name == shapeType);

                    var shapeQuantity = currentShapeTypeList.Count();
                    var shareArea = currentShapeTypeList.Sum(f => f.Area);
                    var sharePerimeter = currentShapeTypeList.Sum(f => f.Perimeter);

                    var shapeName = TextGetter.GetShapeName(selectedLanguage, shapeType, shapeQuantity);

                    sb.Append($"{shapeQuantity} {shapeName} | {areaText} {shareArea.ToString("N2", cultureInfo.NumberFormat)} | {perimeterText} {sharePerimeter.ToString("N2", cultureInfo.NumberFormat)} <br/>");
                });
                #endregion Lines

                #region Footer
                var total = TextGetter.GetTotalText(selectedLanguage);
                var shape = TextGetter.GetShapeText(selectedLanguage, geometricShapes.Count);
                var totalArea = geometricShapes.Sum(gs => gs.Area);
                var totalPerimeter = geometricShapes.Sum(gs => gs.Perimeter);

                sb.Append($"{total}:<br/>");
                sb.Append($"{geometricShapes.Count} {shape} ");
                sb.Append($"{perimeterText} {totalPerimeter.ToString("N2", cultureInfo.NumberFormat)} ");
                sb.Append($"{areaText} {totalArea.ToString("N2", cultureInfo.NumberFormat)}");
                #endregion Footer
            }

            return sb.ToString();
        }
    }
}