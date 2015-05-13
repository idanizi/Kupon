using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public enum buisnessParameters
    {
        ID,
        NAME,
        CITY,
        STREET,
        NUMBER,
        DESCRIPTION,
        CATEGORY,
        MANAGER,
        LONGTITUDE,
        LATITUDE
 };
    public enum buisnessCategory
    {
        Food,
        Sports,
        lifeStile,
        Electronics,
        fashion,
        Games,
        Books,
        Other,
        All
    }

   
    public class Business: INotifyPropertyChanged
    {
        private string Id;
        private string name;
        private string city;
        private string street;
        private int number;
        private string description;
        private string catagory;
        private Manager manager;
        private double vertical;
        private double horizontal;

        public Business(string id, string name, string city, string street, int number, string description, string catagory, Manager manager,double horizontal,double vertical)
        {
            this.Id = id;
            this.name = name;
            this.city = city;
            this.street = street;
            this.number = number;
            this.description = description;
            this.catagory = catagory;
            this.manager=manager;
            this.vertical = vertical;
            this.horizontal = horizontal;
        }

         public static buisnessCategory enumFromString(String value){
             try
             {
                 buisnessCategory r;
                 Enum.TryParse<buisnessCategory>(value, true, out r);
                 return r;
             }
             catch
             {
                 return buisnessCategory.Other;
             }
}
        public string getId()
        {
            return Id;
        }

        public string ID
        {
            get { return Id; }
            set
            {
                Id = value;
                NotifyPropertyChanged("ID");
            }
        }

        public string getName()
        {
            return name;
        }

          public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public double getHorizontal()
        {
            return horizontal;
        }

        public string Longtitude
        {
            get { return horizontal.ToString(); }
            set
            {
                try
                {
                    horizontal = double.Parse(value);
                    NotifyPropertyChanged("Longtitude");
                }
                catch
                {
                    horizontal = 0;
                }
            }
        }


        public double getVertical()
        {
            return vertical;
        }
        public string Longtitude
        {
            get { return horizontal.ToString(); }
            set
            {
                try
                {
                    vertical = double.Parse(value);
                    NotifyPropertyChanged("Altitude");
                }
                catch
                {
                    vertical = 0;
                }
            }
        }

        public string getCity()
        {
            return city;
        }

        public string City
        {
            get { return horizontal.ToString(); }
            set
            {
                try
                {
                    city = value;
                    NotifyPropertyChanged("City");
                }
                
            }
        }



        public string getStreet(){
            return street;
        }

        public string Address
        {
            get { return street; }
            set
            {
                
                    street = value;
                    NotifyPropertyChanged("Address");
                
            }
        }


        public int getNumber()
        {
            return number;
        }
        public string getDescription()
        {
            return description;
        }


        public string Description
        {
            get { return description; }
            set
            {

                description = value;
                NotifyPropertyChanged("Description");

            }
        }


        public string getCatagory()
        {
            return catagory;
        }


        public string Catagory
        {
            get { return catagory; }
            set
            {

                catagory = value;
                NotifyPropertyChanged("Catagory");

            }
        }

        public Manager getManger()
        {
            return manager;
        }

        public string Catagory
        {
            get { return manager.getName(); }
            set
            {

               // manager = value;
                NotifyPropertyChanged("Manager");

            }
        }

        public void setManager(Manager manager){
            this.manager = manager;
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
