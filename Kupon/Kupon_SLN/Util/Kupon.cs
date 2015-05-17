using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public enum KuponParameters { LONGTITUDE, LATITUDE, CATEGORY };
    public enum KuponStatus { NEW, APPROVED, ACTIVE, USED };
    public class Kupon : INotifyPropertyChanged, IRecord
    {
        private string ID;
        private string name;
        private string description;
        private KuponStatus status;
        private int originalPrice;
        private int rank;
        private int dicountPrice;
        private DateTime lastDate;
        private string serialKey;
        private Business business;

        public Kupon(string ID, int rank, string name, string description, KuponStatus status, int originalPrice, int dicountPrice, DateTime lastDate, string serialKey, Business business)
        {
            this.ID = ID;
            this.name = name;
            this.description = description;
            this.status = status;
            this.originalPrice = originalPrice;
            this.dicountPrice = dicountPrice;
            this.lastDate = lastDate;
            this.serialKey = serialKey;
            this.business = business;
            this.rank = rank;
        }
        public Kupon(string ID)
        {
            this.ID = ID;
            this.name = null;
            this.description = null;
            this.status = KuponStatus.ACTIVE;
            this.originalPrice = -1;
            this.dicountPrice = -1;
            this.lastDate = new DateTime();
            this.serialKey = null;
            this.business = null;
            this.rank = -1;
        }

        public string getID(){
            return ID;
        }


        public string Name
        {
            get { return name; }
            set
            {
                try
                {
                    name = value;
                    // manager = value;
                    NotifyPropertyChanged("Name");
                }
                catch
                {
                    rank = 0;
                }
            }
        }

        public int getRank()
        {
            return rank;
        }

        public string getName(){
            return name;
        }
        public string Rank
        {
            get { return rank.ToString(); }
            set
            {
                try
                {
                    rank = int.Parse(value);
                    // manager = value;
                    NotifyPropertyChanged("Rank");
                }
                catch
                {
                    rank = 0;
                }
            }
        }
        public string getDescription() { 
            return description;
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                // manager = value;
                NotifyPropertyChanged("Description");

            }
        }
        public KuponStatus getStatus()
        { 
            return status;
        }
        public string Status
        {
            get { return status.ToString(); }
            set
            {
                status = (KuponStatus) Enum.Parse(typeof(KuponStatus), value, true);
                // manager = value;
                NotifyPropertyChanged("Status");

            }
        }
        public int getOriginalPrice(){ 
            return originalPrice;
        }
        public string OriginalPrice
        {
            get { return originalPrice.ToString(); }
            set
            {
                try
                {
                    originalPrice = int.Parse(value);
                 
                    NotifyPropertyChanged("originalPrice");


                }
                catch
                {
                    originalPrice = 999999;
                }
        }
        }
        public int getDicountPrice(){ 
            return dicountPrice;
        }
        public string DicountPrice
        {
            get { return dicountPrice.ToString(); }
            set
            {
                try
                {
                    dicountPrice = int.Parse(value);

                    NotifyPropertyChanged("DicountPrice");


                }
                catch
                {
                    originalPrice = 999999;
                }
            }
        }
        public DateTime getLastDate(){ 
            return lastDate;
        }
        public string LastDate
        {
            get { return lastDate.ToString(); }
            set
            {
                try
                {
                    lastDate = DateTime.Parse(value);

                    NotifyPropertyChanged("LastDate");


                }
                catch
                {
                    originalPrice = 999999;
                }
            }
        }
        public string getSerialKey(){ 
            return serialKey;
        }

        public void setSerialKey(string newSer)
        {
            this.serialKey = newSer;
        }

        public Business getBusiness(){
            return business;
        }

        public void setBusiness(Business business){
            this.business=business;
        }
        public string Business
        {
            get { return business.Name; }
            set
            {
               //business = value;
              
                NotifyPropertyChanged("Business");

            }
        }
        public void setRank(int rank){
            this.rank=rank;
        }

        public void setStatus(KuponStatus status)
        {
            this.status=status;
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
