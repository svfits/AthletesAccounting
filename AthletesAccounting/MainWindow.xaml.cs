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

            //gridAll.MaxHeight = SystemParameters.WorkArea.Height - 150;
            gridAll.MaxWidth = SystemParameters.WorkArea.Width - 150;
        }

        private void Btn_Grid_Update_Click(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }

        /// <summary>
        ////загрузка видов спорта 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //SizeToContent = SizeToContent.WidthAndHeight;
            SizeToContent = SizeToContent.Width;

           updateDataGrid();
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
            

        private void MenuItem_Click_exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void dataGridALLAthlets_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (dataGridALLAthlets.SelectedItem == null) return;
                var selectedPerson = dataGridALLAthlets.SelectedItem as Athletes;
                //  MessageBox.Show(string.Format("The Person you double clicked on is - Name: {0}, Address: {1}, Email: {2}", selectedPerson.name, selectedPerson.id, selectedPerson.telefon));

                EditAthletesWindows EditAthletesWin = new EditAthletesWindows(selectedPerson.id);
                EditAthletesWin.ShowDialog();

                updateDataGrid();
                Text_Filtr_DataGrid_Athletes.Text = String.Empty;
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("  что то произошло во время редактирования во втором окне ");
            }
        }

        private void addAthlets_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditAthletesWindows EditAthletesWin = new EditAthletesWindows(null);
                EditAthletesWin.ShowDialog();
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("  что то произошло во время редактирования " );
            }
        }

        /// <summary>
        /// обновление datagrid или загрузка
        /// </summary>
        public void updateDataGrid()
        {
            try {
                using (UserContext db = new UserContext())
                {
                    var result = db.Athletes
                        .Include("Sports")
                        .Include("Couch")
                        .AsEnumerable()
                        .Take(300)
                        .ToList()
                        ;
                   
                    dataGridALLAthlets.ItemsSource = result;                  
                       
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                    }
            
        }
        /// <summary>
        /// тект фильтр 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Text_Filtr_Grid_Log_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Text_Filtr_DataGrid_Athletes.Text.Length >= 3)
            {
                if (radioButtonFIO.IsChecked == true)
                {
                    try
                    {
                        using (UserContext db = new UserContext())
                        {
                            var result = db.Athletes
                               .Include("Sports")
                               .Include("Couch")
                               .AsEnumerable()
                               .Where(c => c.fam.ToLower().StartsWith(Text_Filtr_DataGrid_Athletes.Text))
                               .Take(150)
                               .ToList()
                               ;

                            dataGridALLAthlets.ItemsSource = result;
                            System.Diagnostics.Debug.WriteLine("  количество фамилией " + result.Count);

                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                    }
                }
                else if (radioButton1Sport.IsChecked == true)
                {
                    using (UserContext db = new UserContext())
                    {
                        var result = db.Athletes
                           .Include("Sports")
                           .Include("Couch")
                           .AsEnumerable()
                           .Where(c => c.Sports.sport.ToString().ToLower().StartsWith(Text_Filtr_DataGrid_Athletes.Text))
                           //.Take(30)
                           .ToList()
                           ;

                        dataGridALLAthlets.ItemsSource = result;
                        System.Diagnostics.Debug.WriteLine("  количество спортсменов   "  + result.Count);

                    }
               
                }
                else if (radioButtonDateOsmotr.IsChecked == true)
                {
                    using (UserContext db = new UserContext())
                    {
                        var result = db.Athletes
                           .Include("Sports")
                           .Include("Couch")
                           .AsEnumerable()
                           .Where(c => c.dateTimeNextProbe <= DateTime.Now.AddDays(Convert.ToInt32(Text_Filtr_DataGrid_Athletes.Text)))
                           .Take(30)
                           .ToList()
                           ;

                        dataGridALLAthlets.ItemsSource = result;
                        System.Diagnostics.Debug.WriteLine("  количество спортсменов   " + result.Count);

                    }
                }
                else if (radioButtonCouch.IsChecked == true)
                {
                    using (UserContext db = new UserContext())
                    {
                        var result = db.Athletes
                           .Include("Sports")
                           .Include("Couch")
                           .AsEnumerable()
                           .Where(c => c.Couch.fam.ToString().ToLower().StartsWith(Text_Filtr_DataGrid_Athletes.Text))
                           //.Take(30)
                           .ToList()
                           ;

                        dataGridALLAthlets.ItemsSource = result;
                        System.Diagnostics.Debug.WriteLine("  количество спортсменов   " + result.Count);

                    }
                }
            
            }
        }
    }
}
