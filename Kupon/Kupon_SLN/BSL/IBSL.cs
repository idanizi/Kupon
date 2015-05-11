using System;
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
            void buyNewKupon(String kouponID, String userrName, String paymentDetails);
            void addNewBusiness(Business newBusiness );
            void updateKuponAlert(String userrName, String sensorTypr, String sensorInfo);
            List<Kupon> getKuponForApproval(int numOfKupon);
            void approveNewKupon(Kupon newKupon);
            List<Kupon> searchKoupon(buisnessCategory category, string city, double latitude, double longtitude);
            List<Business> searchBusiness(List<buisnessParameters> parameterName, List<String> parameterValue);
            Kupon getKupon(String kouponID);
            void updateKupon(Kupon updated);
            void addNewUser(User user);
            User logIn(string userName, string Pass, double latitude, double longtitude);
            void logOut(String userName);
            void restorUserPass(String userrName);
            void updateUser(User user);
            bool useKupon(String kouponID);
            string getNewKuponID();

    }
}
