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
    public partial class addNewKupon : Window
    {

        string creator;
        IBSL server = new BL();
        MainWindow main;
        public addNewKupon(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
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
            try {
                if (validateFields())
                {
                    //  List<String> ParameterType = new List<String> { KuponParameters., "Catagory", "OrgPrice", "DiscPrice", "ExpDate","Creator" };
                    //   List<String> ParameterValue = new List<String> { Name_TB.Text, Catagory_TB.Text,int.Parse(OrgPrice_TB.Text), int.Parse(DiscPrice_TB.Text),ExpDate_DP.Text,creator};
                    Kupon kupon = new Kupon(server.getNewKuponID(), 0, Name_TB.Text, Descreption_TB.Text, KuponStatus.NEW, int.Parse(OrgPrice_TB.Text), int.Parse(DiscPrice_TB.Text), ExpDate_DP.SelectedDate.Value, "", (Business)main.CurrUser);
                    server.addNewKupon(kupon, main.CurrUser.getName());
                     MessageBox.Show("kupon added to the system and waiting to admin approvel.");
                this.Close();
                }
                else
                {
                    MessageBox.Show("error while trying to add the kupon to the system. please try again.");
                }
            }catch{
                MessageBox.Show("error while trying to add the kupon to the system. please try again.");
            }
               
            }
        }
 }

   
        }

 

      
                
