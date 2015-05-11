using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Util;

namespace BSL
{
    public class BL:IBSL
    {
        //fields
        private IDAL dataBase;

        //constructor
        public BL()
        {
            this.dataBase = new DB_manager();
        }

        public void addNewBusiness(Business newBusiness)
        {
                dataBase.add_business(newBusiness);
        }

        public void addNewKupon(Kupon newKupon )
        {
            dataBase.add_kupon(newKupon);
        }

        /*need to throw exception if doesn't succeed (when missing a parameter). talk with yochai
        dont know which kind of user*/
        public void addNewUser(User user)
        {
            if (user.GetType() is Admin)
                dataBase.add_admin((Admin) user);
            if (user.GetType() is Client)
                dataBase.add_client((Client)user);
            if (user.GetType() is Manager)
                dataBase.add_manager((Manager) user);
        }

        /*the admin should call this when he approved
        how to notify the client about the new kupon?
        add func ClientsByCity(newKupon.getBusiness().getCity()) in DAL.talk to matan*/
        public void approveNewKupon(Kupon newKupon)
        {
            newKupon.setStatus(Status.APPROVED);
            dataBase.update_kupon(newKupon);
        }

        /* tell matan to add dataBase.searchKuponByID() */
        public void buyNewKupon(string kuponID, string userName, string paymentDetails)
        {
            Kupon kupon = dataBase.searchKuponByID(new Kupon(kuponID));
            if(kupon == null)
                throw new ArgumentException("This kupon doesn't exist");

            if (kupon.getStatus() != Status.APPROVED)
                throw new ArgumentException("This kupon doesn't approved yet");
                
            Client client = dataBase.searchClient(new Client(userName));
            kupon.setStatus(Status.ACTIVE);
            //set serial key
            client.addKupon(kupon);
            dataBase.add_userKupon(client, kupon);
        }

        public User logIn(string userName, string Pass, double latitude, double longtitude)
        {
            Client client = dataBase.searchClient(new Client(userName));
            if (client != null)
            {
                if (!client.getPassword().Equals(Pass))
                    return null;
                client.logIn();
                dataBase.add_location_user(client, latitude, longtitude);
                dataBase.update_client(client);
                return client;
            }

            Admin admin = dataBase.searchAdmin(new Admin(userName));
            if (admin != null)
            {
                if (!admin.getPassword().Equals(Pass))
                    return null;
                admin.logIn();
                dataBase.update_admin(admin);
                return admin;
            }

            Manager manager = dataBase.searchManager(new Manager(userName));
            if (manager != null)
            {
                if (!manager.getPassword().Equals(Pass))
                    return null;
                manager.logIn();
                dataBase.update_manager(manager);
                return manager;
            }

            return null;
        }

        public void logOut(string userName)
        {
            Client client = dataBase.searchClient(new Client(userName));
            if (client != null)
            {
                client.logOut();
                dataBase.update_client(client);
                return;
            }

            Admin admin = dataBase.searchAdmin(new Admin(userName));
            if (admin != null)
            {
                admin.logOut();
                dataBase.update_admin(admin);
                return;
            }

            Manager manager = dataBase.searchManager(new Manager(userName));
            if (manager != null)
            {
                manager.logOut();
                dataBase.update_manager(manager);
                return;
            }
        }

        public Kupon getKupon(string kuponID)
        {
            return dataBase.searchKuponByID(new Kupon(kuponID));
        }

        public List<Kupon> getKuponForApproval(int numOfKupon)
        {
            return dataBase.searchKuponByStatus(Status.NEW);
        }

        public void restorUserPass(string userrName)
        {
        }

        public List<Business> searchBusiness (buisnessCategory category, string city, double latitude, double longtitude)
        {
            if (category != null)
            {
                if (city != null)
                    return dataBase.searchBusinessByCityAndCategory(city, category);
                return dataBase.searchBusinessByCatagory(category);
            }
            if (city != null)
                return dataBase.searchBusinessByCity(city);
        }

        public List<Kupon> searchKoupon (buisnessCategory category, string city, double latitude, double longtitude)
        {
            if (category != null)
            {
                if (city != null)
                    return dataBase.searchKuponByCityAndCategory(category, city);
                return dataBase.searchKuponByCatagory(category);
            }
                return dataBase.searchKuponByCity(city);
        }

        public void updateKupon(Kupon updated)
        {
            dataBase.update_kupon(updated);
        }

        public void updateKuponAlert(string userrName, string sensorTypr, string sensorInfo)
        {
            throw new NotImplementedException();
        }

        public void updateUser(User user)
        {
            if (user.GetType() is Admin)
                dataBase.update_admin((Admin)user);
            if (user.GetType() is Client)
                dataBase.update_client((Client)user);
            if (user.GetType() is Manager)
                dataBase.update_manager((Manager)user);
        }

        public bool useKupon(string kouponID)
        {
            throw new NotImplementedException();
        }

        private string extractVariable(List<UserParameters> parameterName, List<string> parameterValue, UserParameters type)
        {
            for (int i = 0; i < parameterName.Count(); i++)
            {
                if (parameterName.ElementAt(i) == type)
                    return parameterValue.ElementAt(i);
            }
            throw new ArgumentException("Missing parameter- "+ type);
        }

        public User getUser(string userName)
        {
            User user = dataBase.searchClient(new Client(userName));
            if (user != null)
                return user;

            user = dataBase.searchAdmin(new Admin(userName));
            if (user != null)
                return user;

            user = dataBase.searchManager(new Manager(userName));
            if (user != null)
                return user;

            return null;
        }

        public void addNewBusiness(Business newBusiness, string userrName)
        {
            throw new NotImplementedException();
        }

        public List<Business> searchBusiness(List<buisnessParameters> parameterName, List<string> parameterValue)
        {
            throw new NotImplementedException();
        }

        public User logIn(string userName, string Pass)
        {
            throw new NotImplementedException();
        }
    }
}
