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
             base("data source = (localdb)\\MSSQLLocalDB; Initial Catalog = 222; Integrated Security = True; TrustServerCertificate=False") { }

        public DbSet<athletes> {get; set;}
    }

}
   

