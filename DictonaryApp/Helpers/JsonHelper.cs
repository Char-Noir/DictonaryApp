using System.Text.Json;

namespace DictonaryApp.Helpers
{
    public static class JsonHelper
    {
        public static string Serialize(DictionaryJson dict)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(dict, options);
            return jsonString;
        }
        public static DictionaryJson Deserialize(string dict)
        {
            DictionaryJson? weatherForecast =
                JsonSerializer.Deserialize<DictionaryJson>(dict);
            return weatherForecast;
        }
        public class DictionaryJson
        {
            public string Name { get; set; }
           
            public string LanguageFrom { get; set; }
          
            public string LanguageTo { get; set; }
            public List<WordJson> Words { get; set; }

        }
        public class WordJson
        {
            public string FromWord { get; set; }
            public string ToWord { get; set; }
        }
    }
}
