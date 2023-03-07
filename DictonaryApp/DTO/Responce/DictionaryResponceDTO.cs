using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictonaryApp.DTO.Responce
{
    public class DictionaryResponceDTO
    {
        public int Id { get; set; }
        public string Name { get; init; }
        public string LanguageFrom { get; set; }
        public string LanguageTo { get; set; }
        public DateTime CreationDate { get; set; }
        public string Result
        {
            get
            {
                return $"{Id}. {Name } {LanguageFrom} => {LanguageTo}";
            }
        }

        public override string ToString()
        {
            return $"Dictionary responce: Id = {Id}, Name = {Name}, Language From: {LanguageFrom}, Language To: {LanguageTo}, Creation Date = {CreationDate} \n";
        }
    }
}
