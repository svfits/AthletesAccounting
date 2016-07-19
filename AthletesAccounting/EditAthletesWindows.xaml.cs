using AthletesAccounting.DataBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AthletesAccounting
{
    /// <summary>
    /// форма для редактирования спортсменов 
    /// </summary>
    public partial class EditAthletesWindows : Window    
    {
        int? athletesAddorUpdate;
        public EditAthletesWindows(int id = -100)
        {
            InitializeComponent();
            
            if (id != -100)
            {
                athletesAddorUpdate = id;
                try
                {
                    using (UserContext db = new UserContext())
                    {
                        var result = db.Athletes
                           .Include("Sports")
                           .Include("SportTeam")
                           .Include("Rank")
                           .Include("Education")
                           .Include("MainSport")
                           .AsEnumerable()
                           .Where(c => c.id == id)
                           .FirstOrDefault()
                           ;

                        this.DataContext = result;
                        //System.Diagnostics.Debug.WriteLine(result.name + "    select11111111111111111111111111111111111111111111111   " + result.education_id);

                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            }            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SizeToContent = SizeToContent.WidthAndHeight;

            try
            {
                using (UserContext db = new UserContext())
                {
                    var result = db.Sports
                       .AsEnumerable()
                       .ToList()
                       ;
                    //System.Diagnostics.Debug.WriteLine(result.ToString());
                    sportCmb.ItemsSource = result;
                    sportMain.ItemsSource = result;
                    sportsOtherCmb.ItemsSource = result;
                    sportsRankCmb.ItemsSource = result;
                    sportsGameCmb.ItemsSource = result;

                    var result1 = db.SportTeam
                        .AsEnumerable()
                        .ToList()
                        ;

                    //System.Diagnostics.Debug.WriteLine(result1.ToString());
                    sportTeamCmb.ItemsSource = result1;

                    var result2 = db.Rank
                      .AsEnumerable()
                      .ToList()
                      ;
                    //System.Diagnostics.Debug.WriteLine(result2.ToString());
                    rankCmb.ItemsSource = result2;
                    rankSportDateCmd.ItemsSource = result2;

                    var result3 = db.Education
                   .AsEnumerable()
                   .ToList()
                   ;
                    //System.Diagnostics.Debug.WriteLine(result3.ToString());
                    education.ItemsSource = result3;

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
          
        }

        private void exportExcel(object sender, RoutedEventArgs e)
        {

        }

        private void importExcel(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(sportCmb.SelectedValue + "     sport");
        }

        private void MenuItem_Click_exit(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// сохраним или обновим данные потом разобраться с DataContext
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAthlets_Click(object sender, RoutedEventArgs e)
        {
            int? idMainSport = null;
            DateTime? dateTimeNextProbe = null;

            if (dateNextDatePicker.SelectedDate != null)
            {
                dateTimeNextProbe = dateNextDatePicker.SelectedDate.Value;
            }


            #region блок 12 каким видом спорта преимущественно занимается сколько вермени

            if (sportMain.SelectedValue != null && mainSportDateDatepicker.SelectedDate != null)
            {
                MainSport mainSport = new MainSport()
                {
                    dateOnSports = mainSportDateDatepicker.SelectedDate.Value,
                    sport_code = sportMain.SelectedIndex
                };

                using (UserContext db = new UserContext())
                {
                    try
                    {
                        if (athletesAddorUpdate != null)
                        {
                            var result = db.Athletes.First(c => c.id == athletesAddorUpdate);

                            if (result.mainSport_id == null)
                            {
                                db.MainSport.Add(mainSport);
                                db.SaveChanges();
                                idMainSport = mainSport.mainSport_id;
                            }
                            else
                            {
                                var result2 = db.MainSport.FirstOrDefault(c => c.mainSport_id == result.mainSport_id);

                                result2.dateOnSports = mainSportDateDatepicker.SelectedDate.Value;
                                result2.sport_code = sportMain.SelectedIndex;

                                db.Entry(result2).State = EntityState.Modified;
                                db.SaveChanges();
                                idMainSport = result.mainSport_id;
                            }
                        }
                        else
                        {
                            db.MainSport.Add(mainSport);
                            db.SaveChanges();
                            idMainSport = mainSport.mainSport_id;
                        }                 
                    }
                    catch
                    { }
                }
            }

            #endregion

            Athletes newAthlet = new Athletes
            {
                fam = fam.Text,
                name = name.Text,
                parent = parent.Text,
                sex = sex.Text,
                adress = Adres.Text,
                telefon = Telefon.Text,
                PlaceofStudyAndWork = PlaceStydy.Text,
                livingСonditions = livingСonditions.Text,
                profAthlets = profAthlets.Text,
                alcohol = alcohol.Text,
                smoke = smoking.Text,
                pastIllnes = pastIllnesTxtb.Text,
                injuries = Injury.Text,
                operations = operationsTxtbx.Text,
                DOB = DOB.SelectedDate.Value,

                sport_code = Convert.ToInt32(sportCmb.SelectedValue),
                sportTeam_code = Convert.ToInt32(sportTeamCmb.SelectedValue),
                education_code = Convert.ToInt32(education.SelectedValue),
                rank_code = Convert.ToInt32(rankCmb.SelectedValue),
                DateGreate = DateTime.Now,

                otherSports = txtotherSports.Text,
                sportsGame  = sportGame.Text,
                rankDateGet = rankDateSport.Text,
                
                mainSport_id = idMainSport,
                notes = notesTxb.Text,
                dateTimeNextProbe = dateTimeNextProbe
            };

            try {

                using (UserContext db = new UserContext())
                {
                    if (athletesAddorUpdate == null)
                    {
                        System.Diagnostics.Debug.WriteLine(" добавим спортсмена ID  " + athletesAddorUpdate);
                   
                        db.Athletes.Add(newAthlet);
                        db.SaveChanges();

                        athletesAddorUpdate = newAthlet.id;
                        System.Diagnostics.Debug.WriteLine(" добавим спортсмена ID  " + athletesAddorUpdate);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine(" редактируем ID  " + athletesAddorUpdate);
                        var update = db.Athletes
                           .AsEnumerable()
                           .Where(c => c.id == athletesAddorUpdate)
                           .FirstOrDefault()
                           ;

                       update.fam = fam.Text;
                       update.name = name.Text;
                       update.parent = parent.Text;
                       update.sex = sex.Text;
                       update.adress = Adres.Text;
                       update.telefon = Telefon.Text;
                       update.PlaceofStudyAndWork = PlaceStydy.Text;
                       update.livingСonditions = livingСonditions.Text;
                       update.profAthlets = profAthlets.Text;
                       update.alcohol = alcohol.Text;
                       update.smoke = smoking.Text;
                       update.pastIllnes = pastIllnesTxtb.Text;
                       update.injuries = Injury.Text;
                       update.operations = operationsTxtbx.Text;
                       update.DOB = DOB.SelectedDate.Value;

                       update.sport_code = Convert.ToInt32(sportCmb.SelectedValue);
                       update.sportTeam_code = Convert.ToInt32(sportTeamCmb.SelectedValue);
                       update.education_code = Convert.ToInt32(education.SelectedValue);
                       update.rank_code = Convert.ToInt32(rankCmb.SelectedValue);

                       update.otherSports = txtotherSports.Text;
                       update.sportsGame = sportGame.Text;
                       update.rankDateGet = rankDateSport.Text;

                       update.mainSport_id = idMainSport;
                       update.notes = notesTxb.Text;
                       update.dateTimeNextProbe = dateTimeNextProbe;

                       db.Entry(update).State = EntityState.Modified;
                       db.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
                       
        }      
          

        private void rank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(rankCmb.SelectedValue + "   rankCmb.SelectedValue");
        }

        private void mainSportDateDatepicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime newDate = DateTime.Now;

            if (mainSportDateDatepicker.SelectedDate != null)
            {
                int yearMainSport = mainSportDateDatepicker.SelectedDate.Value.Year;
                mainSportDateLbl.Content = (DateTime.Now.Year - yearMainSport).ToString();
            }
          
        }

        #region Блок 12-16

        /// <summary>
        //// другие виды спорта получил
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void otherSports_Click(object sender, RoutedEventArgs e)
        {
            if (!txtotherSports.Text.Contains(sportsOtherCmb.SelectedValue.ToString()))
            {
                System.Diagnostics.Debug.WriteLine(sportsOtherCmb.SelectedValue + "   rankCmb.SelectedValue" + txtotherSports.Text);
                //txtotherSports.Text += sportsOtherCmb.SelectedValue + "\n";
                txtotherSports.Text += sportsOtherCmb.SelectedValue + " ";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sportsOtherCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(sportsOtherCmb.SelectedValue + "   rankCmb.SelectedValue");
        }

        /// <summary>
        /// в каких соревнованиях участвовал
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!sportGame.Text.Contains(sportsGameCmb.SelectedValue.ToString()))
            {
                System.Diagnostics.Debug.WriteLine(sportsGameCmb.SelectedValue + "   sportsGameCmb.SelectedValue" + sportGame.Text);
                //sportGame.Text += sportsGameCmb.SelectedValue + "\n";
                sportGame.Text += sportsGameCmb.SelectedValue + "  ";
            }
        }

        /// <summary>
        /// дата получения каждого разряда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (rankSportDateCmd.SelectedValue != null
                && rankDateAdd.SelectedDate != null 
                && sportsRankCmb.SelectedValue != null
                && ( ( rankDateSport.Text.Contains(sportsRankCmb.SelectedValue.ToString())  && rankDateSport.Text.Contains(rankSportDateCmd.SelectedValue.ToString()) ) != true)
                )
            {
                rankDateSport.Text += rankSportDateCmd.SelectedValue + "    " + rankDateAdd.SelectedDate.Value + "  " + sportsRankCmb.SelectedValue + "\n";
            }
        }

        /// <summary>
        /// только год и месяц получения разряда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rankDateAdd_CalendarOpened(object sender, RoutedEventArgs e)
        {
            var rankDateAdd = sender as DatePicker;
            if (rankDateAdd != null)
            {
                // PART_Popup - часть шаблона DatePicker
                var popup = rankDateAdd.Template.FindName(
                    "PART_Popup", rankDateAdd) as System.Windows.Controls.Primitives.Popup;

                if (popup != null && popup.Child is Calendar)
                {
                    Calendar calendar = (Calendar)popup.Child;
                    calendar.DisplayMode = CalendarMode.Year;
                }
            }
        }

        #endregion

        private void sportMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(sportMain.SelectedValue + "   sportsGameCmb.SelectedValue" + sportMain.SelectedValue);
           
        }

        private void Telefon_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Telefon.OpacityMask = Brush.OpacityProperty;
        }
    }

}
