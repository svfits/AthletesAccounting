using System.ComponentModel.DataAnnotations;

namespace AthletesAccounting.DataBase
{
    public class Operations
    {
        [Key]
        public int id { get; set; }

        public string operations { get; set; }
    }
}