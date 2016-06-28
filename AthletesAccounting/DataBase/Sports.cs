using System.ComponentModel.DataAnnotations;

namespace AthletesAccounting.DataBase
{
    public class Sports
    {
        [Key]
        public int sports_id { get; set; }
        public string sports { get; set; }
    }
}