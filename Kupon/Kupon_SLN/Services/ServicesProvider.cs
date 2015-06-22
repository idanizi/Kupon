using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_server;

namespace Services
{
    public class ServicesProvider: IServices
    {
        private IDAL DAL_Controller;

        public ServicesProvider()
        {
            DAL_Controller = new DB_manager();
        }

        public void add_kupon(Util.Kupon kupon)
        {
            DAL_Controller.add_kupon(kupon);
        }

        public void update_kupon(Util.Kupon kupon)
        {
            DAL_Controller.update_kupon(kupon);
        }

        public void delete_kupon(Util.Kupon kupon)
        {
            DAL_Controller.delete_kupon(kupon);
        }

        public Util.Kupon searchKuponByID(Util.Kupon kupon)
        {
            return DAL_Controller.searchKuponByID(kupon);
        }

        public Util.Kupon searchKuponBySerialID(Util.Kupon kupon)
        {
            return DAL_Controller.searchKuponBySerialID(kupon);
        }

        public void add_admin(Util.Admin admin)
        {
            DAL_Controller.add_admin(admin);
        }

        public void update_admin(Util.Admin admin)
        {
            DAL_Controller.update_admin(admin);
        }

        public void delete_admin(Util.Admin admin)
        {
            DAL_Controller.delete_admin(admin);
        }

        public Util.Admin searchAdmin(Util.Admin admin)
        {
            return DAL_Controller.searchAdmin(admin);
        }

        public void add_manager(Util.Manager manager)
        {
            DAL_Controller.add_manager(manager);
        }

        public void update_manager(Util.Manager manager)
        {
            DAL_Controller.update_manager(manager);
        }

        public void delete_manager(Util.Manager manager)
        {
            DAL_Controller.delete_manager(manager);
        }

        public Util.Manager searchManager(Util.Manager manager)
        {
            return DAL_Controller.searchManager(manager);
        }

        public void add_client(Util.Client client)
        {
            DAL_Controller.add_client(client);
        }

        public void update_client(Util.Client client)
        {
            DAL_Controller.update_client(client);
        }

        public void delete_client(Util.Client client)
        {
            DAL_Controller.delete_client(client);
        }

        public Util.Client searchClient(Util.Client client)
        {
            return DAL_Controller.searchClient(client);
        }

        public void add_business(Util.Business business)
        {
            DAL_Controller.add_business(business);
        }

        public void update_business(Util.Business business)
        {
            DAL_Controller.update_business(business);
        }

        public void delete_business(Util.Business business)
        {
            DAL_Controller.delete_business(business);
        }

        public List<Util.Business> searchBusinnesByName(string id)
        {
            return DAL_Controller.searchBusinnesByName(id);
        }

        public Util.Business searchBUsinessByManager(Util.Manager manager)
        {
            return DAL_Controller.searchBUsinessByManager(manager);
        }

        public List<Util.Business> searchBusinessByCity(string city)
        {
            return DAL_Controller.searchBusinessByCity(city);
        }

        public List<Util.Business> searchBusinessBycatagory(string catagory)
        {
            return DAL_Controller.searchBusinessBycatagory(catagory);
        }

        public List<Util.Business> searchBusinessBycatagory_location(string catagory, double vertical, double horizontal, int radius)
        {
            return DAL_Controller.searchBusinessBycatagory_location(catagory, vertical, horizontal, radius);
        }

        public List<Util.Kupon> searchKuponByBusinesName(string businessName)
        {
            return DAL_Controller.searchKuponByBusinesName(businessName);
        }

        public List<Util.Kupon> searchKuponByName(string name)
        {
            return DAL_Controller.searchKuponByName(name);
        }

        public List<Util.Kupon> searchKuponByCatagory(string catagory)
        {
            return DAL_Controller.searchKuponByCatagory(catagory);
        }

        public List<Util.Kupon> searchKuponByCity(string city)
        {
            return DAL_Controller.searchKuponByCity(city);
        }

        public List<Util.Kupon> searchKuponByUser(Util.User user)
        {
            return DAL_Controller.searchKuponByUser(user);
        }

        public List<Util.Kupon> searchKuponByStatus(Util.KuponStatus status)
        {
            return DAL_Controller.searchKuponByStatus(status);
        }

        public void delete_exp()
        {
            DAL_Controller.delete_exp();
        }

        public List<Util.Kupon> searchKuponByCatagory_location(string catagory, double vertical, double horizontal, int radius)
        {
            return DAL_Controller.searchKuponByCatagory_location(catagory, vertical, horizontal, radius);
        }

        public void add_location_user(Util.User user, double vertical, double horizontal)
        {
            DAL_Controller.add_location_user(user, vertical, horizontal);
        }

        public void add_userKupon(Util.User user, Util.Kupon kupon)
        {
            DAL_Controller.add_userKupon(user, kupon);
        }

        public void delete_userkupon(string serialkey)
        {
            DAL_Controller.delete_userkupon(serialkey);
        }

        public void update_userKupon(Util.Kupon kupon)
        {
            DAL_Controller.update_userKupon(kupon);
        }

        public bool setStatusUsed(string serialkey)
        {
            return DAL_Controller.setStatusUsed(serialkey);
        }

        public void update_userFavorite(Util.Client client, List<Util.buisnessCategory> favor)
        {
            DAL_Controller.update_userFavorite(client, favor);
        }

        public Util.User searchUser(Util.User user)
        {
            return DAL_Controller.searchUser(user);
        }
    }
}
