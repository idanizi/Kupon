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
        //kupon 
        void add_kupon(Kupon kupon);
        void update_kupon(Kupon kupon);
        void delete_kupon(Kupon kupon);
        //admin
        void add_admin(Admin admin);
        void update_admin(Admin admin);
        void delete_admin(Admin admin);
        //manager
        void add_manager(Manager manager);
        void update_manager(Manager manager);
        void delete_manager(Manager manager);
        //client
        void add_client(Client client);
        void update_client(Client client);
        void delete_client(Client client);
       //business
        void add_business(Business business);
        void update_business(Business business);
        void delete_business(Business business);
       //business search
        List<Business> searchBusinessByAddress(string city, string street, int number);
        List<Business> searchBusinessBycatagory(string catagory);
        //kupon search
        List<Kupon> searchKuponByBusinesName(string businessName);
        List<Kupon> searchKuponByCatagory(string catagory);
        List<Kupon> searchKuponByAddress(string city,string street,int number);
        List<Kupon> searchKuponByUser(User user);
        //location
        void add_location_user(User user,double vertical,double horizontal);
        //userKupons
        void add_userKupon(User user, Kupon kupon);
        
    }
}
