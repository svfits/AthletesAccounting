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
    /// Interaction logic for Handbook.xaml
    /// </summary>
    public partial class Handbook : Window
    {
        public Handbook()
        {
            InitializeComponent();
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
                       //.Where(c => c.fam.ToLower().StartsWith(comboBox.Text.ToString()))
                       //.Select(c => new
                       //{
                       //    c.id,
                       //    c.fam,
                       //    c.name,
                       //    c.parent,
                       //    c.DOB
                       //}
                       //)
                       //.Take(20)
                       .ToList()
                       ;
                    System.Diagnostics.Debug.WriteLine(result.ToString());
                    dataGrid.ItemsSource = result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}
