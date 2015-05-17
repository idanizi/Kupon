using BSL;
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
    /// Interaction logic for RateKuponWin.xaml
    /// </summary>

    public partial class RateKuponWin : Window
    {
        BL server = new BL();
        MainWindow main;
        Kupon kupon;
        public RateKuponWin(MainWindow main, Kupon kupon)
        {
            InitializeComponent();
            this.main = main;
            this.kupon = kupon;
            KuponName_L.Content = kupon.getName();
        }

        private void save_BTN_Click(object sender, RoutedEventArgs e)
        {
            try{
            int i;
            int.TryParse(Rating_CB.SelectedValue.ToString(),out i);
            server.rankKupon(kupon,i);
            }catch{
                kupon.setRank(5);
            }
            Close();
        }
    }

}
