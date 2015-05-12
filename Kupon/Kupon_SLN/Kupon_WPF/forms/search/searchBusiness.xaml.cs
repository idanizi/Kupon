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
    public partial class searchBusiness : Window , IMapped
    {

        double latitude = -1;
        double longtitude = -1;
        MainWindow main;
        BL server = new BL();
        public searchBusiness(MainWindow main)
        {
            InitializeComponent();
            pickCategory_CB.SelectedIndex = 0;
            this.main = main;
            Array data = Enum.GetValues(typeof(buisnessCategory));
            Value_LB.ItemsSource = data;
        }



        private bool validateFields()
        {
            if (pickCategory_CB.SelectedIndex == 0)
            {
                if (Value_TB.Text.Length == 0)
                {
                    MessageBox.Show("please insert a value.");
                    return false;
                }
            }
            else if (pickCategory_CB.SelectedIndex == 1)
            {
                if (pickCategory_CB.SelectedItem == null)
                {
                    MessageBox.Show("please pick a category.");
                    return false;
                }
                if ((latitude == -1) || (longtitude == -1))
                {
                    MessageBox.Show("please pick a location on the map.");
                    return false;
                }

            }
            else if (pickCategory_CB.SelectedIndex == 2)
            {
                if (Value_TB.Text.Length == 0)
                {
                    MessageBox.Show("please insert a value.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("please pick a search type.");
            }
            return true;
        }

        private void searchKupon_BTN_Click(object sender, RoutedEventArgs e)
        {
       try{
            if (validateFields())
            {
                List<Business> business = null;
           if (pickCategory_CB.SelectedIndex == 0)
                {
                    // List<Kupon> business = server.searchKouponByName(Value_TB.Text);
                    MessageBox.Show("not implemented yet.");
                }
           else if (pickCategory_CB.SelectedIndex == 1)
                {
                    business = server.searchBusiness(Business.enumFromString(pickCategory_CB.SelectionBoxItem.ToString()), latitude, longtitude);
                }
           else if (pickCategory_CB.SelectedIndex == 2)
                {
                    // List<Kupon> business = server.searchKouponByCity(Value_TB.Text);
                    MessageBox.Show("not implemented yet.");
                }
           if (business != null) { }
           if (business.Count > 0)
                 {
                     main.setBusinessData(business);
                     this.Close();
                 }
                 else
                 {
                     MessageBox.Show("didn't found any cupon :( .");
                 }
            }
         
       }

           catch(Exception ex){
                  MessageBox.Show("error while trying to search the kupon. please try again. \n" + ex.ToString());
                 
           }
       }

        public void setLocation(double Longitude, double Latitude)
        {
            this.latitude = Latitude;
            this.longtitude = Longitude;
            Value_TB.Text = Longitude + " , " + Longitude;

        }

        private void pickLocation_BTN_Click(object sender, RoutedEventArgs e)
        {
            show.map map = new show.map(main);
            map.Owner = this;
            map.ShowDialog();
        }

        private void pickCategory_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((pickCategory_CB.SelectedIndex == 0) || (pickCategory_CB.SelectedIndex == 2))
            {
               Value_TB.IsEnabled = true;
               Value_TB.Text = "";
               Value_LB.Visibility = System.Windows.Visibility.Hidden;
               pickLocation_BTN.Visibility = System.Windows.Visibility.Hidden;
           }
            else if (pickCategory_CB.SelectedIndex == 1)
           {
               pickLocation_BTN.Visibility = System.Windows.Visibility.Visible;
               Value_LB.Visibility = System.Windows.Visibility.Visible;
               Value_TB.IsEnabled = false;
           }
               
        }

   
 }
}