using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthletesAccounting.DataBase
{
    public class RankDateGet
    {
        [Key]
        public int rankDateGet_id { get; set; }

        public int? rank_code { get; set; }
        [ForeignKey("rank_code")]
        public virtual Rank Rank { get; set; }

        public DateTime onDateGetRank { get; set; }
    }
}