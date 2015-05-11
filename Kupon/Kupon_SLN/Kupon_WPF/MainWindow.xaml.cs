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
using Util;
using BSL;
using System.Device.Location;


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
        private static User user = null;
        private static double userLatitude = 0;
        private static double userLongtitude = 0;


        GeoCoordinateWatcher mGeoWatcher = new GeoCoordinateWatcher();
        CivicAddress add = new CivicAddress();


        public User CurrUser { get { return user; } set { user = value; } }

        public double UserLatitude { get { return userLatitude; } set { userLatitude = value; } }

        public double UserLongtitude { get { return userLongtitude; } set { userLongtitude = value; } }

        private showCouponRecords couponRecords;
        public IBSL server;

        public MainWindow()
        {
            InitializeComponent();
            server = new BL();
            mGeoWatcher.Start();
            mGeoWatcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
            mGeoWatcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
        }

        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        { 
            userLatitude_L.Content = mGeoWatcher.Position.Location.Latitude.ToString();
            userLongtitude_L.Content = mGeoWatcher.Position.Location.Longitude.ToString();
        }

        private void mainWindow_Initialized(object sender, EventArgs e)
        {
            reInitializedData();
        }

        private void reInitializedData()
        {
           

            //patient can't add new records
            couponRecords = new showCouponRecords(this);
            if (user.GetType is Admin)
            {
                myKupons_BTN.Visibility = System.Windows.Visibility.Hidden;
                addBusiness_BTN.Visibility = System.Windows.Visibility.Visible;
                addNewKupon_BTN.Visibility = System.Windows.Visibility.Visible;
                saveChanges_BTN.Visibility = Visibility.Visible;
                register_BTN.Visibility = System.Windows.Visibility.Hidden;
                userSetting_BTN.Visibility = System.Windows.Visibility.Hidden;
                insertCoupon_BTN.Visibility = System.Windows.Visibility.Hidden;
                 login_BTN.Content = "Logout";
            }
            else if (user.GetType is Manager)
            {

                myKupons_BTN.Visibility = System.Windows.Visibility.Visible;
                addBusiness_BTN.Visibility = System.Windows.Visibility.Hidden;
                addNewKupon_BTN.Visibility = System.Windows.Visibility.Visible;
                saveChanges_BTN.Visibility = Visibility.Hidden;
                register_BTN.Visibility = System.Windows.Visibility.Hidden;
                userSetting_BTN.Visibility = System.Windows.Visibility.Hidden;
                insertCoupon_BTN.Visibility = System.Windows.Visibility.Visible;
                login_BTN.Content = "Logout";
            }
            else if (user.GetType is Client)
            {
                myKupons_BTN.Visibility = System.Windows.Visibility.Visible;
                addBusiness_BTN.Visibility = System.Windows.Visibility.Hidden;
                addNewKupon_BTN.Visibility = System.Windows.Visibility.Hidden;
                saveChanges_BTN.Visibility = Visibility.Hidden;
                register_BTN.Visibility = System.Windows.Visibility.Hidden;
                userSetting_BTN.Visibility = System.Windows.Visibility.Visible;
                insertCoupon_BTN.Visibility = System.Windows.Visibility.Hidden;
                login_BTN.Content = "Logout";
            }
            else
            {
                myKupons_BTN.Visibility = System.Windows.Visibility.Hidden;
                addBusiness_BTN.Visibility = System.Windows.Visibility.Hidden;
                addNewKupon_BTN.Visibility = System.Windows.Visibility.Hidden;
                saveChanges_BTN.Visibility = Visibility.Hidden;
                register_BTN.Visibility = System.Windows.Visibility.Hidden;
                userSetting_BTN.Visibility = System.Windows.Visibility.Hidden;
                insertCoupon_BTN.Visibility = System.Windows.Visibility.Hidden;
                login_BTN.Content = "Login";
            }
            buttons_GRD.Arrange(new Rect());
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
            if (login_BTN.Content == "Login")
            {
                try
                {
                    login loginWindow = new login(this);
                    loginWindow.ShowDialog();
                    //if login succesful
                    reInitializedData();
                    welcome_TB.Text = "welcome "  + user.getName();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception accured. please try again " + ex);
                }
            
        }else{
        reInitializedData();
        }

    }

        private void saveChanges_BTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (Kupon kupon in couponRecords.dataList)
                {
                    server.updateKupon(kupon);
                }
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
            forms.add.addNewKupon registerWindow = new forms.add.addNewKupon(this);
            registerWindow.ShowDialog();
        }

        private void userSetting_BTN_Click(object sender, RoutedEventArgs e)
        {
            mainRecordFrame.Navigate(new UserSettingPage());
        }


        private void addBusiness_BTN_Click(object sender, RoutedEventArgs e)
        {
            forms.add.addBusiness registerWindow = new forms.add.addBusiness(this);
            registerWindow.ShowDialog();
        }

        private void myKupons_BTN_Copy_Click(object sender, RoutedEventArgs e)
        {
           // List<Kupon> myKuponList = server.searchCoupon(new List<String> { "user" }, new List<String> { userName });
            mainRecordFrame.Navigate(couponRecords);
        }

        private void searchKupons_BTN_Click(object sender, RoutedEventArgs e)
        {
            forms.search.searchKupon searchKuponWin = new forms.search.searchKupon(this);
            if (searchKuponWin != null) {
                searchKuponWin.Owner = this;
            searchKuponWin.ShowDialog();

            }
        }

        private void myKupons_BTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void insertCoupon_BTN_Click(object sender, RoutedEventArgs e)
        {
            forms.show.insertCoupon registerWindow = new forms.show.insertCoupon(this);
            registerWindow.ShowDialog();
        }




        internal static void setData(List<Kupon> kupons)
        {
            throw new NotImplementedException();
        }

        internal static void setKuponData(List<Kupon> kupons)
        {
            throw new NotImplementedException();
        }
    }
}
