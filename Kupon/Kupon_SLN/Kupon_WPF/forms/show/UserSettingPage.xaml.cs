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
    /// Interaction logic for UserSettingPage.xaml
    /// </summary>




    public partial class UserSettingPage : Page
    {
        Array data;
        MainWindow main;
        List<bool> userFevoritsValues;
        List<buisnessCategory> userFevorits;
        // List<Setting>
        public UserSettingPage(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
            data = Enum.GetValues(typeof(buisnessCategory));
            userFevorits = ((Client)main.CurrUser).getFavorits();
            userFevoritsValues = new List<bool>();
            Data_Grid.ItemsSource = data;

        }

        void OnChecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Data_Grid.Items[Data_Grid.SelectedIndex].ToString());
            if(((CheckBox)e.OriginalSource).IsChecked.Value){
                userFevorits.Add((buisnessCategory)Data_Grid.Items[Data_Grid.SelectedIndex]);
            }
            saveCanges();
        }

        void OnUnchecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(e.Source.ToString() + " " + ((CheckBox)e.OriginalSource).IsChecked);
            if (!((CheckBox)e.OriginalSource).IsChecked.Value)
            {
                userFevorits.Remove((buisnessCategory)Data_Grid.Items[Data_Grid.SelectedIndex]);
            }
            saveCanges();

        }

        private void saveCanges()
        {
            try
            {
                BL server = new BL();
                ((Client)main.CurrUser).setFavor(userFevorits);
                server.updateUser(main.CurrUser);
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
    }
}
