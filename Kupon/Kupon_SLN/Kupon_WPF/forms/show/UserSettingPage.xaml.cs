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
    /// Interaction logic for UserSettingPage.xaml
    /// </summary>


    

    public partial class UserSettingPage : Page
    {
        Array data;
        MainWindow main;
        List<pref> userFevoritsValues;
        List<buisnessCategory> userFevorits;
        // List<Setting>

        private class pref: INotifyPropertyChanged
        {
            private buisnessCategory category;
            private bool value;
            public pref(buisnessCategory buis, bool value)
            {
                category = buis;
                this.value = value;
              
            }

            public string Category
            {
                get { return category.ToString(); }
                set
                {
                     buisnessCategory res;
                     Enum.TryParse(value, true,out res);
                     this.category = res;
                    NotifyPropertyChanged("Category");

                }
            }

             public bool Value
            {
                get { return value; }
                set
                {
                    this.value = value;
                    NotifyPropertyChanged("Value");
                }
            }

            #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;

            #endregion

            #region Private Helpers

            private void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }

            #endregion


            internal buisnessCategory getCategory()
            {
                return category;
            }
        } 
        
        
        public UserSettingPage(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
            updateValue();
            Data_Grid.IsManipulationEnabled = true;
            Data_Grid.IsEnabled = true;

        }

        private void updateValue()
        {
            data = Enum.GetValues(typeof(buisnessCategory));
            userFevorits = ((Client)main.CurrUser).getFavorits();
            userFevoritsValues = new List<pref>();
            foreach (buisnessCategory busCat in data)
            {
                if (userFevorits.IndexOf(busCat)>=0)
                {
                    userFevoritsValues.Add(new pref(busCat,true));
                }else{
                    userFevoritsValues.Add(new pref(busCat,false));
                }
            }
            Data_Grid.ItemsSource = userFevoritsValues;
        }


        public void saveCanges()
        {
            try
            {
                List<buisnessCategory>  userFevorits = new List<buisnessCategory>();
                BL server = new BL();
                foreach (pref prefV in userFevoritsValues)
                {
                    if(prefV.Value == true){
                  // MessageBox.Show(prefV.getCategory() + prefV.Value.ToString());
                        userFevorits.Add(prefV.getCategory());
                    }
                }
                ((Client)main.CurrUser).setFavor(userFevorits);
                  updateValue();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void Data_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
