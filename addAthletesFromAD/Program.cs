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
        public static void Main(string[] args)
        {
            using (UserContext db = new UserContext())
            {
                db.Athletes.RemoveRange(db.Athletes);
                db.SaveChanges();
            }

            AddUsersFromAD gg = new AddUsersFromAD();
            gg.FromADtoBD();
            Console.ReadKey();
        }

    }
    
  public  class AddUsersFromAD
    {
        public void FromADtoBD()
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
                            //Char delimiter = 's';
                            string[] str = value.Split(new char[] { ' ' });

                            System.Diagnostics.Debug.WriteLine((str.Length.ToString()));

                            if (str.Length > 2)
                            {
                                string name = str[1];
                                string fam = str[0];
                                string parent = str[2];

                                System.Diagnostics.Debug.WriteLine(name + "  " + fam + "  " + parent);

                                saveAthletes(fam, name, parent);
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
                adress = "Иркутская область г.Ангарск, "  + RandomCombo3() + " квартал, " + RandomCombo3() + " дом, " + RandomCombo3() + " квартира",
                sex = "Мужской",
                telefon = "89501" + RandomComboTel() + RandomComboTel(),
                PlaceofStudyAndWork = "школа №" + RandomCombo3() ,
                livingСonditions = "Удовлетворительно",
                sportTeam_code = RandomCombo(),
                profAthlets = "Директор",
                alcohol = "Не употребляет",
                smoke = "Не курит",
                operations = "Ре­зекция желудка по поводу язвенной болезни \n" + "Костно - плас­тическая ампутация стопы по Н.И.Пирогову \n" + "Аppendectomia \n" + "Удаление периферической части конечности на уровне сустава \n",
                pastIllnes = "Корь\n" + "Краснуха\n" + "Гепатит\n" + "А Паротит\n",
                injuries = "Перелом левого уха",
                sport_code = RandomCombo(),
                rank_code = RandomCombo(),
                DOB = RandomDay(),
                mainSport_id = 34,
                otherSports = "Футбол Хоккей Теннис",
                sportsGame = "Футбол Крикет Волейбол Настольный Теннис Картинг",
                rankDateGet = RandomDay() + " 1 разряд " + " Теннис \n" + RandomDay() + " 2 разряд "  + " Теннис \n",
                DateGreate = RandomDay(),
                notes = "13.03.2016 был вызван на прием к неврологу \n",
                dateTimeNextProbe = RandomDay(),
                education_code = RandomCombo(),
                id_couch = RandomCombo2(),
                
            };

            using (UserContext db = new UserContext())
            {
                db.Athletes.Add(newAthletes);
                db.SaveChanges();
            }
        }


        DateTime RandomDay()
        {
            Random gen = new Random();
            System.Threading.Thread.Sleep(RandomCombo2());
            DateTime start = new DateTime(1930, 1, 1);
            int range = (DateTime.Today - start).Days;
            System.Diagnostics.Debug.WriteLine(start.AddDays(gen.Next(range)).ToString());
            return start.AddDays(gen.Next(range));

        }

        int RandomCombo()
        {
            Random gen = new Random();
            System.Threading.Thread.Sleep(RandomCombo2());
            int rnd = gen.Next(0, 7);
            return rnd;
        }

        int RandomCombo2()
        {
            Random gen = new Random();
            int rnd = gen.Next(0, 11);
            return rnd;
        }

        int RandomCombo3()
        {
            Random gen = new Random();
            System.Threading.Thread.Sleep(RandomCombo2());
            int rnd = gen.Next(1, 999);
            return rnd;
        }

        int RandomComboTel()
        {
            Random gen = new Random();
            System.Threading.Thread.Sleep(RandomCombo2());
            int rnd = gen.Next(100, 999);
            return rnd;
        }
    }
}
