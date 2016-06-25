using AthletesAccounting.DataBase;
using AthletesAccounting.TimeDateAge;
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
                        name = "Петр",
                        fam = "Кристофорович",
                        parent = "Крузенштерн",
                        age = 47,
                        adress = "Иркутская обл. г. Ангарск 82 квартал дом 72 кв. 179",
                        telefon = "89500810322",
                        DOB = DateTime.Now
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           SizeToContent = SizeToContent.Height;
        }

        //private void Text_Filtr_DataGrid_Log_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    if (Text_Filtr_DataGrid_Log.Text.Length < 2)
        //    {
        //        return;
        //    }

          
        //    //IEnumerable<Athletes> result = null;
        //    try
        //    {
        //        using (UserContext db = new UserContext())
        //        {
        //            var result = db.Athletes.FirstOrDefault();                    
        //            //.AsEnumerable()
        //            // .Where(c => c.name.ToLower().Contains(Text_Filtr_DataGrid_Log.Text.ToString()))
        //            //.Take(20)
        //            //.ToList()
        //            ;

        //            //System.Diagnostics.Debug.WriteLine(result.First());
        //            this.DataContext = result;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.ToString());
        //    }           
        //}

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

                    //List<string> result1 = new List<string>();
                    //result.ForEach(elem =>
                    //{

                    //    //   elem.ToString().Replace("fam =", "").Replace("name =", "").Replace("parent =", "").Replace("DOB =", "ДР");
                    //    elem.fam.Replace("fam =", "");
                    //    elem.name.Replace("name =", "");
                    //    elem.parent.Replace("parent =", "");
                    //    result1.Add(elem.fam.Replace("fam =", "") + "   " + elem.name.Replace("name =", "") + "  " + elem.parent.Replace("parent =", "") + "    " + elem.DOB);
                    //    //   elem.DOB.toString().Replace("DOB =", "ДР");
                    //    System.Diagnostics.Debug.WriteLine(elem.fam);
                    //});               

                    //comboBox.DisplayMemberPath = "name";
                    //comboBox.DisplayMemberPath = "fam";
                    //comboBox.DisplayMemberPath = "DOB";
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
                       .AsEnumerable()
                       .Where(c => c.id == Convert.ToInt32( comboBox.SelectedValue))
                       .FirstOrDefault()
                       ;
                    System.Diagnostics.Debug.WriteLine(result.name + "    select   " + result.fam + result.Injuries + result.DOB);
                    this.DataContext = result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

          
        }

        private void comboBox_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            MessageBox.Show(selectedItem.Content.ToString());
        }
    }
}
