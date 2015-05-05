using Kupon_WPF.forms.show;
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
using BSL;


namespace Kupon_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {

        //getters & setters
        private static String userStat = "Ghost";
        public static String UserStat { get { return userStat; } set { userStat = value; } }
       
        private static String userName { get; set; }
        public static String UserName { get { return userName; } set { userName = value; } }
        private showCouponRecords couponRecords;
        public IBSL server;

        public MainWindow()
        {
            InitializeComponent();

        }


        private void mainWindow_Initialized(object sender, EventArgs e)
        {
            reInitializedData();
        }

        private void reInitializedData()
        {
            //patient can't add new records
            if (userStat == "Admin")
            {
                couponRecords = new showCouponRecords(userStat);
                saveChanges_BTN.Visibility = Visibility.Visible;
                 userSetting_BTN.IsEnabled = true;
            }
            else if (userStat == "Business")
            {
                couponRecords = new showCouponRecords("Business");
            }
            else
            {
                couponRecords = new showCouponRecords("Ghost");
                userSetting_BTN.IsEnabled = false;
            }

            mainRecordFrame.Navigate(couponRecords);
        }


        //change password
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            passChange passchange = new passChange();
            passchange.Owner = this;
            passchange.ShowDialog();

        }

     

        private void login_BTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                login loginWindow = new login();
                loginWindow.ShowDialog();
                //if login unsuccesful
                reInitializedData();
                welcome_TB.Text = "welcome " + userStat + " " + userName;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception accured. please try again " + ex);
            }
        }

        private void saveChanges_BTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                server.updateKupon(couponRecords.dataList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception accured. please try again \n" + ex);
            }
        }

        private void register_BTN_Click(object sender, RoutedEventArgs e)
        {

                forms.add.addNewUser registerWindow = new  forms.add.addNewUser();
                registerWindow.ShowDialog();
                
        }

        private void addNewKupon_BTN_Click(object sender, RoutedEventArgs e)
        {
            forms.add.addNewKupon registerWindow = new forms.add.addNewKupon(userName);
            registerWindow.ShowDialog();
        }

        private void userSetting_BTN_Click(object sender, RoutedEventArgs e)
        {
            mainRecordFrame.Navigate(new UserSettingPage());
        }


        private void addBusiness_BTN_Click(object sender, RoutedEventArgs e)
        {
            forms.add.addBusiness registerWindow = new forms.add.addBusiness(userName);
            registerWindow.ShowDialog();
        }

        private void myKupons_BTN_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchKupons_BTN_Click(object sender, RoutedEventArgs e)
        {
            forms.search.searchKupon searchKuponWin = new forms.search.searchKupon();
            searchKuponWin.ShowDialog();
        }



    }
}
