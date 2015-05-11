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

namespace Kupon_WPF.forms.add
{
    public partial class addAdmin : Window
    {
        public addAdmin()
        {
            InitializeComponent();
        }

        private void Button_click(object sender, RoutedEventArgs e)
        {
        }

    }
}
    /*
    /// <summary>
    /// Interaction logic for addAdmin.xaml
    /// </summary>
    public partial class addAdmin : Window
    {
        public addAdmin()
        {
            InitializeComponent();
        }

        private void Button_click(object sender, RoutedEventArgs e)
        {
            if (commonMethods.isNumber(IDTB.Text) && pass.Password != null)
            {
                Add newObj = new Add();
                string wrong = "";
                bool added = newObj.addAdmin(Convert.ToInt32(IDTB.Text), Convert.ToString(pass.Password), out wrong);
                if (!added)
                {
                    MessageBox.Show(wrong);
                }
                else  MessageBox.Show("new administrator added");
            }
            else
            {
                MessageBox.Show("one or more wrong parameter. please check your input and try again");
            }

        }

        private void IDTB_GotFocus(object sender, RoutedEventArgs e)
        {
            IDTB.Text = "";
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
    }
     * */
