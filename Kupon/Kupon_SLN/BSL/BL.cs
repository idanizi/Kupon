using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Util;
using DAL_Client;
using System.Net;
using System.Net.Mail;

namespace BSL
{
    public class BL : IBSL
    {
        //server services
        private IServices dataBase;
        //client DAL
        private IDAL_Client localdataBase;

        //constructor
        public BL()
        {
            this.dataBase = new ServicesProvider();
            this.localdataBase = new DB_Client_manager();
        }

        public void addNewBusiness(Business newBusiness)
        {
            dataBase.add_manager(newBusiness.getManger());
            dataBase.add_business(newBusiness);
        }

        public void addNewKupon(Kupon newKupon)
        {
            dataBase.add_kupon(newKupon);
        }

        /*need to throw exception if doesn't succeed (when missing a parameter). talk with yochai
        dont know which kind of user*/
        public void addNewUser(User user)
        {
            if (user is Admin)
            {
                dataBase.add_admin((Admin)user);
            }
            else if (user is Client)
            {
                dataBase.add_client((Client)user);
            }
            else if (user is Manager)
            {
                dataBase.add_manager((Manager)user);
            }
            else throw new Exception("worng type of user");
        }

        /*the admin should call this when he approved
        how to notify the client about the new kupon?
        add func ClientsByCity(newKupon.getBusiness().getCity()) in DAL.talk to matan*/
        public void approveNewKupon(Kupon newKupon)
        {
            newKupon.setStatus(KuponStatus.APPROVED);
            dataBase.update_kupon(newKupon);
        }

        /* tell matan to add dataBase.searchKuponByID() */
        public Kupon buyNewKupon(string kuponID, string userName, string paymentDetails)
        {
            Kupon kupon = dataBase.searchKuponByID(new Kupon(kuponID));
            if (kupon == null)
                throw new ArgumentException("This kupon doesn't exist");

            if (kupon.getStatus() != KuponStatus.APPROVED)
                throw new ArgumentException("This kupon doesn't approved yet");

            Client client = dataBase.searchClient(new Client(userName));
            kupon.setStatus(KuponStatus.ACTIVE);
            kupon.setSerialKey(getNewKuponID());
            client.addKupon(kupon);
            dataBase.add_userKupon(client, kupon);
            localdataBase.add_userKupon(client,kupon);

            return kupon;
        }

        public User logIn(string userName, string Pass, double latitude, double longtitude)
        {
            //search in local db
            Client client = localdataBase.searchClient(new Client(userName));
            localdataBase.delete_exp();
            if (client != null)
            {
                if (!client.getPassword().Equals(Pass))
                    return null;
                client.logIn();
                dataBase.add_location_user(client, latitude, longtitude);
                localdataBase.update_client(client);
                return client;
            }
            else
            {
                client = dataBase.searchClient(new Client(userName));
               // dataBase.delete_exp();
                if (client != null)
                {
                    if (!client.getPassword().Equals(Pass))
                        return null;
                    client.logIn();
                    dataBase.add_location_user(client, latitude, longtitude);
                    localdataBase.add_client(client);
                    return client;
                }
            } 

            Admin admin = localdataBase.searchAdmin(new Admin(userName));
            if (admin != null)
            {
                if (!admin.getPassword().Equals(Pass))
                    return null;
                admin.logIn();
                localdataBase.update_admin(admin);
                return admin;
            }
            else
            {
                admin = dataBase.searchAdmin(new Admin(userName));
                if (admin != null)
                {
                    if (!admin.getPassword().Equals(Pass))
                        return null;
                    admin.logIn();
                    localdataBase.add_admin(admin);
                    return admin;
                }
            }

            Manager manager = localdataBase.searchManager(new Manager(userName));
            if (manager != null)
            {
                if (!manager.getPassword().Equals(Pass))
                    return null;
                manager.logIn();
                localdataBase.update_manager(manager);
                return manager;
            }
            else
            {
                manager = dataBase.searchManager(new Manager(userName));
                if (manager != null)
                {
                    if (!manager.getPassword().Equals(Pass))
                        return null;
                    manager.logIn();
                    localdataBase.add_manager(manager);
                    return manager;
                }
            }

            return null;
        }

        public void logOut(string userName)
        {
            Client client = dataBase.searchClient(new Client(userName));
            if (client != null)
            {
                client.logOut();
                localdataBase.update_client(client);
                return;
            }

            Admin admin = dataBase.searchAdmin(new Admin(userName));
            if (admin != null)
            {
                admin.logOut();
                localdataBase.update_admin(admin);
                return;
            }

            Manager manager = dataBase.searchManager(new Manager(userName));
            if (manager != null)
            {
                manager.logOut();
                localdataBase.update_manager(manager);
                return;
            }
        }

        public Kupon getKupon(string kuponID)
        {
            return dataBase.searchKuponByID(new Kupon(kuponID));
        }

