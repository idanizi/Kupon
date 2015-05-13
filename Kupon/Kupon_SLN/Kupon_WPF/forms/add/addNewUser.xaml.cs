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
    public partial class addNewUser : Window
    {
        string mode;
        BL server = new BL();
        public addNewUser()
        {
            InitializeComponent();
            mode = "new";
        }


        private bool validateFields()
        {
            /*
            try
            {
                if (!((UserName_TB.Text.Length > 0) &
                   (Mail_TB.Text.Length > 0) &
                    (Pass_PB.Password.Length > 0) &
                    (Phone_TB.Text.Length > 0)))
                {
                    MessageBox.Show("one or more of the parameters is empty!", "error");
                    return false;
                }

                if (!(Regex.Match(Pass_PB.Password, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$")).Success)
                {
                    MessageBox.Show
                        ("Password must be at least 4 characters, no more than 8 characters," +
                    "and must include at least one upper case letter, one lower case letter, and one numeric digit."
                    , "error");
                }




                if (!(Regex.Match(Phone_TB.Text, @"(^\+[0-9]{2}|^\+[0-9]{2}\(0\)|^\(\+[0-9]{2}\)\(0\)|^00[0-9]{2}|^0)([0-9]{9}$|[0-9\-\s]{10}$)")).Success)
                {
                    MessageBox.Show
                        ("the phone number you have entered is not a valied phone number"
                    , "error");
                }


                if (!(Regex.Match(Phone_TB.Text, @"(^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")).Success)
                {
                    MessageBox.Show
                        ("the mail number you have entered is not a valied mail address"
                    , "error");
                }
            }

             if(!(server.getUser(UserName_TB.Text) == null){
                 MessageBox.Show("user name or mail already exist in the system.", "error");
                 return false;
             }
        }catch{
        MessageBox.show("one of the parameters is not valid" , "error");
    }
             * */
            if (!(server.getUser(UserName_TB.Text) == null))
            {
                MessageBox.Show("user name or mail already exist in the system.", "error");
                return false;
            }
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (validateFields())
            {
                
                Array arr = Enum.GetValues(typeof(buisnessCategory));
                  List<buisnessCategory> catList = new List<buisnessCategory>(arr.Cast<buisnessCategory>());
                Client newUser = new Client(UserName_TB.Text, Pass_PB.Password, Mail_TB.Text, Phone_TB.Text,firstName_TB.Text,lastName_TB.Text, catList, new List<Kupon>(), address_TB.Text, "todo", -1);   //TODO  
                try
                {
                    server.addNewUser(newUser);

                    MessageBox.Show("user had succesfully added to the system.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error while trying to add the user to the system. please try again\n"+ex.Message);
                }
                this.Close();

            }
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
 

 

      
                
