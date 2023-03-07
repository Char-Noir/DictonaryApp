using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictonaryApp.DTO.Request
{
    public class WordRequestDTO
    {
        public string TextFrom {  get; set; }
        public string TextTo { get; set; } 
        public int IdDictionary { get; set; }

    }
}
