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
using Util;
using BSL;

namespace Kupon_WPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class login : Window
    {
        IBSL server;
        public login()
        {
            InitializeComponent();
      //      server = (IBSL) new object();
          
        }
        private void loginClick(object sender, RoutedEventArgs e)
        {
           // Find login = new Find();
            try
            {
                if (/*.isNumber(IDTB.Text)*/true)
                {

                    if (/*user.userIDCheck(MainWindow.UserID) || ((Convert.ToInt32(IDTB.Text) >=0) && (Convert.ToInt32(IDTB.Text) <= 4))*/true)
                    {
                        //MainWindow.UserID = Convert.ToInt32(IDTB.Text);
                        //   User user = server.connectUser(IDTB.Text, passwordPB.Password);
                        MainWindow.UserStat = "Admin";
                        /*       if (user != null) { 
                               MainWindow.UserStat = user.getStatus();
                               MainWindow.UserName = user.getFirstName() + " " + user.getLastName();
                                } 
                           else MessageBox.Show("in correct username or password,please try again", "error");
                           }*/
                    }
                    else MessageBox.Show("illegale ID,please try again", "error");
                }
                else
                {
                    MessageBox.Show("illegale ID,please try again", "error");
                }
              

                switch (MainWindow.UserStat)
                {
                    case "Admin":
                        MainWindow.UserStat = "Admin";
                        DialogResult = true;
                        this.Close();
                        break;

                    case "doctor":
                        MainWindow.UserStat = "doctor";
                        DialogResult = true;
                        this.Close();
                        break;

                    case "patient":
                        MainWindow.UserStat = "patient";
                        DialogResult = true;
                        this.Close();
                        break;

                    case "false":
                        MessageBox.Show("unknown ID or incorrect password, please try again", "unknown user or password");
                        break;

                    case "defualt":
                        MessageBox.Show("there was an error login to the database. if this error repeats, please contact your system administrator.");
                        break;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "exception");
            
            }
                
            }

      

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (DialogResult == null || !DialogResult.Value)//TRING TO EXIT without login
            {
                if (MessageBox.Show("Are you sure? if you will not log in you won't be able to buy any coupons", "Close", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }

            }
           
        }

        private void IDTB_GotFocus(object sender, RoutedEventArgs e)
        {
            IDTB.Text = "";
        }

        private void IDTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       
        }
    }

    

          
    

