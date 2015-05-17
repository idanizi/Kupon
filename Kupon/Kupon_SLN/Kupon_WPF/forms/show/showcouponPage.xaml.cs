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
    /// Interaction logic for showCouponPage.xaml
    /// </summary>
    public partial class showCouponPage : Page
    {
        Kupon koupon = null;
        List<Kupon> dataList = new List<Kupon>();
        public showCouponPage()
        {
            InitializeComponent();
        }

        public showCouponPage(Kupon koupon)
        {
            InitializeComponent();
            this.koupon = koupon;
            dataList.Add(koupon);
            Coupon_Detiles.DataContext = dataList;
            
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }



        private void Coupon_Detiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
    }
}
