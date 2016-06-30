using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthletesAccounting.DataBase
{
    public class MainSport
    {
        [Key]
        public string mainSport_id { get; set; }
        public DateTime dateOnSports { get; set; }

        public int sports_id { get; set; }
        [ForeignKey("sports_id")]
        public virtual Sports Sports { get; set; }
    }
}