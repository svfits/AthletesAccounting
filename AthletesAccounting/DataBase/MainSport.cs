﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthletesAccounting.DataBase
{
/// <summary>
///  основной вид спорта дата начала
/// </summary>
    public class MainSport
    {
        [Key]
        public int mainSport_id { get; set; }
        public DateTime dateOnSports { get; set; }

        public int sport_code { get; set; }
        [ForeignKey("sport_code")]
        public virtual Sports Sports { get; set; }
    }
}