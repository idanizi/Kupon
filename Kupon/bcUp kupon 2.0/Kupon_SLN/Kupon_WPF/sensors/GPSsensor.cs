using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kupon_WPF.sensors
{
    class GPSsensor : Isensor
    {
        GeoCoordinateWatcher mGeoWatcher = new GeoCoordinateWatcher();
        public event EventHandler infoChanged;

        public object getInfo()
        {
            return mGeoWatcher.Position;
        }

        public void open()
        {
            mGeoWatcher.Start();
            mGeoWatcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
            mGeoWatcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(position_changed);
        }

        void position_changed(object sender, object e)
        {
            infoChanged(null, null);
        }

        public void close()
        {
            mGeoWatcher.Stop();
        }

        public double getL()
        {
            return mGeoWatcher.Position.Location.Latitude;
        }
    }
}
