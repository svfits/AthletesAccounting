using AthletesAccounting.DataBase;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for EditAthletesWindows.xaml
    /// </summary>
    public partial class EditAthletesWindows : Window
    {
        public EditAthletesWindows(int id = -100)
        {
            InitializeComponent();

            if (id != -100)
            {
                try
                {
                    using (UserContext db = new UserContext())
                    {
                        var result = db.Athletes
                           .Include("Sports")
                           .Include("SportTeam")
                           .Include("Rank")
                           .Include("Education")
                           .AsEnumerable()
                           .Where(c => c.id == id)
                           .FirstOrDefault()
                           ;

                        this.DataContext = result;
                        System.Diagnostics.Debug.WriteLine(result.name + "    select11111111111111111111111111111111111111111111111   " + result.education_id);

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
                    System.Diagnostics.Debug.WriteLine(result.ToString());
                    sportCmb.ItemsSource = result;
                    sportMain.ItemsSource = result;
                    sportsOtherCmb.ItemsSource = result;
                    sportsRankCmb.ItemsSource = result;
                    sportsGameCmb.ItemsSource = result;

                    var result1 = db.SportTeam
                        .AsEnumerable()
                        .ToList()
                        ;

                    System.Diagnostics.Debug.WriteLine(result1.ToString());
                    sportTeamCmb.ItemsSource = result1;

                    var result2 = db.Rank
                      .AsEnumerable()
                      .ToList()
                      ;
                    System.Diagnostics.Debug.WriteLine(result2.ToString());
                    rank.ItemsSource = result2;
                    rankSportDateCmd.ItemsSource = result2;

                    var result3 = db.Education
                   .AsEnumerable()
                   .ToList()
                   ;
                    System.Diagnostics.Debug.WriteLine(result3.ToString());
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
            System.Diagnostics.Debug.WriteLine(sportCmb.SelectedValue + "     1");
        }

        private void MenuItem_Click_exit(object sender, RoutedEventArgs e)
        {

        }

        private void saveAthlets_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (UserContext db = new UserContext())
                {
                    var insertOrUpdate = db.Athletes
                        .AsEnumerable()
                        .Where(c => c.name == Name.Text)
                        .Where(c => c.fam == Fam.Text)
                        .Where(c => c.parent == Parent.Text)
                        .Where(c => c.DOB == DOB.SelectedDate.Value)
                        .FirstOrDefault();

                    if (insertOrUpdate == null)
                    {
                        System.Diagnostics.Debug.WriteLine(" добавим спортсмена  ");
                        var rr = this.DataContext;
                        
                        //db.Athletes.AddRange(new List<Athletes> {rr });
                        db.Athletes.Add(new Athletes()
                        {
                            name = Name.Text,
                            fam = Fam.Text,
                            parent = Parent.Text,
                            adress = Adres.Text,
                            telefon = Telefon.Text,
                            DOB = DOB.SelectedDate.Value,
                            sex = sex.Text,
                            PlaceofStudyAndWork = PlaceStydy.Text,
                            profAthlets = profAthlets.Text,
                            alcohol = alcohol.Text,
                            livingСonditions = livingСonditions.Text,
                            smoke = smoking.Text,
                            injuries = Injury.Text,
                            housing = livingСonditions.Text,
                            sports_id = Convert.ToInt32(sportCmb.SelectedValue),
                            sportTeam_id = Convert.ToInt32(sportTeamCmb.SelectedValue),
                            education_id = Convert.ToInt32(education.SelectedValue),
                            rank_id = Convert.ToInt32(rank.SelectedValue),
                            pastIllnes = pastIllnesTxtb.Text,
                            operations = operationsTxtbx.Text
                        });
                        db.SaveChanges();
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine(" обновим спортсмена  ");

                        insertOrUpdate.name = Name.Text;
                        insertOrUpdate.fam = Fam.Text;
                        insertOrUpdate.parent = Parent.Text;
                        insertOrUpdate.adress = Adres.Text;
                        insertOrUpdate.telefon = Telefon.Text;
                        insertOrUpdate.DOB = DOB.SelectedDate.Value;
                        insertOrUpdate.sex = sex.Text;
                        insertOrUpdate.PlaceofStudyAndWork = PlaceStydy.Text;
                        insertOrUpdate.profAthlets = profAthlets.Text;
                        insertOrUpdate.alcohol = alcohol.Text;
                        insertOrUpdate.livingСonditions = livingСonditions.Text;
                        insertOrUpdate.smoke = smoking.Text;
                        insertOrUpdate.injuries = Injury.Text;
                        insertOrUpdate.housing = livingСonditions.Text;
                        insertOrUpdate.sports_id = Convert.ToInt32(sportCmb.SelectedValue);
                        insertOrUpdate.sportTeam_id = Convert.ToInt32(sportTeamCmb.SelectedValue);
                        insertOrUpdate.education_id = Convert.ToInt32(education.SelectedValue);
                        insertOrUpdate.rank_id = Convert.ToInt32(rank.SelectedValue);
                        insertOrUpdate.pastIllnes = pastIllnesTxtb.Text;
                        insertOrUpdate.operations = operationsTxtbx.Text;

                        db.SaveChanges();

                        var rrr = this.DataContext;
                        System.Diagnostics.Debug.WriteLine(" DataContext  " + rrr.ToString() );
                    }
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(" ex  " + ex); }
        }
    
}
    
}
