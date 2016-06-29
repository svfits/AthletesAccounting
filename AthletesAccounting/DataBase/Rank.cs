using System.ComponentModel.DataAnnotations;

namespace AthletesAccounting.DataBase
{
    public class Rank
    {
        [Key]
        public int rank_id { get; set; }
        public string rank { get; set; }
    }
}