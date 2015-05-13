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
using BSL;

namespace Kupon_WPF.forms.show
{
    /// <summary>
    /// Interaction logic for insertCoupon.xaml
    /// </summary>
   
    public partial class insertCoupon : Window
    {
         string kuponCode = "";
         BL server =  new BL();
         MainWindow main;
        public insertCoupon(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void CheckCode_BTN_Click(object sender, RoutedEventArgs e)
        {

          if (server.useKupon(kuponCode_TB.Text))
          {
              KuponInfo_TB.Text = "kupon used. thank u :)";
        }else{
            KuponInfo_TB.Text = "No Kupon in the system for that code. Please try again";
        }
        }
    }
}
