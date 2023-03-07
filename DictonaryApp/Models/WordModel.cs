using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictonaryApp.Models
{
    [Table("words")]
    public class WordModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(200)]
        public string FromWord { get; set; }
        [MaxLength(200)]
        public string ToWord { get; set; }
        public DateTime CreationDate { get; set; }
        [ForeignKey(typeof(DictionaryModel))]
        public int DictionaryId { get; set; }
        [ManyToOne]      // Many to one relationship with Stock
        public DictionaryModel Dictionary{ get; set; }
    }
}
