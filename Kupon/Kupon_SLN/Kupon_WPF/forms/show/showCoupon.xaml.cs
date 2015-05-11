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
using Util;
namespace Kupon_WPF.forms.show
{
    /// <summary>
    /// Interaction logic for showCouponRecord.xaml
    /// </summary>
    public partial class showCoupon : Window
    {
        public showCoupon()
        {
            InitializeComponent();
        }
        

            public showCoupon(Kupon koupon)
        {
            InitializeComponent();

            CouponPage.Navigate(new showCouponPage(koupon));
            
        }
    }
}
