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
            updateDataGrid();
           
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
            ////comboBox.ItemsSource = null;
            //try
            //{
            //    using (UserContext db = new UserContext())
            //    {
            //     var result = db.Athletes
            //        .AsEnumerable()                  
            //        .Where(c => c.fam.ToLower().StartsWith(comboBox.Text.ToString()))
            //        .Select(c => new
            //        {
            //            c.id,
            //            c.fam,
            //            c.name,
            //            c.parent,                        
            //            c.DOB              
            //        }
            //        )                    
            //        .Take(20)
            //        .ToList()
            //        ;
                                    
            //        //comboBox.SelectedIndex = -1;
            //        comboBox.IsDropDownOpen = true;
            //        comboBox.ItemsSource = result;
            //    }               
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine(ex.ToString());
            //}
        }
        
        /// <summary>
        /// выбор после поиска 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {        
            //try
            //{
            //    using (UserContext db = new UserContext())
            //    {
            //        var result = db.Athletes
            //           .Include("Sports")
            //           .Include("SportTeam")
            //           .Include("Rank")
            //           .Include("Education")                     
            //           .AsEnumerable()                       
            //           .Where(c => c.id == Convert.ToInt32(comboBox.SelectedValue))                       
            //           .FirstOrDefault()
            //           ;
                 
            //        this.DataContext = result;
            //        System.Diagnostics.Debug.WriteLine(result.name + "    select11111111111111111111111111111111111111111111111   " + result.education_id);
                                      
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine(ex.ToString());
            //}

          
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
            catch { }
        }

        private void addAthlets_Click(object sender, RoutedEventArgs e)
        {
            EditAthletesWindows EditAthletesWin = new EditAthletesWindows();
            EditAthletesWin.ShowDialog();
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
                        .AsEnumerable()
                        .Take(20)
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
            try
            {
                using (UserContext db = new UserContext())
                {
                    var result = db.Athletes
                       .Include("Sports")               
                       .AsEnumerable()
                       .Where(c => c.fam.ToLower().StartsWith(Text_Filtr_DataGrid_Athletes.Text))
                       .ToList()
                       ;

                    dataGridALLAthlets.ItemsSource = result;
                    System.Diagnostics.Debug.WriteLine( "  result.id   " + result.FirstOrDefault());

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}
