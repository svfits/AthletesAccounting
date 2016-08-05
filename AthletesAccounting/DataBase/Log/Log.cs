using AthletesAccounting.DataBase.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthletesAccounting.DataBase.Log
{
    public class Log 
    {
        [Key]
        public int id { get; set; }

        public int whereEvent { get; set; }
        [ForeignKey("whereEvent")]
        public virtual WhereEvent WhereEvent { get; set; }

        public int typeEvent { get; set; }
        [ForeignKey("typeEvent")]
        public virtual TypeEvent TypeEvent { get; set; }

        public DateTime logGreate { get; set; }

        public int id_user { get; set; }
        [ForeignKey("id_user")]
        public virtual Users Users { get; set; }
    }
}
