using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public enum KuponParameters { LONGTITUDE, LATITUDE, CATEGORY };
    public enum KuponStatus { NEW, APPROVED, ACTIVE, USED };
    public class Kupon
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

        public string getID()
        {
            return ID;
        }

        public int getRank()
        {
            return rank;
        }

        public string getName()
        {
            return name;
        }

        public string getDescription()
        {
            return description;
        }

        public KuponStatus getStatus()
        {
            return status;
        }

        public int getOriginalPrice()
        {
            return originalPrice;
        }

        public int getDicountPrice()
        {
            return dicountPrice;
        }

        public DateTime getLastDate()
        {
            return lastDate;
        }

        public string getSerialKey()
        {
            return serialKey;
        }

        public Business getBusiness()
        {
            return business;
        }

        public void setBusiness(Business business)
        {
            this.business = business;
        }

        public void setRank(int rank)
        {
            this.rank = rank;
        }

        public void setStatus(KuponStatus status)
        {
            this.status = status;
        }


        public void setSerialNum(string serial)
        {
            this.serialKey = serial;


        }
    }
}
