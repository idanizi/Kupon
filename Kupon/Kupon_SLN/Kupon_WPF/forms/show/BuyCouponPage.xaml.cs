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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Util;
namespace Kupon_WPF.forms.show
{
    /// <summary>
    /// Interaction logic for BuyCouponPage.xaml
    /// </summary>
    public partial class BuyCouponPage : Page
    {
        public BuyCouponPage()
        {
            InitializeComponent();
        }
        public BuyCouponPage(Kupon koupon)
        {
            InitializeComponent();
            PaymentSum.Content = "Payment Sum: " + koupon.getDicountPrice();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           MessageBox.Show("congratolations! your payment has been accepted. this kupon was added to your personal koupon list");

        }
    }
}
