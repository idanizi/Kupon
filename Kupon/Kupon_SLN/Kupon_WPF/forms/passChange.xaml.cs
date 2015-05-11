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

namespace Kupon_WPF
{
    /// <summary>
    /// Interaction logic for passChange.xaml
    /// </summary>
    public partial class passChange : Window
    {
        public passChange()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
        /* 
            try
            {
               Edit editDB = new Edit();
                if (editDB.editPasswordByID(MainWindow.UserStat, MainWindow.UserID, oldPass_PB.Password, newPass_PB.Password))
                {
                    MessageBox.Show("password for user " + MainWindow.UserName + " has changed succesfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("wronge password, please try again");
                  
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("error reaching the database. contact your system administrator.  error:" + ex.Data);
            }
    }
    }
            
}
*/