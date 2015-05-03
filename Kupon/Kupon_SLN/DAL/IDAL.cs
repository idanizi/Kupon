using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace DAL
{
    public interface IDAL
    {
        void add_kupon(Kupon kupon);
        void update_kupon(Kupon kupon);
        void delete_kupon(Kupon kupon);
        void delete_admin(Admin admin);
        void add_admin(Admin admin);
        void delete_manager(Manager manager);
        void add_manager(Manager manager);
        void add_business(Business business);
        void update_business(Business business);
        void delete_business(Business business);
        List<Business> searchBusinessByAdress(string city, string street, int number);
        List<Business> searchBusinessBycatagory(string catagory);
        List<Kupon> searchKuponByBuissnesName(string businessName);
        List<Kupon> searchKuponByCatagory(string catagory);
        List<Kupon> searchKuponByaddress(string city,string street,int number);
    }
}
