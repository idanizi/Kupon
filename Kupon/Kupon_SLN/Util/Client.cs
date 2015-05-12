using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Client: User
    {
        private List<buisnessCategory> favoriets;
        private List<Kupon> kupons;
        private string city;
        private string street;
        private int number;

        public Client(string name, string password, string email, string phone, string firstName, string lastName, List<buisnessCategory> favor, List<Kupon> kupons, string city, string street, int number)
            : base(name, password, email, phone, firstName, lastName)
        {
            this.favoriets = favor;
            this.kupons = kupons;
            this.city = city;
            this.street = street;
            this.number = number;
        }

        public Client(string name, string password, string email, string phone, string firstName, string lastName, List<string> favor, List<Kupon> kupons, string city, string street, int number)
            : base(name, password, email, phone, firstName, lastName)
        {
            this.favoriets = catFromString(favor);
            this.kupons = kupons;
            this.city = city;
            this.street = street;
            this.number = number;
        }

        public Client(string username)
            : base(username)
        {
            this.favoriets = null;
            this.kupons = null;
            this.city = null;
            this.street = null;
            this.number = -1;
        }

            public List<buisnessCategory> getFavor()
            {
                return favoriets;
            }

            public List<Kupon> getKupon()
            {
                return kupons;
            }

            public string getCity()
            {
                return city;
            }

            public string getStreet()
            {
                return street;
            }

            public int getNumber()
            {
                return number;
            }
            public void setKupons(List<Kupon> kupons)
            {
                this.kupons = kupons;
            }

            public void setFavor(List<buisnessCategory> favorites)
            {
                this.favoriets = favoriets;
            }

            public void setFavor(List<string> favorit)
            {
                this.favoriets = catFromString(favorit);
            }

            private List<buisnessCategory> catFromString(List<string> favoriets)
            {
                List<buisnessCategory> list = new List<buisnessCategory>();
                foreach( string f in favoriets){
                    buisnessCategory b;
                    Enum.TryParse<buisnessCategory>(f,true,out b);
                    list.Add (b);
                }
                return list;
            }

        public void addKupon(Kupon kupon)
        {
            kupons.Add(kupon);
        }

        public List<buisnessCategory> getFavorits()
        {
            return favoriets;
        }
    }
}
