using AthletesAccounting.DataBase;
using System;
using System.Collections;
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

           updateDataGrid();
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
            try
            {
                DateTime newDate = DateTime.Now;
                //int DOBAthlets = DOB.SelectedDate.Value.Year;
                //txtbAge.Text = (DateTime.Now.Year - DOBAthlets).ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
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
                 
                    this.DataContext = result;
                    System.Diagnostics.Debug.WriteLine(result.name + "    select11111111111111111111111111111111111111111111111   " + result.education_id);
                                      
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
            ///MessageBox.Show(menuItem.Header.ToString());
                   
            ///MessageBox.Show(menuItem.Header.ToString());

            Handbook handbook = new Handbook(menuItem.Header.ToString());
            handbook.ShowDialog();
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
            //try
            //{
            //    using (UserContext db = new UserContext())
            //    {
            //        if (comboBox.Text.Length <= 0)
            //        {
            //            System.Diagnostics.Debug.WriteLine(comboBox.Text.Length + " добавим спортсмена");
            //            db.Athletes.Add(new Athletes()
            //            {
            //                name = Name.Text,
            //                fam = Fam.Text,
            //                parent = Parent.Text,
            //                adress = Adres.Text,
            //                telefon = Telefon.Text,
            //                DOB = DOB.SelectedDate.Value,
            //                sex = sex.Text,                          
            //                PlaceofStudyAndWork = PlaceStydy.Text,
            //                profAthlets = profAthlets.Text,
            //                alcohol = alcohol.Text,
            //                livingСonditions = livingСonditions.Text,
            //                smoke = smoking.Text,
            //                injuries = Injury.Text,
            //                housing = livingСonditions.Text,
            //                sports_id = Convert.ToInt32(sportCmb.SelectedValue),
            //                sportTeam_id = Convert.ToInt32(sportTeamCmb.SelectedValue),
            //                education_id = Convert.ToInt32(education.SelectedValue),
            //                rank_id = Convert.ToInt32(rank.SelectedValue),
            //                pastIllnes = pastIllnesTxtb.Text,
            //                operations = operationsTxtbx.Text
            //            });
            //            db.SaveChanges();
            //        }
            //        System.Diagnostics.Debug.WriteLine("обновим спортмена  " + comboBox.SelectedValue);
            //        var ss = Convert.ToInt32(comboBox.SelectedValue);

            //        var AthletUpdate = db.Athletes
            //            .Where(c => c.id == ss)
            //            .FirstOrDefault();

            //        AthletUpdate.name = Name.Text;
            //        AthletUpdate.fam = Fam.Text;
            //        AthletUpdate.parent = Parent.Text;
            //        AthletUpdate.adress = Adres.Text;
            //        AthletUpdate.telefon = Telefon.Text;
            //        AthletUpdate.DOB = DOB.SelectedDate.Value;
            //        AthletUpdate.sex = sex.Text;
            //        AthletUpdate.PlaceofStudyAndWork = PlaceStydy.Text;
            //        AthletUpdate.profAthlets = profAthlets.Text;
            //        AthletUpdate.alcohol = alcohol.Text;
            //        AthletUpdate.livingСonditions = livingСonditions.Text;
            //        AthletUpdate.smoke = smoking.Text;
            //        AthletUpdate.injuries = Injury.Text;
            //        AthletUpdate.housing = livingСonditions.Text;
            //        AthletUpdate.sports_id = Convert.ToInt32(sportCmb.SelectedValue);
            //        AthletUpdate.sportTeam_id = Convert.ToInt32(sportTeamCmb.SelectedValue);
            //        AthletUpdate.education_id = Convert.ToInt32(education.SelectedValue);
            //        AthletUpdate.rank_id = Convert.ToInt32(rank.SelectedValue);
            //        AthletUpdate.pastIllnes = pastIllnesTxtb.Text;
            //        AthletUpdate.operations = operationsTxtbx.Text;

            //        db.SaveChanges();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            //    System.Diagnostics.Debug.WriteLine(ex.ToString());
            //}
        }

        private void sport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try {
            //    System.Diagnostics.Debug.WriteLine(sportCmb.SelectedValue + "  22222222222222222222222222");
            //}
            //catch
            //{
            //    System.Diagnostics.Debug.WriteLine(sportCmb.SelectedValue + "  22222222222222222222222222");
            //}
        }

        private void pastIllnessesBtn_Click(object sender, RoutedEventArgs e)
        {
            //PastIllnesses.SelectedValue.ToString
        }

        private void orgNameAthlet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(sportTeamCmb.SelectedValue + "     1");
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //try
            //{
            //    DateTime newDate = DateTime.Now;
            //    int DOBAthlets = mainSportDateDatepicker.SelectedDate.Value.Year;
            //    mainSportDateLbl.Content = (DateTime.Now.Year - DOBAthlets).ToString();
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine(ex.ToString());
            //}
        }
      

        private void MenuItem_Click_exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void dataGridALLAthlets_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridALLAthlets.SelectedItem == null) return;
            var selectedPerson = dataGridALLAthlets.SelectedItem as Athletes;
            //  MessageBox.Show(string.Format("The Person you double clicked on is - Name: {0}, Address: {1}, Email: {2}", selectedPerson.name, selectedPerson.id, selectedPerson.telefon));
                
            EditAthletesWindows EditAthletesWin = new EditAthletesWindows(selectedPerson.id);
            EditAthletesWin.ShowDialog();

            updateDataGrid();

        }

        private void addAthlets_Click(object sender, RoutedEventArgs e)
        {
            EditAthletesWindows EditAthletesWin = new EditAthletesWindows();
            EditAthletesWin.ShowDialog();
        }

        /// <summary>
        /// обновление datagrid или загрузка
        /// </summary>
        private void updateDataGrid()
        {
            using (UserContext db = new UserContext())
            {
                var result = db.Athletes
                     .Include("Sports")
                    .AsEnumerable()
                    .Take(20)
                    .ToList()
                    ;
                dataGridALLAthlets.ItemsSource = null;
                dataGridALLAthlets.ItemsSource = result;
            }
        }
    }
}
