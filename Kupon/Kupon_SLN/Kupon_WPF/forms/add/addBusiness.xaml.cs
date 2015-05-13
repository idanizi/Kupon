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
using BSL;
using Util;
using System.Text.RegularExpressions;
namespace Kupon_WPF.forms.add
{
    public partial class addBusiness : Window, IMapped
    {

        MainWindow main;
        BL server = new BL();
        public addBusiness()
        {
            InitializeComponent();
        }

        public addBusiness(MainWindow main)
        {
            InitializeComponent();
            this.main = main;

            Array data = Enum.GetValues(typeof(buisnessCategory));
            Category_LB.ItemsSource = data;
        }


        public void setLocation(double Longitude, double Latitude)
        {
            Location_TB.Text = Longitude + " , " + Latitude;

        }

        private bool validateFields()
        {
           
            if(!((Name_TB.Text.Length > 0) &
               ( Address_TB.Text.Length > 0) &
                (City_TB.Text.Length > 0) &
                 (mangerUsername_TB.Text.Length > 0) &
                  (ManegerPass_PB.Password.Length > 0) &
                   (mangerMail_TB.Text.Length > 0) &
                    (mangerPhone_TB.Text.Length > 0) &
                (Category_LB.SelectedItems.Count > 0) 
                )){
                return false;
            }
           

            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
       try{
            if (validateFields())
            {
                Manager busiMan = new Manager(mangerUsername_TB.Text, ManegerPass_PB.Password, mangerMail_TB.Text, mangerPhone_TB.Text, "Maneger", Name_TB.Text);
             
               //TODO: getNewBusiinessID
                Business newBusiness = new Business(server.getNewKuponID(), Name_TB.Text, City_TB.Text, Address_TB.Text, 0, Descreption_TB.Text, Category_LB.SelectedItem.ToString(), busiMan, main.UserLongtitude, main.UserLatitude);
               server.addNewBusiness(newBusiness);
               this.Close();
            }else{
                MessageBox.Show("one or more worng parameter");
            }
        
        }catch(Exception ex){
        MessageBox.Show(ex.ToString());
        }
    }
        private void Category_LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void pickLocation_BTN_Click(object sender, RoutedEventArgs e)
        {
            show.map map = new show.map(main);
            map.Owner = this;
            map.ShowDialog();
        }
 }

        }

 

      
                
