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
        private readonly string _nameHandbook;

        public Handbook(string txt)
        {
            InitializeComponent();
            _nameHandbook = txt;
            //MessageBox.Show(txt);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SizeToContent = SizeToContent.WidthAndHeight;

            switch (_nameHandbook)
            {
                case "Виды спорта":
                    dataGridSports.Visibility = Visibility.Visible;
                    //dataGridSports.Width = 300;
                    load_DataGrid_Sports();
                    this.Title = "Справочник - виды спорта";                  
                    break;
                case "Спортколлектив (ДЮСШ)":
                    dataGridSportTeam.Visibility = Visibility.Visible;
                    dataGridSports.Width = 300;
                    load_DataGrid_SportTeam();
                    this.Title = "Справочник - спортколлектив (ДЮСШ)";                 
                    break;
                case "Образование":
                    dataGridEducation.Visibility = Visibility.Visible;
                    dataGridSports.Width = 300;
                    load_DataGrid_Education();
                    this.Title = "Справочник - образование";                   
                    break;
                case "Разряды":
                    dataGridRank.Visibility = Visibility.Visible;
                    dataGridSports.Width = 300;
                    load_DataGrid_Rank();
                    this.Title = "Справочник - разряды";
                    break;
                case "Тренер":
                    dataGridCouch.Visibility = Visibility.Visible;
                  
                    load_DataGrid_Couch();
                    this.Title = "Справочник - тренер";
                    break;
            }
          
        }

        private void load_DataGrid_SportTeam()
        {
            try
            {
                var myList = db.SportTeam
                   .AsEnumerable()
                   .ToList()
                   ;

                dataGridSportTeam.ItemsSource = myList;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private void load_DataGrid_Rank()
        {
            try
            {
                var myList = db.Rank
                   .AsEnumerable()
                   .ToList()
                   ;

                dataGridRank.ItemsSource = myList;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private void load_DataGrid_Education()
        {
            try
            {
                var myList = db.Education
                   .AsEnumerable()
                   .ToList()
                   ;

                dataGridEducation.ItemsSource = myList;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private void load_DataGrid_Couch()
        {
            try
            {
                var myList = db.Couch
                   .Include("Sports")
                   .AsEnumerable()                                      
                   .ToList()
                   ;

                dataGridCouch.ItemsSource = myList;
                var myList1 = db.Sports
                    .AsEnumerable()
                    .ToList()
                    ;
                comboxColomn.ItemsSource = myList1;            
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private void load_DataGrid_Sports()
        {
            try
            {
                var myList = db.Sports                 
                   .AsEnumerable()
                   //.Select(c => c.sport)                      
                   .ToList()
                   ;

                dataGridSports.ItemsSource = myList;
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
        Sports objToAddSports;
        Education objToAddEducation;
        Rank objToAddRank;
        SportTeam objToAddSportTeam;
        Couch objToAddCouch;
        

        /// <summary>
        /// узнаем что изменилось в таблице сохраним
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
            

        private void dataGridCouch_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {
                var Res = MessageBox.Show("Сохранить изменения?", "Сохранить?", MessageBoxButton.YesNo);
                if (Res == MessageBoxResult.Yes)
                {
                    var conn = db.Couch.Where(c => c.id_couch == objToAddCouch.id_couch).FirstOrDefault();
                    var conn1 = db.Couch.Where(c => c.name == objToAddCouch.name &&
                    c.parent == objToAddCouch.parent && c.fam == objToAddCouch.fam && c.sport_code == objToAddCouch.sport_code).FirstOrDefault();
                   
                    int idMax = -1;
                    if (conn == null && objToAddCouch.fam != "" && objToAddCouch.name != "" && objToAddCouch.parent != "" && conn1 == null)
                    {
                        db.Couch.Add(new Couch {
                            id_couch = 0,
                            fam = objToAddCouch.fam,
                            name = objToAddCouch.name,
                            parent = objToAddCouch.parent,
                            sport_code = objToAddCouch.sport_code
                        });
                    }
                    else
                    {
                        idMax = db.Couch.ToList().Select(c => c.id_couch).Last();
                    }

                    if (idMax >= 0 && conn1 == null)
                    {
                        idMax = idMax + 1;
                        db.Couch.Add(new Couch { id_couch = idMax, fam = objToAddCouch.fam, name = objToAddCouch.name, parent = objToAddCouch.parent });
                    }
                    else if (conn != null && objToAddCouch.fam != "" && objToAddCouch.name != "" && objToAddCouch.parent != "" )
                    {
                        conn.id_couch = objToAddCouch.id_couch;
                        conn.name = objToAddCouch.name;
                        conn.fam = objToAddCouch.fam;
                        conn.parent = objToAddCouch.parent;
                        conn.sport_code = objToAddCouch.sport_code;

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

        private void dataGridRank_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {
                var Res = MessageBox.Show("Сохранить изменения?", "Сохранить?", MessageBoxButton.YesNo);
                if (Res == MessageBoxResult.Yes)
                {
                    var conn = db.Rank.Where(c => c.rank_code == objToAddRank.rank_code).FirstOrDefault();
                    var conn1 = db.Rank.Where(c =>c.rank == objToAddRank.rank.Trim()).FirstOrDefault();
                    int idMax = -1;
                    if (conn == null && objToAddRank.rank != "" && conn1 == null )
                    {
                        db.Rank.Add(new Rank { rank_code = 0, rank = objToAddRank.rank });
                    }
                    else
                    {
                        idMax = db.Rank.ToList().Select(c => c.rank_code).Last();
                    }

                    if (idMax >= 0 && conn1 == null)
                    {
                        db.Rank.Add(new Rank { rank_code = idMax + 1, rank = objToAddRank.rank });
                    }
                    else if (conn != null)
                    {
                        conn.rank_code = objToAddRank.rank_code;
                        conn.rank = objToAddRank.rank;
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

        private void dataGridSportTeam_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {
                var Res = MessageBox.Show("Сохранить изменения?", "Сохранить?", MessageBoxButton.YesNo);
                if (Res == MessageBoxResult.Yes)
                {
                    var conn = db.SportTeam.Where(c => c.sportTeam_code == objToAddSportTeam.sportTeam_code).FirstOrDefault();
                    var conn1 = db.SportTeam.Where(c => c.sportTeam == objToAddSportTeam.sportTeam).FirstOrDefault();
                    int idMax = -1;
                    if (conn == null && objToAddSportTeam.sportTeam != "" && conn1 == null)
                    {
                        db.SportTeam.Add(new SportTeam { sportTeam_code = 0, sportTeam = objToAddSportTeam.sportTeam });
                    }
                    else
                    {
                        idMax = db.SportTeam.ToList().Select(c => c.sportTeam_code).Last();
                    }

                    if (idMax >= 0 && conn1 == null)
                    {
                        db.SportTeam.Add(new SportTeam { sportTeam_code = idMax + 1, sportTeam = objToAddSportTeam.sportTeam });
                    }
                    else if (conn != null)
                    {
                        conn.sportTeam_code = objToAddSportTeam.sportTeam_code;
                        conn.sportTeam = objToAddSportTeam.sportTeam;
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

        private void dataGridEducation_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {
                var Res = MessageBox.Show("Сохранить изменения?", "Сохранить?", MessageBoxButton.YesNo);
                if (Res == MessageBoxResult.Yes)
                {
                    var conn = db.Education.Where(c => c.education_code == objToAddEducation.education_code).FirstOrDefault();
                    var conn1 = db.Education.Where(c => c.education == objToAddEducation.education).FirstOrDefault();
                    int idMax = -1;
                    if (conn == null && objToAddEducation.education != "" && conn1 == null)
                    {
                        db.Education.Add(new Education { education_code = 0, education = objToAddEducation.education });
                    }
                    else
                    {
                        idMax = db.Education.ToList().Select(c => c.education_code).Last();
                    }

                    if (idMax >= 0 && conn1 == null)
                    {
                        db.Education.Add(new Education { education_code = idMax + 1, education = objToAddEducation.education });
                    }
                    else if (conn != null )
                    {
                        conn.education_code = objToAddEducation.education_code;
                        conn.education = objToAddEducation.education;
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

        private void dataGridSports_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {
                var Res = MessageBox.Show("Сохранить изменения?", "Сохранить?", MessageBoxButton.YesNo);
                if (Res == MessageBoxResult.Yes)
                {
                    var conn = db.Sports.Where(c => c.sports_code == objToAddSports.sports_code).FirstOrDefault();
                    var conn1 = db.Sports.Where(c => c.sport == objToAddSports.sport).FirstOrDefault();
                    int idMax = -1;
                    // первый раз заполняем таблицу
                    if (conn == null && objToAddSports.sport != "" && conn1 == null)
                    {
                        db.Sports.Add(new Sports { sports_code = 0, sport = objToAddSports.sport });
                    }
                    else
                    {
                        idMax = db.Sports.ToList().Select(c => c.sports_code).Last();
                    }

                    // не в первый раз заполняем таблицу
                    if (idMax >= 0 && conn1 == null)
                    {
                        db.Sports.Add(new Sports { sports_code = idMax + 1, sport = objToAddSports.sport });
                    }
                    else if (conn != null)
                    {
                        conn.sports_code = objToAddSports.sports_code;
                        conn.sport = objToAddSports.sport;
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

        #region зполним то что изменилось в таблицах
        private void dataGridSports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objToAddSports = dataGridSports.SelectedItem as Sports;
        }

        private void dataGridEducation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objToAddEducation = dataGridEducation.SelectedItem as Education;
        }

        private void dataGridSportTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objToAddSportTeam = dataGridSportTeam.SelectedItem as SportTeam;
        }

        private void dataGridRank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objToAddRank = dataGridRank.SelectedItem as Rank;
        }

        private void dataGridCouch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objToAddCouch = dataGridCouch.SelectedItem as Couch;
        }

        #endregion зполним то что изменилось в таблицах

            
    }
}
