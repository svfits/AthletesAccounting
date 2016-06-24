using AthletesAccounting.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthletesAccounting.TimeDateAge
{
    public static class ConvertDOBtoAge
    {
        public static int convertDOBtoAge(DateTime DOB)
        {
            //string result1 = "ffffff";
            //try
            //{
            //    using (UserContext db = new UserContext())
            //    {
            //        var result = db.Athletes
            //           .AsEnumerable()
            //           .Where(c => c.fam.ToLower().StartsWith(famAthletes))
            //           .Select(c => new
            //           {
            //               c.fam,
            //               c.name,
            //               c.parent,
            //               c.DOB
            //           }
            //           )
            //           .Take(20)
            //           ;
            //        return result;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine(ex.ToString());
            //}

            //return result1;


            return (DateTime.Now.Year - DOB.Year);
        }
    }
}
