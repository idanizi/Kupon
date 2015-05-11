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
        private IBSL server = new BL();
        //CollectionViewSource itemCollectionViewSource;


public    showBusinessRecords(MainWindow main)
          {
        InitializeComponent();
        // TODO: Complete member initialization
        user = main.CurrUser;
    /*
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
    */
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
               List<String> favorits = ((Client)user).getFavorits();
               foreach(String category in favorits){
         
               dataList.AddRange(server.searchBusiness(new List<KuponParameters>{KuponParameters.LONGTITUDE,KuponParameters.LATITUDE,KuponParameters.CATEGORY},new List<string>{main.UserLongtitude,main.UserLatitude,category}));
               }
                Data_Grid.DataContext = dataList;
           }
           else //userStat == ghost
           {

           }
    }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

     

        }

       

    }

