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
        //   base("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = 2222; Integrated Security = True") { }                 
        

        public DbSet<Athletes> Athletes{get; set;}     

        //public DbSet<Operations> Operations { get; set; }

        public DbSet<Rank> Rank { get; set; }

        public DbSet<SportTeam> SportTeam { get; set; }

        public DbSet<Education> Education { get; set; }

        //public DbSet<Rank> Rank { get; set; }

        public DbSet<Sports> Sports { get; set; }

        public DbSet<MainSport> MainSport { get; set; }

    }

}
   

