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
using System.Text.RegularExpressions;
namespace Kupon_WPF.forms.add
{
    public partial class addNewKupon : Window
    {

        string creator;
        IBSL server = new BL();
        public addNewKupon()
        {
            InitializeComponent();
        }

        public addNewKupon(string creator)
        {
            InitializeComponent();
            this.creator = creator;
        }



        private bool validateFields()
        {
           
            if(!((Name_TB.Text.Length > 0) &
               ( Catagory_TB.Text.Length > 0) &
                (OrgPrice_TB.Text.Length > 0) &
                (DiscPrice_TB.Text.Length > 0) &
                ExpDate_DP.SelectedDate != null
               
                )){
                MessageBox.Show("one or more of the parameters is empty!", "error");
                return false;
            }
            
            if ((((DateTime)ExpDate_DP.SelectedDate).CompareTo(DateTime.Now))<1){
                MessageBox.Show("illeagle experetion date.", "error");
                 return false;
            }

            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
       
            if (validateFields())
            {
                List<String> ParameterType = new List<String> { "Name", "Catagory", "OrgPrice", "DiscPrice", "ExpDate","Creator" };
                List<String> ParameterValue = new List<String> { Name_TB.Text, Catagory_TB.Text, OrgPrice_TB.Text, DiscPrice_TB.Text,ExpDate_DP.Text,creator};
                        server.addNewKupon(ParameterType, ParameterValue);  
                 if (server.searchCoupon(ParameterType, ParameterValue)).Count >= 1))
                 {
                     MessageBox.Show("kupon added to the system and waiting to admin approvel.");
                     this.Close();
                 }
                 else
                 {
                     MessageBox.Show("error while trying to add the kupon to the system. please try again.");
                 }
                this.Close();
            }
        }
 }

   
        }

 

      
                
