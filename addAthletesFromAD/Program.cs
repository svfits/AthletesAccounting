﻿using AthletesAccounting.DataBase;
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
                adress = "Иркутская область г.Ангарск улица Ворошилова 117а корпус 7 квартира 115",
                sex = "Муж.",
                telefon = "89501475249",
                PlaceofStudyAndWork = "школа №32",
                livingСonditions = "НЕ удолетворительно",
                sportTeam_code = RandomCombo(),
                profAthlets = "Директор",
                alcohol = "Много",
                smoke = "Курит",
                operations = "Ре­зекция желудка по поводу язвенной болезни \n" + "Костно - плас­тическая ампутация стопы по Н.И.Пирогову \n" + "Аppendectomia \n" + "Удаление периферической части конечности на уровне сустава \n",
                pastIllnes = "Корь \n" + "Краснуха \n" + "Гепатит А \n" + "Паротит",
                injuries = "Перелом левого уха",
                sport_code = RandomCombo(),
                rank_code = RandomCombo(),
                DOB = RandomDay(),
                mainSport_id = 34,
                otherSports = "Футбол Хоккей Тенис",
                sportsGame = "Футбол  Крекет  Волейбол  Настольный Тенис  Картинг",
                rankDateGet = "1 разряд    13.07.2016 Тенис \n" + "2 разряд    13.07.2016 Тенис \n",
                DateGreate = RandomDay(),
                notes = "Пиль куриль  болель",
                dateTimeNextProbe = RandomDay(),
                education_code = RandomCombo()
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
            DateTime start = new DateTime(1930, 1, 1);
            int range = (DateTime.Today - start).Days;
            System.Diagnostics.Debug.WriteLine(start.AddDays(gen.Next(range)).ToString());
            return start.AddDays(gen.Next(range));

        }

        int RandomCombo()
        {
            Random gen = new Random();
            int rnd = gen.Next(0, 6);
            return rnd;
        }
    }
}
