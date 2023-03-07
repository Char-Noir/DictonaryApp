using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictonaryApp.Translation
{
    public static class TranslationLanguage
    {
        public static ComplexLanguage BULGARIAN { get; } = new ComplexLanguage() { Code = "BG", Name = " - Bulgarian" };
        public static ComplexLanguage CZECH { get; } = new ComplexLanguage() { Code = "CS", Name = " - Czech" };
        public static ComplexLanguage DANISH { get; } = new ComplexLanguage() { Code = "DA", Name = " - Danish" };
        public static ComplexLanguage GERMAN { get; } = new ComplexLanguage() { Code = "DE", Name = "Deutsch - German" };
        public static ComplexLanguage GREEK { get; } = new ComplexLanguage() { Code = "EL", Name = " - Greek" };
        public static ComplexLanguage ENGLISH { get; } = new ComplexLanguage() { Code = "EN", Name = "English " };
        public static ComplexLanguage BRITISH { get; } = new ComplexLanguage() { Code = "EN-GB", Name = "British English" , Parent = ENGLISH};
        public static ComplexLanguage AMERICAN { get; } = new ComplexLanguage() { Code = "EN-US", Name = "American English" , Parent = ENGLISH };
        public static ComplexLanguage SPANISH { get; } = new ComplexLanguage() { Code = "ES", Name = " - Spanish" };
        public static ComplexLanguage ESTONIAN { get; } = new ComplexLanguage() { Code = "ET", Name = " - Estonian" };
        public static ComplexLanguage FINNISH { get; } = new ComplexLanguage() { Code = "FI", Name = " - Finnish" };
        public static ComplexLanguage FRENCH { get; } = new ComplexLanguage() { Code = "FR", Name = " - French" };
        public static ComplexLanguage HUNGARIAN { get; } = new ComplexLanguage() { Code = "HU", Name = " - Hungarian" };
        public static ComplexLanguage INDONESIAN { get; } = new ComplexLanguage() { Code = "ID", Name = " - Indonesian" };
        public static ComplexLanguage ITALIAN { get; } = new ComplexLanguage() { Code = "IT", Name = " - Italian" };
        public static ComplexLanguage JAPANESE { get; } = new ComplexLanguage() { Code = "JA", Name = " - Japanese" };
        public static ComplexLanguage KOREAN { get; } = new ComplexLanguage() { Code = "KO", Name = " - Korean" };
        public static ComplexLanguage LITHUANIAN { get; } = new ComplexLanguage() { Code = "LT", Name = " - Lithuanian" };
        public static ComplexLanguage LATVIAN { get; } = new ComplexLanguage() { Code = "LV", Name = " - Latvian" };
        public static ComplexLanguage NORWEGIAN { get; } = new ComplexLanguage() { Code = "NB", Name = " - Norwegian (Bokmål)" };
        public static ComplexLanguage DUTCH { get; } = new ComplexLanguage() { Code = "NL", Name = " - Dutch" };
        public static ComplexLanguage POLISH { get; } = new ComplexLanguage() { Code = "PL", Name = " - Polish" };
        public static ComplexLanguage PORTUGUESE { get; } = new ComplexLanguage() { Code = "PT", Name = " - Portuguese" };
        public static ComplexLanguage BRAZILIAN { get; } = new ComplexLanguage() { Code = "PT-BR", Name = " - Brazilian Portuguese", Parent = PORTUGUESE };
        public static ComplexLanguage PORTUGUESE_EXC { get; } = new ComplexLanguage() { Code = "PT-PT", Name = " - Portuguese", Parent = PORTUGUESE };
        public static ComplexLanguage ROMANIAN { get; } = new ComplexLanguage() { Code = "RO", Name = " - Romanian" };
        public static ComplexLanguage SLOVAK { get; } = new ComplexLanguage() { Code = "SK", Name = " - Slovak" };
        public static ComplexLanguage SLOVENIAN { get; } = new ComplexLanguage() { Code = "SL", Name = " - Slovenian" };
        public static ComplexLanguage SWEDISH { get; } = new ComplexLanguage() { Code = "SV", Name = " - Swedish" };
        public static ComplexLanguage TURKISH { get; } = new ComplexLanguage() { Code = "TR", Name = " - Turkish" };
        public static ComplexLanguage UKRAINIAN { get; } = new ComplexLanguage() { Code = "UK", Name = "Українська - Ukrainian" };
        public static ComplexLanguage CHINESE { get; } = new ComplexLanguage() { Code = "ZH", Name = " - Chinese (simplified)" };
        
        

    }
}
