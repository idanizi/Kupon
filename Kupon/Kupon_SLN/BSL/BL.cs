﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

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

        public void addNewKupon(Kupon newKupon)
        {
            dataBase.add_kupon(newKupon);
        }

        public void addNewUser(User user)
        {
            if (user.GetType() is Admin)
                dataBase.add_admin((Admin)user);
            if (user.GetType() is Client)
                dataBase.add_client((Client)user);
            if (user.GetType() is Manager)
                dataBase.add_manager((Manager)user);
        }

        public void approveNewKupon(Kupon newKupon)
        {
            newKupon.setStatus(KuponStatus.APPROVED);
            dataBase.update_kupon(newKupon);
        }

        public void buyNewKupon(string kuponID, string userName, string paymentDetails)
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
            return dataBase.searchKuponByStatus(KuponStatus.NEW);
        }

        public void restorUserPass(string userName)
        {
            User user = dataBase.searchUser(new User(userName));
            MailAddress to = new MailAddress(user.getEmail());
            MailAddress from = new MailAddress("");
            MailMessage message = new MailMessage(from, to);
            message.Body = "We are the king of the kupon!!!";
            message.Subject = "Kupon test";

            
            SmtpClient ClientSmtp = new SmtpClient("172.0.0.1");
            ClientSmtp.Send(message);
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

        public void updateKuponAlert(string userName, double latitude, double longtitude)
        {
            dataBase.add_location_user(dataBase.searchClient(new Client(userName)), latitude, longtitude);
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
    }
}
