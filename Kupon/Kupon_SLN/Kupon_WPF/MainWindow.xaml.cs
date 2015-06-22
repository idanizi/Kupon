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
        private GeoPosition<GeoCoordinate> location = new GeoPosition<GeoCoordinate>();
        private Page currFrame = null;
        Isensor GPSsensor = null;
        CivicAddress add = new CivicAddress();
        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        public List<buisnessCategory> pref = new List<buisnessCategory>();

        public User CurrUser { get { return user; } set { user = value; } }

        public double UserLatitude { get { return location.Location.Latitude; } set { location.Location.Latitude = value; } }

        public double UserLongtitude { get { return location.Location.Longitude; } set { location.Location.Longitude = value; } }

        private showCouponRecords couponRecords;
        public BL server;
 
        public MainWindow()
        {
            InitializeComponent();
            CurrUser = new User("Ghost");
            reInitializedData();
            try
            {

                server.addNewUser(new Admin("admin", "123", "Aa", "33", "ss", "ss"));
            }
            catch
            {
                try
                {
                    Manager manager = new Manager("manger", "123", "Aa", "33", "ss", "ss");
                    server.addNewUser(manager);
                }
                catch
                {
                    try
                    {

                        Manager manager = new Manager("defualtManager", "defualtManager", "Aa", "33", "ss", "ss");
                        server.addNewBusiness(new Business("defualt", "defualt", "city", "street", 10, "bus descreption", buisnessCategory.Food, manager, 0, 0));
                        server.addNewUser(new Client("client1", "123", "mail@mail", "083333", "firstname", "lastname", new List<buisnessCategory>() { buisnessCategory.Food, buisnessCategory.Games }, new List<Kupon>(), "city", "address", 10));
                    }
                    catch { }
                }
            }

        }

        private Isensor startGPS()
        {
            Isensor GPSsen = new sensors.GPSsensor();
            GPSsen.open();
            watcher_PositionChanged(null, null);
            GPSsen.infoChanged += new EventHandler(watcher_PositionChanged);
            return GPSsen;

        }

        void watcher_PositionChanged(object sender, object e)
        {
            if (GPSsensor != null)
            {
                location = (GeoPosition<GeoCoordinate>)GPSsensor.getInfo();
                userLatitude_L.Content = location.Location.Latitude.ToString();
                userLongtitude_L.Content = location.Location.Longitude.ToString();
            }
            else
            {
                location = new GeoPosition<GeoCoordinate>();
                location.Location = new GeoCoordinate();
                userLatitude_L.Content = "Latitude:unknown";
                userLongtitude_L.Content = "Longtitude:unknown";
            }
        }

      

        public void reInitializedData()
        {

            server = new BL();
            GPSsensor = startGPS();
            GPSsensor.open();

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(1, 0, 0);
            dispatcherTimer.Start();


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
                Delete_BTN.Content = "Delete";
                Delete_BTN.Visibility = System.Windows.Visibility.Visible;
                myKupons_BTN.Visibility = System.Windows.Visibility.Visible;
                myKupons_BTN.Content = "coupons for Approvel";
                addBusiness_BTN.Content = "Add Business";
                addBusiness_BTN.Visibility = System.Windows.Visibility.Visible;
                addNewKupon_BTN.Content = "Add New Kupon";
                addNewKupon_BTN.Visibility = System.Windows.Visibility.Visible;
                saveChanges_BTN.Content = "Save Changes";
                saveChanges_BTN.Visibility = Visibility.Visible;
                register_BTN.Visibility = System.Windows.Visibility.Hidden;
                userSetting_BTN.Content = "Approve Kupon";
                userSetting_BTN.Visibility = System.Windows.Visibility.Visible;
                insertCoupon_BTN.Content = "Insert Kupon Code";
                insertCoupon_BTN.Visibility = System.Windows.Visibility.Visible;
                login_BTN.Content = "Logout";
                mainRecordFrame.Navigate(couponRecords);
                currFrame = couponRecords;
                myKupons_BTN_Click(null, null);
            }
            else if (user is Manager)
            {
                Delete_BTN.Visibility = System.Windows.Visibility.Hidden;
                myKupons_BTN.Visibility = System.Windows.Visibility.Visible;
                myKupons_BTN.Content = "My coupons";
                addBusiness_BTN.Content = "Edit Business Detiles";
                addBusiness_BTN.Visibility = System.Windows.Visibility.Visible;
                addNewKupon_BTN.Content = "Add New Kupon";
                addNewKupon_BTN.Visibility = System.Windows.Visibility.Visible;
                saveChanges_BTN.Content = "Purchesed Kupons";
                saveChanges_BTN.Visibility = Visibility.Visible;
                register_BTN.Visibility = System.Windows.Visibility.Hidden;
                saveChanges_BTN.Content = "Save Changes";
                userSetting_BTN.Content = "watch kupon purched";
                userSetting_BTN.Visibility = System.Windows.Visibility.Visible;
                insertCoupon_BTN.Content = "Insert Kupon Code";
                insertCoupon_BTN.Visibility = System.Windows.Visibility.Visible;
                login_BTN.Content = "Logout";
                Delete_BTN.Visibility = System.Windows.Visibility.Hidden;
                mainRecordFrame.Navigate(couponRecords);
                currFrame = couponRecords;
                myKupons_BTN_Click(null, null);
            }
            else if (user is Client)
            {

                Delete_BTN.Visibility = System.Windows.Visibility.Hidden;
                myKupons_BTN.Visibility = System.Windows.Visibility.Visible;
                myKupons_BTN.Content = "My coupons";
                addBusiness_BTN.Content = "Rate Kupon";
                addBusiness_BTN.Visibility = System.Windows.Visibility.Visible;
                addNewKupon_BTN.Content = "Add Kupon From The Net";
                addNewKupon_BTN.Visibility = System.Windows.Visibility.Visible;
                saveChanges_BTN.Content = "Save Changes";
                saveChanges_BTN.Visibility = Visibility.Hidden;
                register_BTN.Visibility = System.Windows.Visibility.Hidden;
                userSetting_BTN.Content = "User Setting";
                userSetting_BTN.Visibility = System.Windows.Visibility.Visible;
                insertCoupon_BTN.Content = "buy kupon";
                insertCoupon_BTN.Visibility = System.Windows.Visibility.Visible;
                login_BTN.Content = "Logout";
                Delete_BTN.Visibility = System.Windows.Visibility.Hidden;
                suggestNewCupons();
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
                suggestNewCupons();

            }
            buttons_GRD.UpdateLayout();
          

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
          
            if (user is Client | user.getName().Equals("Ghost"))
            {
                suggestNewCupons();
            }
        }

        private void suggestNewCupons()
        {
           
            try
            {
               
                if (user is Client)
                {
                    List<Kupon> kupons = new List<Kupon>();
                    foreach (buisnessCategory favor in (((Client)user).getFavorits()))
                    {
                        kupons.AddRange(server.searchKoupon(favor, location.Location.Latitude, location.Location.Longitude));
                    }
                    if (kupons.Count > 0)
                    {
                        couponRecords = new showCouponRecords(this, kupons);
                        mainRecordFrame.Navigate(couponRecords);
                        currFrame = couponRecords;
                        MessageBox.Show("new kupon near your area! try them out..");
                    }
                }
                else if (user.getName().Equals("Ghost"))
                {
                    List<Kupon> kupons = new List<Kupon>();
                     Array data = Enum.GetValues(typeof(buisnessCategory));
                     foreach (buisnessCategory favor in data)
                    {
                        kupons.AddRange(server.searchKoupon(favor, location.Location.Latitude, location.Location.Longitude));
                    }
                    if (kupons.Count > 0)
                    {
                        couponRecords = new showCouponRecords(this, kupons);
                        mainRecordFrame.Navigate(couponRecords);
                        currFrame = couponRecords;
                        MessageBox.Show("new kupon near your area! try them out..");
                    }




                }
            }
            catch
            {

            }

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
                   // reInitializedData();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception accured. please try again " + ex);
                }

            }
            else
            {
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

                    IRecord record = ((IDataTable)currFrame).getCurrentRecord();
                    if (record is Kupon)
                    {
                        server.updateKupon((Kupon)record);
                    }
                    else if (record is Business)
                    {
                        server.updateBusiness((Business)record);
                    }
                    else if (record is User)
                    {
                        server.updateUser((User)record);
                    }
                    else
                    {
                        MessageBox.Show("please choose a record to update");
                    }

                }
                else if (user is Client)
                {

                    if (currFrame is UserSettingPage)
                    {
                        ((UserSettingPage)currFrame).saveCanges();
                        server.updateUser(user);

                    }
                }
                else if (user is Manager)
                {
                    IRecord record = ((IDataTable)currFrame).getCurrentRecord();
                    if (((Business)record).getId().Equals(server.searchManagerBusiness((Manager)user).getId()))
                    {
                        server.updateBusiness((Business)record);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception accured. please try again \n" + ex.ToString());
            }

        }

        private void register_BTN_Click(object sender, RoutedEventArgs e)
        {

            forms.add.addNewUser registerWindow = new forms.add.addNewUser();
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
                else if (user is Admin)
                {
                    try
                    {
                        bus = (Business)((IDataTable)currFrame).getCurrentRecord();
                        if (bus == null)
                        {

                            MessageBox.Show("unknown businessList. can't add cupon");
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("please choose business to add the coupon to");
                        return;
                    }

                }
                else if (user is Client)
                {

                    bus = null; ;

                }
                forms.add.addNewKupon newKuponWindow = new forms.add.addNewKupon(this, bus);
                newKuponWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void userSetting_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (user is Client)
            {
                UserSettingPage settings = new UserSettingPage(this);
                mainRecordFrame.Navigate(settings);
                currFrame = settings;
                saveChanges_BTN.Visibility = Visibility.Visible;
            }
            else if (user is Admin)//aprove kupon
            {
                try
                {
                    IRecord record = ((IDataTable)currFrame).getCurrentRecord();
                    server.approveNewKupon((Kupon)record);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("choos kupon to approve.\n" + ex.ToString());
                }
            }
            else if (user is Manager)//get purchesed kupons
            {
                try
                {

                    server.getPurchestKuponsForBusness(server.searchManagerBusiness((Manager)user));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error.\n" + ex.ToString());
                }
            }
        }


        private void addBusiness_BTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (user is Admin)
                {
                    forms.add.addBusiness registerWindow = new forms.add.addBusiness(this);
                    registerWindow.ShowDialog();
                }
                else if (user is Client)
                {
                    IRecord record = ((IDataTable)currFrame).getCurrentRecord();
                    if (record is Kupon)
                    {
                        if (((Kupon)record).getStatus() == KuponStatus.USED)
                        {
                            RateKuponWin rateKuponWindow = new RateKuponWin(this, (Kupon)record);
                            rateKuponWindow.Owner = this;
                            rateKuponWindow.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("this kupon is not used.you heve to use the kuponin order to rate it!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("choose kupon for rating");
                    }
                }
                else if (user is Manager)
                {
                    Business bus = null;
                    if (user is Manager)
                    {
                        bus = server.searchManagerBusiness((Manager)user);
                        List<Business> busList = new List<Business>();
                        busList.Add(bus);
                        showBusinessRecords myBusiness = new showBusinessRecords(busList, this);
                        mainRecordFrame.Navigate(myBusiness);
                        currFrame = myBusiness;
                    }
                    else
                    {
                        MessageBox.Show("choose kupon for rating");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("exception accurd. \n" + ex.ToString());
            }
        }


        private void searchKupons_BTN_Click(object sender, RoutedEventArgs e)
        {
            forms.search.searchKupon searchKuponWin = new forms.search.searchKupon(this);
            if (searchKuponWin != null)
            {
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
            else if (user is Manager)
            {
                kupons = server.searchKouponByBusiness(server.searchManagerBusiness((Manager)user));
            }
            showCouponRecords couponRecords = new showCouponRecords(this, kupons);
            mainRecordFrame.Navigate(couponRecords);
            currFrame = couponRecords;
        }

        private void insertCoupon_BTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (user is Manager)
                {
                    forms.show.insertCoupon registerWindow = new forms.show.insertCoupon(this);
                    registerWindow.ShowDialog();
                }
                else if (user is Client) //buy k
                {
                    IRecord record = ((IDataTable)currFrame).getCurrentRecord();
                    if (record is Kupon)
                    {
                        BuyCouponPage buyKuponWindow = new BuyCouponPage(this, (Kupon)record);
                        mainRecordFrame.Navigate(buyKuponWindow);
                        currFrame = buyKuponWindow;
                    }
                    else if (record is Business)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.ToString());
            }
        }

        public void setKuponData(List<Kupon> kupons)
        {
            showCouponRecords couponRecords = new showCouponRecords(this, kupons);
            mainRecordFrame.Navigate(couponRecords);
            currFrame = couponRecords;
        }

        public void setBusinessData(List<Business> business)
        {

            showBusinessRecords couponRecords = new showBusinessRecords(business, this);
            mainRecordFrame.Navigate(couponRecords);
            currFrame = couponRecords;
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

        internal void sendData(IRecord record)
        {
            if (user is Client)
            {
                if (record is Kupon)
                {
                    BuyCouponPage buyKupon = new BuyCouponPage(this, (Kupon)record);
                    mainRecordFrame.Navigate(buyKupon);
                    currFrame = buyKupon;
                }
                else if (user is Admin)
                {

                }
            }
        }

        private void Delete_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (user is Admin)
            {
                IRecord record = ((IDataTable)currFrame).getCurrentRecord();
                if (record is Kupon)
                {
                    server.deleteKupon((Kupon)record);
                }
                else if (record is Business)
                {
                    server.deleteBusiness((Business)record);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /*
            userLatitude_L.Content = "Latitude:" + mGeoWatcher.Position.Location.Latitude.ToString();
            userLongtitude_L.Content = "Longtitude:" +  mGeoWatcher.Position.Location.Longitude.ToString();
       
            MessageBox.Show(((sensors.GPSsensor)GPSsensor).getL().ToString());
            GPSsensor = new sensors.GPSsensor();
            MessageBox.Show(GPSsensor.ToString());
            GeoPosition<GeoCoordinate>  loc = (GeoPosition<GeoCoordinate>)GPSsensor.getInfo();
            MessageBox.Show(loc.ToString());
            MessageBox.Show(loc.Location.ToString());
            MessageBox.Show(loc.Location.Latitude.ToString());
            userLatitude_L.Content = loc.Location.Latitude;
            MessageBox.Show(((sensors.GPSsensor)GPSsensor).getL().ToString());
            userLongtitude_L.Content = loc.Location.Longitude.ToString(); */
        }
    }
}
