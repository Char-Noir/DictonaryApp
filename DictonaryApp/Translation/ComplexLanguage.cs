using DictonaryApp.Resources.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictonaryApp.Translation
{
    public class ComplexLanguage:Language
    {
        public Language Parent { get; init; }
        public bool IsHasParent()
        {
            return Parent != null;
        }

    }
}
