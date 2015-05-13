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
    public partial class showCouponRecords : Page
    {

    //    public ICollectionView Customers { get; private set; }
     //   public ICollectionView GroupedCustomers { get; private set; }
        public List<Kupon> dataList = new List<Kupon>();
        private User user = null;
        private BL server = new BL();
        //CollectionViewSource itemCollectionViewSource;


public    showCouponRecords(MainWindow main)
          {
        InitializeComponent();
        // TODO: Complete member initialization
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
    */
          //Set the DataGrid's DataContext to be a filled DataTable
         Data_Grid.DataContext = dataList;
           if (user.GetType is Admin)
           {
               //Data_Grid.SelectionUnit = DataGridSelectionUnit.Cell;
               Data_Grid.IsManipulationEnabled = true;
               Data_Grid.IsReadOnly = false;
               Data_Grid.IsEnabled = true;
               Data_Grid.SelectionMode = DataGridSelectionMode.Extended;

           }
           else if (user.GetType is Business)
           {

           }
           else if (user.GetType is Client)
           {
               List<buisnessCategory> favorits = ((Client)user).getFavorits();
               foreach(buisnessCategory category in favorits){
         
               dataList.AddRange(server.searchKoupon(category,main.UserLongtitude,main.UserLatitude));
               }
                Data_Grid.DataContext = dataList;
           }
           else //userStat == ghost
           {

           }
    }

public showCouponRecords(List<Kupon> kupons)
{
  /*  InitializeComponent();

    //Set the DataGrid's DataContext to be a filled DataTable
    Data_Grid.DataContext = kupons;
    if (userStat == "Admin")
    {
        //Data_Grid.SelectionUnit = DataGridSelectionUnit.Cell;
        Data_Grid.IsManipulationEnabled = true;
        Data_Grid.IsReadOnly = false;
        Data_Grid.IsEnabled = true;
        Data_Grid.SelectionMode = DataGridSelectionMode.Extended;
    }*/
}

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Data_Grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((Data_Grid.SelectedIndex > 0) & (Data_Grid.SelectedIndex < dataList.Capacity)){
            showCoupon showCouponWin = new showCoupon(dataList[Data_Grid.SelectedIndex]);
            showCouponWin.ShowDialog();
        }

        }

        private void Data_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
