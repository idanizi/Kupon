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
        public BL(IDAL dataBase)
        {
            this.dataBase = dataBase;
        }

        public void addNewBusiness(Business newBusiness)
        {
                dataBase.add_business(newBusiness);
        }

        public void addNewKupon(Kupon newKupon, string userName)
        {
            dataBase.add_kupon(newKupon);
        }

        /*need to throw exception if doesn't succeed (when missing a parameter). talk with yochai
        dont know which kind of user*/
        public void addNewUser(List<UserParameters> parameterName, List<string> parameterValue)
        {
            string userName = extractVariable(parameterName, parameterValue, UserParameters.USERNAME);
            string password = extractVariable(parameterName, parameterValue, UserParameters.PASSOWRD);
            string email = extractVariable(parameterName, parameterValue, UserParameters.EMAIL);
            string phone = extractVariable(parameterName, parameterValue, UserParameters.PHONE);
            string firstName = extractVariable(parameterName, parameterValue, UserParameters.FIRSTNAME);
            string lastName = extractVariable(parameterName, parameterValue, UserParameters.LASTNAME);

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
            Client client = dataBase.searchClient(new Client(userName));
            dataBase.add_userKupon(client, kupon);
        }

        public void logIn(string userName, string Pass)
        {
            Client client = dataBase.searchClient(new Client(userName));
            if (client != null)
            {
                client.logIn();
                dataBase.update_client(client);
                return;
            }

            Admin admin = dataBase.searchAdmin(new Admin(userName));
            if (admin != null)
            {
                admin.logIn();
                dataBase.update_admin(admin);
                return;
            }

            Manager manager = dataBase.searchManager(new Manager(userName));
            if (manager != null)
            {
                manager.logIn();
                dataBase.update_manager(manager);
                return;
            }

            throw new ArgumentException("user doesn't exist");
        }

        public void logOut(string userName, string Pass)
        {
            Client client = dataBase.searchClient(new Client(userName));
            if (client != null)
            {
                client.logIn();
                dataBase.update_client(client);
                return;
            }

            Admin admin = dataBase.searchAdmin(new Admin(userName));
            if (admin != null)
            {
                admin.logIn();
                dataBase.update_admin(admin);
                return;
            }

            Manager manager = dataBase.searchManager(new Manager(userName));
            if (manager != null)
            {
                manager.logIn();
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

        public List<Business> searchBusiness(List<buisnessParameters> parameterName, List<string> parameterValue)
        {
            throw new NotImplementedException();
        }

        public List<Kupon> searchKoupon(List<KuponParameters> parameterName, List<string> parameterValue)
        {
            throw new NotImplementedException();
        }

        public void updateKupon(Business kouponID, Kupon updated)
        {
            throw new NotImplementedException();
        }

        public void updateKupon(string kouponID, Kupon updated)
        {
            throw new NotImplementedException();
        }

        public void updateKuponAlert(string userrName, string sensorTypr, string sensorInfo)
        {
            throw new NotImplementedException();
        }

        public void updateUser(List<UserParameters> parameterName, List<string> parameterValue)
        {
            throw new NotImplementedException();
        }

        public bool useKupon(string serialID)
        {
            Kupon useKupon = dataBase.searchKuponBySerialID(new Kupon(null,-1,null,null,Status.USED,-1,-1,new DateTime(),serialID,null));
            useKupon.setStatus(Status.USED);
            dataBase.update_userKupom(useKupon);
            return true;
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

        User IBSL.logIn(string userName, string Pass)
        {
            throw new NotImplementedException();
        }

        public void logOut(string userName)
        {
            throw new NotImplementedException();
        }

        public string getNewKuponID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
