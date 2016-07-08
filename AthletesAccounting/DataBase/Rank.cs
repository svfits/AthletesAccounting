using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthletesAccounting.DataBase
{
    public class Rank
    {   
        public string rank { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rank_code { get; set; }
    }
}