using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DictonaryApp.Models
{
    [Table("dictionary")]
    public class DictionaryModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(32)]
        public string Name { get; set; }
        [MaxLength(5)]
        public string LanguageFrom { get; set; }
        [MaxLength(5)]
        public string LanguageTo { get; set; }
        public DateTime CreationDate { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<WordModel> Words { get; set; }
    }
}
