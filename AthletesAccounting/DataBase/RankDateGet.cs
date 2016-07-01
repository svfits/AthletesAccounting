using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthletesAccounting.DataBase
{
    public class RankDateGet
    {
        [Key]
        public int rankDateGet_id { get; set; }

        public int? rank_id { get; set; }
        [ForeignKey("rank_id")]
        public virtual Rank rank { get; set; }

        public DateTime onDateGetRank { get; set; }
    }
}