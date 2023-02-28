using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DictonaryApp.Resources.Localization
{
    public static class LanguageManager
    {
        public static IList<Language> AvaliableLanguages { get; } =  new List<Language>()
        {
            new Language() { Name = "English", Code = "en" },
            new Language() { Name = "Українська", Code = "uk" }
        };

        public static bool IsLanguageAvaliable(string language)
        {
            foreach (var lang in AvaliableLanguages)
            {
                if(lang.Code == language)
                {
                    return true;
                }
            }
            return false;
        }

        public static int GetLanguageIndex(string language)
        {
            for (int i = 0; i < AvaliableLanguages.Count; i++)
            {
                if (AvaliableLanguages[i].Code == language)
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
