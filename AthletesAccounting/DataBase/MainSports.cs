using System;
using System.ComponentModel.DataAnnotations;

namespace AthletesAccounting.DataBase
{
    public class MainSports
    {
        [Key]
        public string idAthlets { get; set; }
        public DateTime DateOnSports { get; set; }
        public virtual Sports Sports { get; set; }
    }
}