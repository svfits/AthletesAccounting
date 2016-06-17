using System.ComponentModel.DataAnnotations;

namespace AthletesAccounting.DataBase
{
    public class Injuries
    {
        [Key]
        public int id { get; set; }
        public string injury { get; set; }
    }
}