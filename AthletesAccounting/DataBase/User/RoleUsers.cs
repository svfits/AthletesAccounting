using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthletesAccounting.DataBase.User
{
   public class RoleUsers
    {
        [Key]
        public int id_role { get; set; }

        /// <summary>
        /// имя роли 
        /// </summary>
        public string name_role { get; set; }

        /// <summary>
        ////описание роли
        /// </summary>
        public string description_role { get; set; }
    }
}
