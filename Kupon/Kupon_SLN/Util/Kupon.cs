using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Kupon : INotifyPropertyChanged
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
        private string _Price;

        public string Price
        {
            get { return _Price; }
            set { _Price = value;
            NotifyPropertyChanged("Price");
            }
        }

   

        public Kupon(String _ID1, String _name1, String _description1, String _Price1)
        {
            // TODO: Complete member initialization
            this._ID = _ID1;
            this._name = _name1;
            this._description = _description1;
            this._Price = _Price1;
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

