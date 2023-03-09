using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictonaryApp.DTO.Responce
{
    public class WordResponceDTO
    {
        public int Id { get; init; }
        public string WordFrom { get; init; }
        public string WordTo { get; init; }
        public int IdDictionary { get; init; }
        public string Result
        {
            get
            {
                return $"{WordFrom} => {WordTo}";
            }
        }
    }
}
