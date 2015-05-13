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
using Microsoft.VisualBasic;
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
        private List<Business> businessList;

        GeoCoordinateWatcher mGeoWatcher = new GeoCoordinateWatcher();
        CivicAddress add = new CivicAddress();
        public List<buisnessCategory> pref = new List<buisnessCategory>();

        public User CurrUser { get { return user; } set { user = value; } }

        public double UserLatitude { get { return userLatitude; } set { userLatitude = value; } }

        public double UserLongtitude { get { return userLongtitude; } set { userLongtitude = value; } }

        private showCouponRecords couponRecords;
        public BL server;

        public MainWindow()
        {
            InitializeComponent();
            server = new BL();
           CurrUser = new User("Ghost");
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
            if (user != null)
            {
                welcome_TB.Text = "welcome " + user.getName();
            }
            else
            {
                welcome_TB.Text = "welcome ghost. Please log in";
            }
            
            if (user is Admin)
            {
                myKupons_BTN.Visibility = System.Windows.Visibility.Visible;
                myKupons_BTN.Content = "Approve new coupons";
                addBusiness_BTN.Visibility = System.Windows.Visibility.Visible;
                addNewKupon_BTN.Visibility = System.Windows.Visibility.Visible;
                saveChanges_BTN.Visibility = Visibility.Visible;
                register_BTN.Visibility = System.Windows.Visibility.Hidden;
                userSetting_BTN.Visibility = System.Windows.Visibility.Hidden;
                insertCoupon_BTN.Visibility = System.Windows.Visibility.Hidden;
                 login_BTN.Content = "Logout";
                List<Kupon> data = server.getKuponForApproval(50);
                couponRecords = new showCouponRecords(this, data);
            }
            else if (user is Manager)
            {

                myKupons_BTN.Visibility = System.Windows.Visibility.Visible;
                myKupons_BTN.Content = "My coupons";
                addBusiness_BTN.Visibility = System.Windows.Visibility.Hidden;
                addNewKupon_BTN.Visibility = System.Windows.Visibility.Visible;
                saveChanges_BTN.Visibility = Visibility.Hidden;
                register_BTN.Visibility = System.Windows.Visibility.Hidden;
                userSetting_BTN.Visibility = System.Windows.Visibility.Hidden;
                insertCoupon_BTN.Visibility = System.Windows.Visibility.Visible;
                login_BTN.Content = "Logout";
                //List<Kupon> data = server.getKuponForBusiness(user);
                //couponRecords = new showCouponRecords(this, data);
            }
            else if (user is Client)
            {
                myKupons_BTN.Visibility = System.Windows.Visibility.Visible;
                myKupons_BTN.Content = "My coupons";
                addBusiness_BTN.Visibility = System.Windows.Visibility.Hidden;
                addNewKupon_BTN.Visibility = System.Windows.Visibility.Hidden;
                saveChanges_BTN.Visibility = Visibility.Hidden;
                register_BTN.Visibility = System.Windows.Visibility.Hidden;
                userSetting_BTN.Visibility = System.Windows.Visibility.Visible;
                insertCoupon_BTN.Visibility = System.Windows.Visibility.Hidden;
                login_BTN.Content = "Logout";
                List<Kupon> data = new  List<Kupon>();
                foreach(buisnessCategory cat in ((Client)user).getFavorits()){
                    data.AddRange(server.searchKoupon(cat, UserLatitude, UserLongtitude));
                }
                couponRecords = new showCouponRecords(this, data);
            }
            else
            {
                myKupons_BTN.Visibility = System.Windows.Visibility.Hidden;
                addBusiness_BTN.Visibility = System.Windows.Visibility.Hidden;
                addNewKupon_BTN.Visibility = System.Windows.Visibility.Hidden;
                saveChanges_BTN.Visibility = Visibility.Hidden;
                register_BTN.Visibility = System.Windows.Visibility.Visible;
                userSetting_BTN.Visibility = System.Windows.Visibility.Hidden;
                insertCoupon_BTN.Visibility = System.Windows.Visibility.Hidden;
                login_BTN.Content = "Login";
                List<Kupon> data = new List<Kupon>();
               /* foreach (buisnessCategory cat in  Enum.GetValues(typeof(buisnessCategory)))
                {
                   
                    data.AddRange(server.searchKoupon(cat, UserLatitude, UserLongtitude));
                } */
                couponRecords = new showCouponRecords(this, data);
            } 
            buttons_GRD.UpdateLayout();
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
            if ((string)login_BTN.Content == "Login")
            {
                try
                {
                    login loginWindow = new login(this);
                    loginWindow.ShowDialog();
                    //if login succesful
                    reInitializedData();
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception accured. please try again " + ex);
                }
            
        }else{
            server.logOut(user.getName());
            CurrUser = null;
        reInitializedData();
        }

    }

        private void saveChanges_BTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (user is Admin)
                {

                    foreach (Kupon kupon in couponRecords.dataList)
                    {
                        server.updateKupon(kupon);
                    }


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
                registerWindow.Owner = this;
                registerWindow.ShowDialog();
                
        }

        private void addNewKupon_BTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Business bus = null;
                if (user is Manager)
                {
                    bus = server.searchManagerBusiness((Manager)user);
                }
                else if (user is Admin )
                {
                    if (businessList.Count > 0)
                    {
                        bus = businessList[0];
                    }
                    else
                    {
                        MessageBox.Show("please choose business to add the coupon to");
                        return;
                    }
                }
                forms.add.addNewKupon registerWindow = new forms.add.addNewKupon(this, bus);
                registerWindow.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void userSetting_BTN_Click(object sender, RoutedEventArgs e)
        {
            mainRecordFrame.Navigate(new UserSettingPage(this));
        }


        private void addBusiness_BTN_Click(object sender, RoutedEventArgs e)
        {
            forms.add.addBusiness registerWindow = new forms.add.addBusiness(this);
            registerWindow.ShowDialog();
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
            List<Kupon> kupons = new List<Kupon>();

            if (user is Admin)
            {
                kupons = server.getKuponForApproval(50);
            }
            else if (user is Client)
            {
                kupons = server.getKuponsForUser(user);
            }
            else if(user is Manager)
            {
                kupons = server.getKuponsForUser(user);
            }
            showCouponRecords couponRecords = new showCouponRecords(kupons);
             mainRecordFrame.Navigate(couponRecords);
        }

        private void insertCoupon_BTN_Click(object sender, RoutedEventArgs e)
        {
            forms.show.insertCoupon registerWindow = new forms.show.insertCoupon(this);
            registerWindow.ShowDialog();
        }

        public void setKuponData(List<Kupon> kupons)
        {
            showCouponRecords couponRecords = new showCouponRecords(kupons);
            mainRecordFrame.Navigate(couponRecords);
        }

        public void setBusinessData(List<Business> business)
        {
            MessageBox.Show(business.Count.ToString());
            showBusinessRecords couponRecords = new showBusinessRecords(business,this);
            businessList = business;
            mainRecordFrame.Navigate(couponRecords);
        }

        private void searchBusiness_BTN_Click(object sender, RoutedEventArgs e)
        {
            forms.search.searchBusiness searchBusinessWin = new forms.search.searchBusiness(this);
            if (searchBusinessWin != null)
            {
                searchBusinessWin.Owner = this;
                searchBusinessWin.ShowDialog();

            }
        }
    }
}
