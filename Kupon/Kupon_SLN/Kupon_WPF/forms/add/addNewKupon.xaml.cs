﻿using System;
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
        //IBSL server = (IBSL)new object();
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
                /* server.addNewKupon(ParameterType, ParameterValue);   //TODO  
                 if (!server.searchCoupon(ParameterType, ParameterValue))
                 {
                     MessageBox.Show("kupon added to the system and waiting to admin approvel.");
                     this.Close();
                 }
                 else
                 {
                     MessageBox.Show("error while trying to add the kupon to the system. please try again.");
                 }*/
                this.Close();
            }
        }
 }

        
    /*
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class addPatient : Window
    {
        string mode;
        public addPatient()
        {
            InitializeComponent();
            mode = "new";
        }

        public addPatient(IBase editDoc)
        {
            mode = "edit";
            InitializeComponent();
            if (editDoc is patient)
            {
                IDTB.Text = editDoc.ID.ToString();
                FNTB.Text = ((patient)editDoc).FirstName;
                LNTB.Text = ((patient)editDoc).LastName;
                GCB.Text = ((patient)editDoc).Gender;

                DIDTB.Text = ((patient)editDoc).MainDoctor.ToString();
                BirthDate_DP.SelectedDate = ((patient)editDoc).DateBirth;
                pass_PB.Password = ((patient)editDoc).Password;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (commonMethods.isNumber(IDTB.Text) && commonMethods.validNameCheck(FNTB.Text) && commonMethods.validNameCheck(LNTB.Text) && commonMethods.isNumber(DIDTB.Text) && BirthDate_DP.SelectedDate != null)
            {


                patient newPat = new patient(Convert.ToInt32(IDTB.Text), FNTB.Text, LNTB.Text, GCB.Text, Convert.ToInt32(DIDTB.Text), (DateTime)BirthDate_DP.SelectedDate, pass_PB.Password);

                string wrong = "";
                if (mode == "edit")
                {
                    Delete deleteObject = new Delete();
                    bool deleted = deleteObject.delete(newPat);
                    if (!deleted)
                    {
                        MessageBox.Show(wrong);
                    }
                   
                }
                else
                {
                    Add newObject = new Add();
                    bool added = newObject.add(newPat, out wrong);
                    if (!added)
                    {
                        MessageBox.Show(wrong);
                    }
                    else
                    {
                       
                        if (mode == "edit")  MessageBox.Show("changes saved");
                        else MessageBox.Show("new Patient added");
                        this.Close();
                     
                    }
                }
            }
            else
            {
                MessageBox.Show("one or more wrong parameter. please check your input and try again");
            }
        
             
        
        }

         private void FNTB_LostFocus(object sender, RoutedEventArgs e)
        {
            
            if (!commonMethods.validNameCheck(FNTB.Text))
            {
                MessageBox.Show("illegale first name, please try again", "error");
            }
        }

        private void LNTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!commonMethods.validNameCheck(LNTB.Text))
            {
                MessageBox.Show("illegale last name, please try again", "error");
            }
        }

        private void IDTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (commonMethods.isNumber(IDTB.Text))
            {
                int ID = Convert.ToInt32(IDTB.Text);
                if (!user.userIDCheck(ID))
                {
                    MessageBox.Show("illegale ID,please try again", "error");
                }
            }
            else MessageBox.Show("illegale ID,please try again", "error");
        }

        private void DIDTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (commonMethods.isNumber(DIDTB.Text))
            {
                int ID = Convert.ToInt32(DIDTB.Text);
                if (!user.userIDCheck(ID))
                {
                    MessageBox.Show("illegale doctor's ID,please try again", "error");
                }
            }
            else MessageBox.Show("illegale doctor's ID,please try again", "error");
        }

        private void FNTB_GotFocus(object sender, RoutedEventArgs e)
        {
            FNTB.Text = "";
        }

        private void LNTB_GotFocus(object sender, RoutedEventArgs e)
        {
            LNTB.Text = "";
        }

        private void IDTB_GotFocus(object sender, RoutedEventArgs e)
        {
            IDTB.Text = "";
        }

          private void DIDTB_GotFocus(object sender, RoutedEventArgs e)
        {
            DIDTB.Text = "";
        }
    }
             * */
        }

 

      
                
