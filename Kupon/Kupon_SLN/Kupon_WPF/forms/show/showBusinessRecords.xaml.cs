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
    private User user;
        private BL server = new BL();
        //CollectionViewSource itemCollectionViewSource;


public    showBusinessRecords(List <Business> data, MainWindow main)
          {
        InitializeComponent();
        // TODO: Complete member initialization
        user = main.CurrUser;

        Data_Grid.DataContext = data;
           if (user is Admin)
           {
               //Data_Grid.SelectionUnit = DataGridSelectionUnit.Cell;
               Data_Grid.IsManipulationEnabled = true;
               Data_Grid.IsReadOnly = false;
               Data_Grid.IsEnabled = true;
               Data_Grid.SelectionMode = DataGridSelectionMode.Extended;
              
           }
          
           else if (user is Client)
           {
               Data_Grid.IsManipulationEnabled = false;
               Data_Grid.IsReadOnly = true;
               Data_Grid.IsEnabled = false;
               Data_Grid.SelectionMode = DataGridSelectionMode.Single;
             /*  List<buisnessCategory> favorits = ((Client)user).getFavorits();
               foreach (buisnessCategory category in favorits)
               {
                   dataList.AddRange(server.searchBusiness(  category,main.UserLongtitude, main.UserLatitude));
               } */
              

           }
           else //userStat == ghost
           {
               Data_Grid.IsManipulationEnabled = false;
               Data_Grid.IsReadOnly = true;
               Data_Grid.IsEnabled = false;
               Data_Grid.SelectionMode = DataGridSelectionMode.Single;
               /*  List<buisnessCategory> favorits = ((Client)user).getFavorits();
                 foreach (buisnessCategory category in favorits)
                 {
                     dataList.AddRange(server.searchBusiness(  category,main.UserLongtitude, main.UserLatitude));
                 } */
             
           }
           Data_Grid.DataContext = data;
           MessageBox.Show(data.Count.ToString());
    }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

     

        }

       

    }

