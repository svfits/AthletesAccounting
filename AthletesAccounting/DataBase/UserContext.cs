using AthletesAccounting.DataBase.User;
using AthletesAccounting.DataBase.Settings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthletesAccounting.DataBase
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("data source = (localdb)\\MSSQLLocalDB; Initial Catalog = AthletesAccounting; Integrated Security = True; TrustServerCertificate=False") { }
          //base("BookContext") { }                 
        
        public DbSet<Athletes> Athletes{get; set;}     
   
        public DbSet<Rank> Rank { get; set; }

        public DbSet<SportTeam> SportTeam { get; set; }

        public DbSet<Education> Education { get; set; }

        public DbSet<Sports> Sports { get; set; }

        public DbSet<MainSport> MainSport { get; set; }

        public DbSet<AnthropometricData> AnthropometricData { get; set; }

        public DbSet<Couch> Couch { get; set; }

        /// <summary>
        ////пользователи
        /// </summary>
        public DbSet<Users> Users { get; set; }
        /// <summary>
        ///  роли пользователей
        /// </summary>
        public DbSet<RoleUsers> RoleUsers { get; set; }
        /// <summary>
        ////шаблоны для печати итд
        /// </summary>
        public DbSet<Templates> Templates { get; set; }
        /// <summary>
        /// системные настроки
        /// </summary>
        public DbSet<Settings.Settings> Settings { get; set; }

    }

}
   

