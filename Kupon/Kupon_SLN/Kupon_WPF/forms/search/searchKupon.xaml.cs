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

        double latitude;
        double longtitude;
        MainWindow main;
        BL server = new BL();
        public searchKupon(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
            Location_TB.Text = main.UserLatitude + " , " + main.UserLongtitude;
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
       try{
            if (validateFields())
            {
                List<KuponParameters> ParameterType = new List<KuponParameters>() {KuponParameters.CATEGORY};
                List<String> ParameterValue = new List<String>() { Category_LB.SelectedItem.ToString()};
                 List<Kupon> kupons =  server.searchKoupon((buisnessCategory)Category_LB.SelectedValue,latitude,longtitude);  
                 if (kupons.Count > 0)
                 {
                   MainWindow.setKuponData(kupons);
                     this.Close();
                 }
                 else
                 {
                     MessageBox.Show("didn't found any cupon :( .");
                 }
            }else{
                   MessageBox.Show("wrong parameters. please try again.");
            }
       }

           catch{
                  MessageBox.Show("error while trying to add the kupon to the system. please try again.");
           }
       }

        public void setLocation(double Longitude, double Latitude)
        {
            this.latitude = Latitude;
            this.longtitude = Longitude;
            Location_TB.Text = Longitude +" , "+ Longitude;

        }

        private void pickLocation_BTN_Click(object sender, RoutedEventArgs e)
        {
            show.map map = new show.map(main);
            map.Owner = this;
            map.ShowDialog();
        }
 }
}