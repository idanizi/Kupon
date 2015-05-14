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
        MainWindow main;
        BL server;
        public login(MainWindow main)
        {
            InitializeComponent();
            server =  new BL();
            this.main = main;
          
        }
        private void loginClick(object sender, RoutedEventArgs e)
        {
            

            try{
             
            if(username_TB.Text != "" & password_PB.Password != ""){
           User user = server.logIn(username_TB.Text,password_PB.Password,main.UserLatitude,main.UserLongtitude);
                     
            if (user != null) { 
                               main.CurrUser = user;
                               DialogResult = true;
                 this.Close();
                                } 
                           else MessageBox.Show("incorrect username or password,please try again", "error");
                           }
                    else MessageBox.Show("illegale input", "error");
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
                main.CurrUser = new User("Ghost");

            }
           
        }

        private void IDTB_GotFocus(object sender, RoutedEventArgs e)
        {
            username_TB.Text = "";
        }

        private void IDTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       
        }
    }

    

          
    

