﻿using System.ComponentModel.DataAnnotations;

namespace AthletesAccounting.DataBase
{
    public class PlaceofWork
    {
        [Key]
        public int Id { get; set; }

        public string Place_Work { get; set; }
    }
}