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

namespace Kupon_WPF.forms.show
{
    /// <summary>
    /// Interaction logic for showCouponRecords.xaml
    /// </summary>
    public partial class showBusinessRecords : Page
    {

    //    public ICollectionView Customers { get; private set; }
     //   public ICollectionView GroupedCustomers { get; private set; }
        public List<Business> dataList;
    private string userStat = "Ghost";

        //CollectionViewSource itemCollectionViewSource;


        public showBusinessRecords()
        {
            InitializeComponent();
        }

public    showBusinessRecords(string UserStat)
          {
        InitializeComponent();
        // TODO: Complete member initialization
        this.userStat = UserStat;

        dataList = new List<Business>

                                 {
                                     new Business
                                         (
                                             "12236821",
                                             "Business1",
                                             "bla adssdasdjgbla bla",
                                            "333.444444",
                                            "3387324,344343",
                                            Categoris.getList()
                                         ),
                                     new Business
                                         (
                                              "1226678321",
                                              "Business2",
                                             "bhjjhla bjhjhla bhjla",
                                            "333.444444",
                                            "323324.344343",
                                            Categoris.getList()
                                         ),
                                     new Business
                                         (
                                              "12334431",
                                             "Business3",
                                             "bsdffsdfds bla",
                                            "33293.444676444",
                                            "33677324,3467674343",
                                            Categoris.getList()
                                         )
                                 };

          //Set the DataGrid's DataContext to be a filled DataTable
         Data_Grid.DataContext = dataList;
           if (userStat == "Admin" | (userStat == "Business" & ((Business)Data_Grid.SelectedItem).ID == userStat));
           {
               //Data_Grid.SelectionUnit = DataGridSelectionUnit.Cell;
               Data_Grid.IsManipulationEnabled = true;
               Data_Grid.IsReadOnly = false;
               Data_Grid.IsEnabled = true;
               Data_Grid.SelectionMode = DataGridSelectionMode.Extended;
           }
    }

public showBusinessRecords(List<Business> Business,string Business_ID)
{
    InitializeComponent();

    //Set the DataGrid's DataContext to be a filled DataTable
    Data_Grid.DataContext = Business;
    if (userStat == "Admin" | (userStat == "Business" & ((Business)Data_Grid.SelectedItem).ID == Business_ID)) ;
           {
               //Data_Grid.SelectionUnit = DataGridSelectionUnit.Cell;
               Data_Grid.IsManipulationEnabled = true;
               Data_Grid.IsReadOnly = false;
               Data_Grid.IsEnabled = true;
               Data_Grid.SelectionMode = DataGridSelectionMode.Extended;
           }
}

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

     

        }

       

    }

