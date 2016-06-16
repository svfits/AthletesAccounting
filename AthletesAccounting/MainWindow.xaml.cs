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
            try
            {
                using (UserContext db = new UserContext())
                {
                    db.Athletes.Add(new Athletes()
                    {
                        name = "Семен",
                        fam = "Семенович",
                        parent = "Семенович",
                        age = 21,
                        adress = "ghjghjghjjjjjjjjjjjjj",
                        telefon = "89500810322"
                    });
                    db.SaveChanges();
                }
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                System.Diagnostics.Debug.WriteLine(ex.ToString());                
            }
         
                //db.Database.Create();

                //db.claim.Add(new claim()
                //{
                //    UserNameFrom = User.Identity.Name,
                //    ClaimeName = ClaimeName,
                //    UserNameWhom = UserNameWhom,
                //    claimBody = claimBody,
                //    dataTimeOpen = DateTime.Now,
                //    dataTimeEnd = DateTime.Now.AddMinutes(5),
                //    evants = "заявка создана",
                //    parents = parents,
                //    category = category
                //});

                //db.SaveChanges();

            
            }
    }
}
