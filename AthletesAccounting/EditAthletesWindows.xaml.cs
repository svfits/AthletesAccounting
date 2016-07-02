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
        public EditAthletesWindows(int id=-100)
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

        }

        private void MenuItem_Click_exit(object sender, RoutedEventArgs e)
        {

        }
    }
}
