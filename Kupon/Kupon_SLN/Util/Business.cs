using System;
using System.Collections.Generic;
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
        MANAGER
 }
    public class Business
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

        public string getId()
        {
            return Id;
        }

        public string getName()
        {
            return name;
        }
        public double getHorizontal()
        {
            return horizontal;
        }
        public double getVertical()
        {
            return vertical;
        }
        public string getCity()
        {
            return city;
        }
        public string getStreet(){
            return street;
        }
        public int getNumber()
        {
            return number;
        }
        public string getDescription()
        {
            return description;
        }
        public string getCatagory()
        {
            return catagory;
        }
        public Manager getManger()
        {
            return manager;
        }
        public void setManager(Manager manager){
            this.manager = manager;
        }
    }
}
