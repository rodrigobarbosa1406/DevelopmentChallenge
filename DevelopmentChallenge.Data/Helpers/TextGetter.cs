using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Helpers
{
    public static class TextGetter
    {
        public static string GetShapeText(JToken selectedLanguage, int shapeQuantity)
        {
            var shapeJToken = selectedLanguage["Words"]["Shape"] ?? throw new KeyNotFoundException("Translated text not found");
            var shapeText = shapeJToken[shapeQuantity == 1 ? "Singular" : "Plural"] ?? throw new KeyNotFoundException("Translated text not found");

            return shapeText.ToString();
        }

        public static string GetTotalText(JToken selectedLanguage)
        {
            var totalText = selectedLanguage["Words"]["Total"] ?? throw new KeyNotFoundException("Translated text not found");

            return totalText.ToString();
        }

        public static string GetShapeName(JToken selectedLanguage, string shapeType, int shapeQuantity)
        {
            var shapeJToken = selectedLanguage["GeometricShapes"][shapeType] ?? throw new KeyNotFoundException("Translated text not found");
            var shapeName = shapeJToken[shapeQuantity == 1 ? "Singular" : "Plural"] ?? throw new KeyNotFoundException("Translated text not found");

            return shapeName.ToString();
        }

        public static string GetPerimeterText(JToken selectedLanguage)
        {
            var perimeterText = selectedLanguage["Dimensions"]["Perimeter"] ?? throw new KeyNotFoundException("Translated text not found");

            return perimeterText.ToString();
        }

        public static string GetAreaText(JToken selectedLanguage)
        {
            var areaText = selectedLanguage["Dimensions"]["Area"] ?? throw new KeyNotFoundException("Translated text not found");

            return areaText.ToString();
        }

        public static string GetReportTitle(JToken selectedLanguage)
        {
            var reportTitle = selectedLanguage["Messages"]["ReportTitle"] ?? throw new KeyNotFoundException("Translated text not found");

            return reportTitle.ToString();
        }

        public static string GetEmptyListMessage(JToken selectedLanguage)
        {
            var emptyListMessage = selectedLanguage["Messages"]["EmptyList"] ?? throw new KeyNotFoundException("Translated text not found");

            return emptyListMessage.ToString();
        }
    }
}