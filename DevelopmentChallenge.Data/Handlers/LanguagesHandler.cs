using DevelopmentChallenge.Data.Enums;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;

namespace DevelopmentChallenge.Data.Handlers
{
    public static class LanguagesHandler
    {
        public static JToken GetSelectedLanguage(Language language)
        {
            var languagesConfigFile = @"DevelopmentChallenge.Data\languages.json";

            if (!File.Exists(languagesConfigFile))
                throw new FileNotFoundException("Language config file not found");

            var jsonContent = File.ReadAllText(languagesConfigFile);
            var languages = JObject.Parse(jsonContent);

            var selectedLanguage = languages[language.ToString()];

            if (selectedLanguage is null)
                throw new InvalidDataException("Selected language is not present in the language config file");

            if (!selectedLanguage.HasValues)
                throw new InvalidDataException("Selected language is empty");
            else if (selectedLanguage.Count() < 4)
                throw new InvalidDataException("Selected language is incomplete");
            else
            {
                var geometricShapes = selectedLanguage["GeometricShapes"];
                var dimensions = selectedLanguage["Dimensions"];
                var messages = selectedLanguage["Messages"];
                var words = selectedLanguage["Words"];

                if (geometricShapes is null || dimensions is null || messages is null || words is null)
                    throw new InvalidDataException("Selected language is invalid in language config file");
            }

            return selectedLanguage;
        }
    }
}