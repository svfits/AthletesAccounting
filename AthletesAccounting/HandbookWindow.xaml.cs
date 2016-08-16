using AthletesAccounting.DataBase;
using System;
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
    /// Interaction logic for Handbook.xaml
    /// </summary>
    public partial class Handbook : Window
    {
        UserContext db = new UserContext();

        public Handbook(string txt)
        {
            InitializeComponent();
            //MessageBox.Show(txt);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SizeToContent = SizeToContent.WidthAndHeight;

            try
            {            
                    var myList = db.Sports
                       .AsEnumerable()                      
                       .ToList()
                       ;

                dataGrid.ItemsSource = myList;
                //dataGrid.DataContext = myList;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
               
        /// <summary>
        /// обьект который изменился
        /// </summary>
        Sports objToAdd;
        /// <summary>
        /// узнаем что изменилось в таблице сохраним
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          objToAdd = dataGrid.SelectedItem as Sports;
        }

        private void dataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {
                var Res = MessageBox.Show("Сохранить изменения?", "Сохранить?", MessageBoxButton.YesNo);
                if (Res == MessageBoxResult.Yes)
                {
                    var conn = db.Sports.Where(c => c.sports_code == objToAdd.sports_code).FirstOrDefault();

                    if (conn == null)
                    {                       
                        db.Sports.Add(objToAdd);
                    }
                    else
                    {
                        conn.sports_code = objToAdd.sports_code;
                        conn.sport = objToAdd.sport;
                        db.Entry(conn).State = System.Data.Entity.EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
