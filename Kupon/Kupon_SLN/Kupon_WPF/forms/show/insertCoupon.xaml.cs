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
         IBSL server = (IBSL)new object();
            string ID;
        public insertCoupon(String ID)
        {
            InitializeComponent();
            this.ID = ID;
        }

        private void CheckCode_BTN_Click(object sender, RoutedEventArgs e)
        {
            Kupon myKupon = null;
          //  myKupon = (server.searchCoupon(new List<string>{"BusinessID","kuponCode"},new List<string>{ID,kuponCode_TB.Text}); //TODO
        if(myKupon != null){
            kuponCode = kuponCode_TB.Text;
            KuponInfo_TB.Text = myKupon.ToString();
            UseCoupon_BTN.IsEnabled = true;
        }else{
            KuponInfo_TB.Text = "No Kupon in the system for that code. Please try again";
        }
        }
    }
}
