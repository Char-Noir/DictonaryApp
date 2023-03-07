using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictonaryApp.Resources.Localization
{
    public static class LocalizationLanguage
    {
        public static Language UKRAINIAN { get; } = new Language() { Name = "Українська", Code = "uk" };
        public static Language ENGLISH { get; } = new Language() { Name = "English", Code = "en" };
    }
}
