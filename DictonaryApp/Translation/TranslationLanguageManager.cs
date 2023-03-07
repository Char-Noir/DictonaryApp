using DictonaryApp.Resources.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictonaryApp.Translation
{
    class TranslationLanguageManager
    {
        public static IList<ComplexLanguage> AvaliableLanguages { get; } = new List<ComplexLanguage>()
        {
            TranslationLanguage.BULGARIAN,
            TranslationLanguage.CZECH, 
            TranslationLanguage.DANISH,
            TranslationLanguage.GERMAN, 
            TranslationLanguage.GREEK,
            TranslationLanguage.BRITISH,
            TranslationLanguage.AMERICAN,
            TranslationLanguage.SPANISH,
            TranslationLanguage.ESTONIAN,
            TranslationLanguage.FINNISH,
            TranslationLanguage.FRENCH,
            TranslationLanguage.HUNGARIAN,
            TranslationLanguage.INDONESIAN,
            TranslationLanguage.ITALIAN,
            TranslationLanguage.JAPANESE,
            TranslationLanguage.KOREAN,
            TranslationLanguage.LITHUANIAN,
            TranslationLanguage.LATVIAN,
            TranslationLanguage.NORWEGIAN,
            TranslationLanguage.DUTCH,
            TranslationLanguage.POLISH,
            TranslationLanguage.BRAZILIAN,
            TranslationLanguage.PORTUGUESE_EXC,
            TranslationLanguage.ROMANIAN,
            TranslationLanguage.SLOVAK,
            TranslationLanguage.SLOVENIAN,
            TranslationLanguage.SWEDISH,
            TranslationLanguage.TURKISH,
            TranslationLanguage.UKRAINIAN,
            TranslationLanguage.CHINESE
        };

        public static bool IsLanguageAvaliable(string language)
        {
            foreach (var lang in AvaliableLanguages)
            {
                if (lang.Code == language)
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

        public static ComplexLanguage GetLanguageByCode(string code)
        {
            foreach (var language in AvaliableLanguages)
            {
                if(language.Code == code)
                {
                    return language;
                }
            }
            return null;
        }
    }
}
