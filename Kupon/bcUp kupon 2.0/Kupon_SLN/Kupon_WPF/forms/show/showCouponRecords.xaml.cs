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
using System.ComponentModel;
using BSL;

namespace Kupon_WPF.forms.show
{
    /// <summary>
    /// Interaction logic for showCouponRecords.xaml
    /// </summary>
    public partial class showCouponRecords : Page, IDataTable
    {

        //    public ICollectionView Customers { get; private set; }
        //   public ICollectionView GroupedCustomers { get; private set; }
        public List<Kupon> dataList = new List<Kupon>();
        private User user = null;
        private BL server = new BL();
        private MainWindow main;



        public showCouponRecords()
        {
            InitializeComponent();

        }

        public showCouponRecords(MainWindow main, List<Kupon> kupons)
        {
            InitializeComponent();
            this.main = main;
            user = main.CurrUser;
            if (user is Admin)
            {
                //Data_Grid.SelectionUnit = DataGridSelectionUnit.Cell;
                Data_Grid.IsManipulationEnabled = true;
                Data_Grid.IsReadOnly = false;
                Data_Grid.IsEnabled = true;
                Data_Grid.SelectionMode = DataGridSelectionMode.Single;

            }
            else if (user is Manager)
            {
                Data_Grid.IsManipulationEnabled = false;
                Data_Grid.IsReadOnly = true;
                Data_Grid.IsEnabled = true;
                Data_Grid.SelectionMode = DataGridSelectionMode.Single;
            }
            else if (user is Client)
            {
                Data_Grid.IsManipulationEnabled = false;
                Data_Grid.IsReadOnly = true;
                Data_Grid.IsEnabled = true;
                Data_Grid.SelectionMode = DataGridSelectionMode.Single;
            }
            else //userStat == ghost
            {
                Data_Grid.IsManipulationEnabled = false;
                Data_Grid.IsReadOnly = true;
                Data_Grid.IsEnabled = false;
                Data_Grid.SelectionMode = DataGridSelectionMode.Single;
            }
            dataList = kupons;
            Data_Grid.DataContext = dataList;
        }


        public IRecord getCurrentRecord()
        {
            return (dataList[Data_Grid.SelectedIndex]);
        }

        private void Data_Grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            main.sendData(dataList[Data_Grid.SelectedIndex]);
        }
    }
}
