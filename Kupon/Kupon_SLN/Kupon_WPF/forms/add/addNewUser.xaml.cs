
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
   
        BL server = new BL();
        public addNewUser()
        {
            InitializeComponent();
        }


        private bool validateFields()
        {
            
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
                     return false;
                }
                if (!(Regex.Match(Phone_TB.Text, @"(^\+[0-9]{2}|^\+[0-9]{2}\(0\)|^\(\+[0-9]{2}\)\(0\)|^00[0-9]{2}|^0)([0-9]{9}$|[0-9\-\s]{10}$)")).Success)
                {
                    MessageBox.Show
                        ("the phone number you have entered is not a valied phone number"
                    , "error");
                     return false;
                }
               /* if (!(Regex.Match(Phone_TB.Text, @"(^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")).Success)
                {
                    MessageBox.Show
                        ("the mail number you have entered is not a valied mail address"
                    , "error");
                     return false;
                }*/
            
             if (!(server.getUser(UserName_TB.Text) == null))
            {
                MessageBox.Show("user name or mail already exist in the system.", "error");
                return false;
            }
        }catch(Exception ex){
            MessageBox.Show("one of the parameters is not valid:" + ex.ToString(), "error");
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

  