using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Business
    {
        
       
        private String _ID;

        public String ID
        {
            get { return _ID; }
            set { _ID = value;
            NotifyPropertyChanged("ID");
            }
        }
        private String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value;
            NotifyPropertyChanged("Name");
            }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value;
            NotifyPropertyChanged("Description");
            }
        }
        private string _Longitude;

        public string Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value;
            NotifyPropertyChanged("Longitude");
            }
        }

        private string _Latitude;
         public string Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value;
            NotifyPropertyChanged("Latitude");
            }
        }

         private List<string> _Categorys;
         public List<string> Categorys
        {
            get { return _Categorys; }
            set { _Categorys = value;
            NotifyPropertyChanged("Categorys");
            }
        }
   

        public Business(String _ID1, String _name1, String _description1, String _Latitude1,String _Longitude1,List<string> _Categorys1)
        {
            // TODO: Complete member initialization
            this._ID = _ID1;
            this._name = _name1;
            this._description = _description1;
            this._Latitude = _Latitude1;
            this._Latitude = _Longitude1;
            this._Categorys = _Categorys1;
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
      
    }
}

