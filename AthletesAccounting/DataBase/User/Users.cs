using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthletesAccounting.DataBase.User
{
    public class Users : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [Key]
        public int id_user { get; set; }

        public string fam { get; set; }

        public string name { get; set; }

        public string parent { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public int? id_role { get; set; }
        [ForeignKey("id_role")]
        public virtual RoleUsers RoleUsers { get; set; }
    }
}
