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
using BSL;
namespace Kupon_WPF.forms.show
{
    /// <summary>
    /// Interaction logic for BuyCouponPage.xaml
    /// </summary>
    public partial class BuyCouponPage : Page
    {
        MainWindow main = null;
        BL server = new BL();
            Kupon kupon;
        public BuyCouponPage()
        {
            InitializeComponent();
        }
        public BuyCouponPage(MainWindow main,Kupon kupon)
        {
            InitializeComponent();
            this.main = main;
            this.kupon = kupon;
            PaymentSum.Content = "Payment Sum: " + kupon.getDicountPrice();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(cheackDetials()){
               kupon=server.buyNewKupon(kupon.getID(),main.CurrUser.getName(),Credit_TB.Text);
               server.sendMail("thenks for you buy Kupon",((Client)main.CurrUser).getEmail(),"recipet for kupon. paid "
                   + kupon.getDicountPrice().ToString() +
                   " shekels.\n your kupon code is: \n "+
                   kupon.getSerialKey()
                   +"\n thanks. see you soon!.");
                    MessageBox.Show("congratolations! your payment has been accepted. this kupon was added to your personal koupon list");
          
                    this.NavigationService.GoBack();
                }else{
            MessageBox.Show("sorry, payment details are wrong . pleas try again");
            }
            
            
            }catch(Exception ex){
             MessageBox.Show("sorry, unable to perches kupon. pleas try again. \n "+ ex.ToString() );
            }

        }

private bool cheackDetials()
{
    if(Credit_TB.Text.Length < 8){
        return false;
    }else if(kupon.getLastDate() < DateTime.Now){
        MessageBox.Show("sorry, this kupon has expierd");
        return false;
    }
 return true;
    }
    }
}
