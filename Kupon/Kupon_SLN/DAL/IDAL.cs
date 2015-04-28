using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IDAL
    {
        void addNewKupon(Kupon new,String userID);
void buyNewKupon(String kouponID,String userID,String paymentDetails);
void addNewBusiness(Business new,String userID);
void updateKuponAlert(String userID,String sensorTypr,String sensorInfo);
List<Kupon> getKuponForApproval(int numOfKupon);
void approveNewKupon(Kupon new);
List<Kupon> searchCoupon(List<Enum couponParameterType> parameterName,List<String> parameterValue);
List<Business> searchBusiness(List<Enum bussinessParameterType> parameterName,List<String> parameterValue);
Kupon getKupon(String kouponID);
void updateKupon(String kouponID,Kupon updated);
Kupon getKupon(String kouponID);
void updateKupon(Business kouponID,Kupon updated);
void addNewUser(List<Enum userParameterType> parameterName,List<String> parameterValue);
bool connectUser(String userID,Sring Pass);
void restorUserPass(String userID);
void updateUser(List<Enum userParameterType> parameterName,List<String> parameterValue);
bool useKupon(String kouponID);
    }
}
