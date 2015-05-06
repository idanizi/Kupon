using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Device.Location;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BSL;
using Util;
using System.Text.RegularExpressions;

namespace Kupon_WPF.forms.search
{
    public partial class searchKupon : Window , IMapped
    {

        string creator;
        String Latitude;
        String Longitude;
        GeoCoordinateWatcher mGeoWatcher = new GeoCoordinateWatcher();
        CivicAddress add = new CivicAddress();

        public searchKupon()
        {
            InitializeComponent();
            mGeoWatcher.Start();
            mGeoWatcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
            mGeoWatcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
            Category_LB.ItemsSource = Categoris.getList();
        }

        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            Location_TB.Text = mGeoWatcher.Position.Location.ToString();
        }


        private bool validateFields()
        {
           
            if(!((Business_TB.Text.Length > 0) |
               (  Category_LB.SelectedItem != null) |
                (Location_TB.Text.Length > 0) 
                )){
                MessageBox.Show("you shold list at least one search parameter!", "error");
                return false;
            }
            
          
            return true;
        }

        private void searchKupon_BTN_Click(object sender, RoutedEventArgs e)
        {
       /*
            if (validateFields())
            {
                if (Location_TB.Text == "Near my location")
                {

                }
                List<String> ParameterType = new List<String> { "Business", "Location", "Category"};
                List<String> ParameterValue = new List<String> { Business_TB.Text, Location_TB.Text, Category_LB.SelectedItem.ToString()};
                /* List<String> kupons =  server.addNewKupon(ParameterType, ParameterValue);   //TODO  
                 if (!server.searchCoupon(ParameterType, ParameterValue))
                 {
                   
                     this.Close();
                 }
                 else
                 {
                     MessageBox.Show("error while trying to add the kupon to the system. please try again.");
                 }
                ((MainWindow)this.Parent).mainRecordFrame.Navigate(new show.showCouponPage(kupons));*/
            Close();
            }

     

        public void setLocation(double Longitude, double Latitude)
        {
            Location_TB.Text = Longitude +" , "+ Longitude;
            this.Latitude = Latitude.ToString();
            this.Longitude = Longitude.ToString();
        }

        private void pickLocation_BTN_Click(object sender, RoutedEventArgs e)
        {
            show.map map = new show.map();
            map.Owner = this;
            map.ShowDialog();
        }
 }
}