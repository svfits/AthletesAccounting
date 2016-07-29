using AthletesAccounting.DataBase.User;
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
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private const string _salt = "P&0myWHq!";

        public AuthorizationWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// проверим логин и пароль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAuthrization_Click(object sender, RoutedEventArgs e)
        {
          if ( textBoxLogin.Text == null )
            {
                return;
            }
              
          //if ( Hash.getHashSha256FromBD(textBoxLogin.Text.Trim().ToLower()) == "" )
          //  {
          //      //тут должен сам придумать пароль
          //      MessageBox.Show("нет такого пользователя");
          //  }
          //else if ( Hash.getHashSha256FromBD(textBoxLogin.Text.Trim().ToLower()) == null )
          //  {
          //      MessageBox.Show("тут должен сам придумать пароль");
          //  }

          if ( Hash.getHashSha256(_salt + passwordTextBox.Password) == Hash.getHashSha256FromBD(textBoxLogin.Text.Trim().ToLower()))
            {
              // добро пожаловать!
              //  MessageBox.Show("// добро пожаловать!");
                MainWindow mainWin = new MainWindow(textBoxLogin.Text);
                mainWin.Show();
                this.Close();
            }
          else
            {
                //не правильный логин или пароль
                //MessageBox.Show("//не добро пожаловать!");
                lblWhat.Content = "не правильный логин и(или) пароль";              
                lblWhat.Foreground = Brushes.Red;
            }

            //string test = Hash.getHashSha256(_salt + passwordTextBox.Password);
            //textBoxLogin.Text = test;
                    
            //Hash dd = new Hash();
            //var test1 = Hash.getHashSha256FromBD(textBoxLogin.Text.Trim().ToLower());
            //MessageBox.Show(test1.ToString());
        }
    }
}
