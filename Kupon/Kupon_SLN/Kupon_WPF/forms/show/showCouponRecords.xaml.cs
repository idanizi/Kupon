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
        private List<Kupon> data;
        //CollectionViewSource itemCollectionViewSource;


        public showCouponRecords()
        {
            InitializeComponent();

            /*     this.userStat = UserStat;
                 dataList = new List<Kupon>

                                          {
                                              new Kupon
                                                  (
                                                      "122321",
                                                      "Moser",
                                                      "bla bla bla",
                                                     "2362.4"
                                                  ),
                                              new Kupon
                                                  (
                                                     "3754",
                                                      "sdsdds",
                                                      "bla sadadssadas bla",
                                                     "232.2"
                                                  ),
                                              new Kupon
                                                  (
                                                     "54645",
                                                      "ffFff",
                                                      "sddssdaddgsdgd bla bla",
                                                     "6632.4"
                                                  )
                                          };
             
            //Set the DataGrid's DataContext to be a filled DataTable
            Data_Grid.DataContext = dataList;
            if (user is Admin)
            {
                //Data_Grid.SelectionUnit = DataGridSelectionUnit.Cell;
                Data_Grid.IsManipulationEnabled = true;
                Data_Grid.IsReadOnly = false;
                Data_Grid.IsEnabled = true;
                Data_Grid.SelectionMode = DataGridSelectionMode.Extended;

            }
            else if (user is Business)
            {

            }
            else if (user is Client)
            {
                List<buisnessCategory> favorits = ((Client)user).getFavorits();
                foreach (buisnessCategory category in favorits)
                {

                   // dataList.AddRange(server.searchKoupon(category, main.UserLongtitude, main.UserLatitude));
                }
                Data_Grid.DataContext = dataList;
            }
            else //userStat == ghost
            {

            }*/
        }

        public showCouponRecords(MainWindow main, List<Kupon> kupons)
        {
            InitializeComponent();
            this.main = main;

            if (user is Admin)
            {
                //Data_Grid.SelectionUnit = DataGridSelectionUnit.Cell;
                Data_Grid.IsManipulationEnabled = true;
                Data_Grid.IsReadOnly = false;
                Data_Grid.IsEnabled = true;
                Data_Grid.SelectionMode = DataGridSelectionMode.Single;

            }
            else if (user is Business)
            {
                Data_Grid.IsManipulationEnabled = false;
                Data_Grid.IsReadOnly = true;
                Data_Grid.IsEnabled = false;
                Data_Grid.SelectionMode = DataGridSelectionMode.Single;
            }
            else if (user is Client)
            {
                Data_Grid.IsManipulationEnabled = false;
                Data_Grid.IsReadOnly = true;
                Data_Grid.IsEnabled = false;
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
