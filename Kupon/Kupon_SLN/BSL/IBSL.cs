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
            void addNewKupon(Kupon newKupon, String userrName);
            void buyNewKupon(String kouponID, String userrName, String paymentDetails);
            void addNewBusiness(Business newBusiness, String userrName);
            void updateKuponAlert(String userrName, String sensorTypr, String sensorInfo);
            List<Kupon> getKuponForApproval(int numOfKupon);
            void approveNewKupon(Kupon newKupon);
            List<Kupon> searchKoupon(List<KuponParameters> parameterName, List<String> parameterValue);
            List<Business> searchBusiness(List<buisnessParameters> parameterName, List<String> parameterValue);
            Kupon getKupon(String kouponID);
            void updateKupon(String kouponID, Kupon updated);
            void updateKupon(Business kouponID, Kupon updated);
            void addNewUser(List<UserParameters> parameterName, List<String> parameterValue);
            User logIn(String userName, String Pass);
            void logOut(String userName);
            void restorUserPass(String userrName);
            void updateUser(List<UserParameters> parameterName, List<String> parameterValue);
            bool useKupon(String kouponID);


            string getNewKuponID();
    }
}
