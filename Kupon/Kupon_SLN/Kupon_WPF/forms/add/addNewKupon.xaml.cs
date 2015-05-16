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
            if (bus == null)
            {
                Desc_L.Visibility = System.Windows.Visibility.Hidden;
                DP_L.Visibility = System.Windows.Visibility.Hidden;
                ED_L.Visibility = System.Windows.Visibility.Hidden;
                OP_L.Visibility = System.Windows.Visibility.Hidden;
                Descreption_TB.Visibility = System.Windows.Visibility.Hidden;
                DiscPrice_TB.Visibility = System.Windows.Visibility.Hidden;
                OrgPrice_TB.Visibility = System.Windows.Visibility.Hidden;
                ExpDate_DP.Visibility = System.Windows.Visibility.Hidden;
                name_L.Content = "Enter Link";
            }
            else
            {
                business = bus;
            }
          
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
                if (business != null)
                {
                    if (validateFields())
                    {

                       
                        Kupon kupon = new Kupon(server.getNewKuponID(), 0, Name_TB.Text, Descreption_TB.Text, KuponStatus.NEW, int.Parse(OrgPrice_TB.Text), int.Parse(DiscPrice_TB.Text), ExpDate_DP.SelectedDate.Value, "", business);
                        server.addNewKupon(kupon);
                        MessageBox.Show("kupon added to the system and waiting to admin approvel.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("weong parameters. please try again.");
                    }
                }
                else
                {
                    if (Name_TB.Text.Length > 0)
                    {
                        string id = server.getNewKuponID();
                        Kupon kupon = new Kupon(id, 0, id, "link suggested by user " + main.CurrUser.getName(), KuponStatus.NEW, 0, 0, DateTime.Now, "", server.searchBusinessByName("defualt")[0]);
                        server.addNewKupon(kupon);
                        MessageBox.Show("kupon added to the system and waiting to admin approvel.");
                        this.Close();
                    }
                }
            }catch(Exception ex){
                MessageBox.Show("error while trying to add the kupon to the system. please try again.\n" + ex.ToString());
            }
               
            }
        }
 }

   
        

 

      
                
