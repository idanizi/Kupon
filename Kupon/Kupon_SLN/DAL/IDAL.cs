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
        Kupon searchKuponByID(Kupon kupon);
        Kupon searchKuponBySerialID(Kupon kupon);
        //admin
        void add_admin(Admin admin);
        void update_admin(Admin admin);
        void delete_admin(Admin admin);
        Admin searchAdmin(Admin admin);
        //manager
        void add_manager(Manager manager);
        void update_manager(Manager manager);
        void delete_manager(Manager manager);
        Manager searchManager(Manager manager);
        //client
        void add_client(Client client);
        void update_client(Client client);
        void delete_client(Client client);
        Client searchClient(Client client);
       //business
        void add_business(Business business);
        void update_business(Business business);
        void delete_business(Business business);
       //business search
        List<Business> searchBusinessByAddress(string city, string street, int number);
        List<Business> searchBusinessBycatagory(string catagory);
        List<Business> searchBusinessBycatagory_location(string catagory, double vertical, double horizontal,int radius);
        //kupon search
        List<Kupon> searchKuponByBusinesName(string businessName);
        List<Kupon> searchKuponByCatagory(string catagory);
        List<Kupon> searchKuponByAddress(string city,string street,int number);
        List<Kupon> searchKuponByUser(User user);
        List<Kupon> searchKuponByStatus(Status status);
        List<Kupon> searchKuponByCatagory_location(string catagory, double vertical, double horizontal, int radius);
        //location
        void add_location_user(User user,double vertical,double horizontal);
        //userKupons
        void add_userKupon(User user, Kupon kupon);
        void update_userKupom(Kupon kupon);
    }
}
