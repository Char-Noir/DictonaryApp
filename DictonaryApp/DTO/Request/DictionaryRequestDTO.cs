using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictonaryApp.DTO.Request
{
    public class DictionaryRequestDTO
    {
        public required string Name {  get; init; }
        public required string LanguageFrom { get; init; }
        public required string LanguageTo { get; init; }


        public override string ToString()
        {
            return $"Dictionary request: Name = {Name}, Language From: {LanguageFrom}, Language To: {LanguageTo}\n";
        }

        
    }
}
