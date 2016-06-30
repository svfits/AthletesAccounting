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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AthletesAccounting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Grid_Update_Click(object sender, RoutedEventArgs e)
        {

            this.DataContext = null;
        }

        /// <summary>
        ////загрузка видов спорта 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                    var  result1 = db.SportTeam
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

        private void comboBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //if (comboBox.Text.Length < 2)
            //{
            //    //comboBox.ItemsSource = null;
            //    return;
            //}
            //   List<Athletes> result = null;
            //comboBox.ItemsSource = null;
            try
            {
                using (UserContext db = new UserContext())
                {
                 var result = db.Athletes
                    .AsEnumerable()                  
                    .Where(c => c.fam.ToLower().StartsWith(comboBox.Text.ToString()))
                    .Select(c => new
                    {
                        c.id,
                        c.fam,
                        c.name,
                        c.parent,                        
                        c.DOB              
                    }
                    )                    
                    .Take(20)
                    .ToList()
                    ;
                                    
                    comboBox.SelectedIndex = -1;
                    comboBox.IsDropDownOpen = true;
                    comboBox.ItemsSource = result;
                }               
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// высчитываем возраст спортсмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DOB_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {          
            DateTime newDate = DateTime.Now;          
            int DOBAthlets = DOB.SelectedDate.Value.Year;
            txtbAge.Text = (DateTime.Now.Year - DOBAthlets).ToString();
        }

        /// <summary>
        /// выбор после поиска 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                       .Where(c => c.id == Convert.ToInt32(comboBox.SelectedValue))                       
                       .FirstOrDefault()
                       ;
                    //System.Diagnostics.Debug.WriteLine(result.name + "    select   " + result.Sports.sports );
                    this.DataContext = result;
                    System.Diagnostics.Debug.WriteLine(result.name + "    select11111111111111111111111111111111111111111111111   " + result.education_id);
                    //sport.SelectedIndex = Convert.ToInt32(result.sports_id);
                    //orgNameAthlet.SelectedIndex = 3;
                    //sportCmb.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

          
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            MessageBox.Show(menuItem.Header.ToString());

            Handbook handbook = new Handbook();
            handbook.Show();
        }

        private void exportExcel(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            MessageBox.Show(menuItem.Header.ToString());
        }

        private void importExcel(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            MessageBox.Show(menuItem.Header.ToString());
        }

        private void btnSaveAthlets_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (UserContext db = new UserContext())
                {
                    if (comboBox.Text.Length <= 0)
                    {
                        System.Diagnostics.Debug.WriteLine(comboBox.Text.Length + " добавим спортсмена");
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
                    System.Diagnostics.Debug.WriteLine("обновим спортмена  " + comboBox.SelectedValue);
                    var ss = Convert.ToInt32(comboBox.SelectedValue);

                    var AthletUpdate = db.Athletes
                        .Where(c => c.id == ss)
                        .FirstOrDefault();

                    AthletUpdate.name = Name.Text;
                    AthletUpdate.fam = Fam.Text;
                    AthletUpdate.parent = Parent.Text;
                    AthletUpdate.adress = Adres.Text;
                    AthletUpdate.telefon = Telefon.Text;
                    AthletUpdate.DOB = DOB.SelectedDate.Value;
                    AthletUpdate.sex = sex.Text;
                    AthletUpdate.PlaceofStudyAndWork = PlaceStydy.Text;
                    AthletUpdate.profAthlets = profAthlets.Text;
                    AthletUpdate.alcohol = alcohol.Text;
                    AthletUpdate.livingСonditions = livingСonditions.Text;
                    AthletUpdate.smoke = smoking.Text;
                    AthletUpdate.injuries = Injury.Text;
                    AthletUpdate.housing = livingСonditions.Text;
                    AthletUpdate.sports_id = Convert.ToInt32(sportCmb.SelectedValue);
                    AthletUpdate.sportTeam_id = Convert.ToInt32(sportTeamCmb.SelectedValue);
                    AthletUpdate.education_id = Convert.ToInt32(education.SelectedValue);
                    AthletUpdate.rank_id = Convert.ToInt32(rank.SelectedValue);
                    AthletUpdate.pastIllnes = pastIllnesTxtb.Text;
                    AthletUpdate.operations = operationsTxtbx.Text;

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private void sport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {
                System.Diagnostics.Debug.WriteLine(sportCmb.SelectedValue + "  22222222222222222222222222");
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine(sportCmb.SelectedValue + "  22222222222222222222222222");
            }
        }

        private void pastIllnessesBtn_Click(object sender, RoutedEventArgs e)
        {
            //PastIllnesses.SelectedValue.ToString
        }

        private void orgNameAthlet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(sportTeamCmb.SelectedValue + "     1");
        }
    }
}
