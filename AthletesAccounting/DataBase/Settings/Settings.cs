using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthletesAccounting.DataBase.Settings
{
    /// <summary>
    ////настройки системы
    /// </summary>
    public class Settings
    {
        [Key]
        public int id { get; set; }

        public string HomeDirCard { get;set; }
    }
}