        public List<Kupon> getKuponForApproval(int numOfKupon)
        {
            return dataBase.searchKuponByStatus(KuponStatus.NEW);
        }

        public void restorUserPass(string userrName)
        {
            User user = localdataBase.searchUser(new User(userrName));
            if (user == null){
                user = dataBase.searchUser(new Client(userrName));
                if (user == null) throw new Exception("invalit user");
                else
                {
                    sendMail("restor password", user.getEmail(), "your password is: " + user.getPassword());
                }
            }
            else
            {
                sendMail("restor password", user.getEmail(), "your password is: " + user.getPassword());
            }
        }

        public List<Business> searchBusiness(buisnessCategory category, double latitude, double longtitude)
        {
            if (category != null)
            {
                if (latitude != -1 && longtitude != -1)
                    return dataBase.searchBusinessBycatagory_location(category.ToString(), latitude, longtitude, 10);
                return dataBase.searchBusinessBycatagory(category.ToString());
            }
            return null;
        }

        public List<Kupon> searchKoupon(buisnessCategory category, double latitude, double longtitude)
        {
            if (category != null)
            {
                if (latitude != -1 && longtitude != -1)
                    return dataBase.searchKuponByCatagory_location(category.ToString(), latitude, longtitude, 10);
                return dataBase.searchKuponByCatagory(category.ToString());
            }
            return null;
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
            if (user is Admin)
                dataBase.update_admin((Admin)user);
                localdataBase.update_admin((Admin)user);
            if (user is Client)
            {
                dataBase.update_client((Client)user);
                dataBase.update_userFavorite((Client)user, ((Client)user).getFavorits());
                localdataBase.update_client((Client)user);
                localdataBase.update_userFavorite((Client)user, ((Client)user).getFavorits());
            }
            if (user is Manager)
                dataBase.update_manager((Manager)user);
                localdataBase.update_manager((Manager)user); 
        }

        public bool useKupon(string serialkey)
        {/*
            Kupon kupon = new Kupon(null, serialkey);
            kupon= dataBase.searchKuponBySerialID(kupon);
            kupon.setSerialKey(serialkey);
          */
            localdataBase.setStatusUsed(serialkey);
            return dataBase.setStatusUsed(serialkey);
        }

        private string extractVariable(List<UserParameters> parameterName, List<string> parameterValue, UserParameters type)
        {
            for (int i = 0; i < parameterName.Count(); i++)
            {
                if (parameterName.ElementAt(i) == type)
                    return parameterValue.ElementAt(i);
            }
            throw new ArgumentException("Missing parameter- " + type);
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

        public string getNewKuponID()
        {
            return Guid.NewGuid().ToString("N");
        }


        public Business searchManagerBusiness(Manager manager)
        {
            return dataBase.searchBUsinessByManager(manager);
        }

        public List<Kupon> getKuponsForUser(User user)
        {
            List<Kupon> kupons= localdataBase.searchKuponByUser(user);
            if (kupons != null) return kupons;
            else return dataBase.searchKuponByUser(user);
        }

        public List<Business> searchBusinessByName(string p)
        {
            return dataBase.searchBusinnesByName(p);
        }

        public List<Kupon> searchKouponByCity(string p)
        {
            return dataBase.searchKuponByCity(p);
        }

        public List<Business> searchBusinessByCity(string p)
        {
            return dataBase.searchBusinessByCity(p);
        }

        public List<Kupon> searchKouponByName(string p)
        {
            return dataBase.searchKuponByName(p);
        }

        public void updateBusiness(Business record)
        {
            dataBase.update_business(record);
        }

        public void sendMail(string Subject, string mail, string text)
        {
            MailMessage msg = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            msg.From = new MailAddress("yochailehman@gmail.com");
            msg.To.Add(mail);
            msg.Subject = Subject;
            msg.Body = text;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("yochailehman", "hjhknIg1");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(msg);
        }



        public void deleteKupon(Kupon kupon)
        {
            dataBase.delete_kupon(kupon);
        }

        public void deleteBusiness(Business business)
        {
            dataBase.delete_business(business);
        }

        public List<Kupon> searchKouponByBusiness(Business business)
        {
            return dataBase.searchKuponByBusinesName(business.getName());
        }

        public void getPurchestKuponsForBusness(Business business)
        {
            throw new NotImplementedException();
        }

        public bool rankKupon(Kupon kupon, int i)
        {
            kupon.setRank(i);
            dataBase.update_userKupon(kupon);
            return true;
        }

        public void deleteUser(Admin admin)
        {
            dataBase.delete_admin(admin);
            try
            {
                localdataBase.delete_admin(admin);
            }
            catch { }
        }

        public void deleteUser(Client client)
        {
            dataBase.delete_client(client);
            try
            {
                localdataBase.delete_client(client);
            }
            catch { }
        }

        public void deleteUser(Manager manager)
        {
            dataBase.delete_manager(manager);
            try
            {
                localdataBase.delete_manager(manager);
            }
            catch { }
        }
    }
}

