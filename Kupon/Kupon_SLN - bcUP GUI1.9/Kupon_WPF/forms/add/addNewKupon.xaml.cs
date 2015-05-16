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

        BL server = new BL();
        private MainWindow main;
        private Business business;

        public addNewKupon(MainWindow mainWindow, Business bus)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.main = mainWindow;
            business = bus;
        }



        private bool validateFields()
        {
           
            if(!((Name_TB.Text.Length > 0) &
             
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

                    MessageBox.Show(business.getName());
                    MessageBox.Show(business.getManger().getName());
                    Kupon kupon = new Kupon(server.getNewKuponID(), 0, Name_TB.Text, Descreption_TB.Text, KuponStatus.NEW, int.Parse(OrgPrice_TB.Text), int.Parse(DiscPrice_TB.Text), ExpDate_DP.SelectedDate.Value, "", business);
                    server.addNewKupon(kupon);
                     MessageBox.Show("kupon added to the system and waiting to admin approvel.");
                this.Close();
                }
                else
                {
                    MessageBox.Show("weong parameters. please try again.");
                }
            }catch(Exception ex){
                MessageBox.Show("error while trying to add the kupon to the system. please try again.\n" + ex.ToString());
            }
               
            }
        }
 }

   
        

 

      
                
