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
using System.Device.Location;
using Microsoft.Maps.MapControl.WPF.Design;
using Microsoft.Maps.MapControl.WPF;

namespace Kupon_WPF.forms.show
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
   
    public partial class map : Window
    {
        GeoCoordinateWatcher mGeoWatcher = new GeoCoordinateWatcher();
        LocationConverter locConverter = new LocationConverter();
        Pushpin pin;
        MainWindow main;
        public map(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
             Map.Focus();
             pin = new Pushpin();
             Location pinLocation = Map.Center;
             pin.Location = pinLocation;

             // Adds the pushpin to the map.
             Map.Children.Add(pin);
        }

        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            Map.Center.Latitude = main.UserLatitude;
            Map.Center.Longitude = main.UserLongtitude;
        }

        private void Map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Disables the default mouse double-click action.
            e.Handled = true;

            // Determin the location to place the pushpin at on the map.

            //Get the mouse click coordinates
            Point mousePosition = e.GetPosition(this);
            //Convert the mouse coordinates to a locatoin on the map
            Location pinLocation = Map.ViewportPointToLocation(mousePosition);
            pin.Location = pinLocation;
            lon_L.Content = pinLocation.Longitude;
            lat_L.Content = pinLocation.Latitude;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((IMapped)this.Owner).setLocation(pin.Location.Longitude,pin.Location.Latitude);
            Close();
        }
    }
}
