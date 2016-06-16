using System.ComponentModel.DataAnnotations;

namespace AthletesAccounting.DataBase
{
    public class PastIllness
    {
        [Key]
        public int id { get; set; }

        public string pastIllnesses { get; set; }
    }
}