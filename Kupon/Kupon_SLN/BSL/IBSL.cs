﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace BSL
{
    public interface IBSL
    {
        void addNewKupon(Kupon newKupon);
        Kupon buyNewKupon(String kouponID, String userrName, String paymentDetails);
        void addNewBusiness(Business newBusiness);
        void updateKuponAlert(String userrName, String sensorTypr, String sensorInfo);
        List<Kupon> getKuponForApproval(int numOfKupon);
        void approveNewKupon(Kupon newKupon);
        List<Kupon> searchKoupon(buisnessCategory category, double latitude, double longtitude);
        List<Business> searchBusiness(buisnessCategory category, double latitude, double longtitude);
        Kupon getKupon(String kouponID);
        void updateKupon(Kupon updated);
        void addNewUser(User user);
        User logIn(String userName, String Pass, double vertical, double horizontal);
        void logOut(String userName);
        void restorUserPass(String userrName);
        void updateUser(User user);
        bool useKupon(string serialkey);
        string getNewKuponID();
    }
}
