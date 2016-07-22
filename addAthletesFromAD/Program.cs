using AthletesAccounting.DataBase;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddAthletesFromAD
{
    class Program
    {
        static void Main(string[] args)
        {
            FromADtoBD();
            Console.ReadKey();
        }

        static public void FromADtoBD()
        {
           
            try
            {
                string domain = "isea.ru";
                DirectoryEntry adRoot = new DirectoryEntry("LDAP://" + domain, null, null, AuthenticationTypes.Secure);
                DirectorySearcher search = new DirectorySearcher(adRoot);
                search.Filter = "(&(objectClass=user)(objectCategory=person))";

                search.PropertiesToLoad.Add("samaccountname");
                search.PropertiesToLoad.Add("mail");
                search.PropertiesToLoad.Add("memberOf");
                search.PropertiesToLoad.Add("displayname");//first name
          
                SearchResult result;
                SearchResultCollection resultCol = search.FindAll();

                if (resultCol != null)
                {
                    for (int counter = 0; counter < resultCol.Count; counter++)
                    {
                        result = resultCol[counter];
                        if (result.Properties.Contains("samaccountname") &&
                                 result.Properties.Contains("mail") &&
                            result.Properties.Contains("displayname") &&
                            result.Properties.Contains("memberOf"))
                        {
                            //////string groups = (String)result.Properties["memberOf"][0];
                            //////groups = groups.Replace("CN=", "").Replace("OU=БГУЭП", "").Replace("DC=isea", "").Replace("DC=ru", "").Replace("OU=", "");

                            //db.Ad_users.Add(new Ad_users()
                            //{
                            //    Email = (String)result.Properties["mail"][0],
                            //    UserName = (String)result.Properties["samaccountname"][0],
                            //    DisplayName = (String)result.Properties["displayname"][0],
                            //    role = "",
                            //    group = groups
                            //});

                            //System.Diagnostics.Debug.WriteLine((String)result.Properties["samaccountname"][0] + "  логин");
                            //System.Diagnostics.Debug.WriteLine((String)result.Properties["mail"][0] + "   First Name");
                            //System.Diagnostics.Debug.WriteLine((String)result.Properties["memberof"][0] + "   Last Name");
                            System.Diagnostics.Debug.WriteLine((String)result.Properties["displayName"][0] + "  displayName");
                            string value = (String)result.Properties["displayName"][0];
                            Char delimiter = 's';
                            string[] str = value.Split(delimiter);

                            if (str.Length > 2)
                            {
                                string name = str[0];
                                string fam = str[1];
                                string parent = str[2];
                                
                                System.Diagnostics.Debug.WriteLine(name + "  " + fam + "  " + parent);
                            }
                        }
                    }
                    //db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

        }

        private void saveAthletes(string fam, string name, string parent)
        {
            Athletes newAthletes = new Athletes()
            {
                fam = fam,
                name = name,
                parent = parent,
                adress = "Иркутская область г.Ангарск улица Ворошилова 117а корпус 7 квартира 115",

            };
        }
    }
}
