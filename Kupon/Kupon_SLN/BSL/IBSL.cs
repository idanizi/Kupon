using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
namespace BSL
{
    public enum couponParameterType{};
      public enum bussinessParameterType{};
      public enum userParameterType{};

    public interface IBSL
    {
void addNewKupon(Kupon kupon, String userID);
bool validateNewUser(String UserName, String MailAdd);
void buyNewKupon(String kouponID, String userID, String paymentDetails);
void addNewBusiness(Business bus, String userID);
void updateAlert(String userID, String sensorTypr, String sensorInfo);
List<Kupon> getKuponForApproval(int numOfKupon);
List<Kupon> searchCoupon(List<couponParameterType> parameterName, List<String> parameterValue);
List<Business> searchBusiness(List<bussinessParameterType> parameterName, List<String> parameterValue);
Kupon getKupon(String kouponID);
void updateKupon(String kouponID,Kupon updated);
void updateKupon(List<Kupon> updated);
void addNewUser(List<userParameterType> parameterName, List<String> parameterValue);
User connectUser(String userID, String Pass);
void restorUserPass(String userID);
void updateUser(List<userParameterType> parameterName, List<String> parameterValue);
bool useKupon(String kouponID);
    }
}
