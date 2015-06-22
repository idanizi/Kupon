using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using BSL;
using NUnit.Framework;

namespace SolutionTest
{

   [TestFixture]
    public class LogicTest
    {

      
       BL server = new BL();
        Admin admin;
           Manager manager;
           Business busines;
           Client client ;
     
       [SetUp]
       public void setUP()
       {
           admin = new Admin("testadmin", "123", "Aa", "33", "ss", "ss");
           manager = new Manager("testmanger", "123", "Aa", "33", "ss", "ss");
           busines = new Business("testbusiness", "testbusiness", "city", "street", 10, "bus descreption", buisnessCategory.Food, manager, 0, 0);
            client = new Client("testclient", "123", "client@mail", "083333", "firstname", "lastname", new List<buisnessCategory>() { buisnessCategory.Food, buisnessCategory.Games }, new List<Kupon>(), "city", "address", 10);

           try
               {
                server.deleteBusiness(busines);
               }catch{}
           try
           {
               server.deleteUser(manager);

           }
           catch { }
           try
           {
               server.addNewBusiness(busines);
           }
           catch(Exception ex) {
               Assert.Fail(ex.ToString());
           }

          try
               {
                  server.deleteUser(admin);
               }catch{}

          try
          {
              server.addNewUser(admin);
          }
          catch (Exception ex)
          {
              Assert.Fail(ex.ToString());
          }

          

            try
            {
                server.deleteUser(client);
            }
            catch { }

            try
            {
                server.addNewUser(client);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
           
       }

       [Test]
       public void kupon_logic()
       {
           List<Kupon> kuponList = null ;
           Kupon kupon = new Kupon("1234", 0, "testkupon", "des", KuponStatus.NEW, 100, 50, new DateTime(2017,1,1), "", busines,0);
           server.addNewKupon(kupon);
           server.approveNewKupon(kupon);
           kuponList = server.searchKouponByBusiness(busines);
           Assert.AreEqual(kuponList[0].getStatus(), KuponStatus.APPROVED);
           kuponList = server.searchKouponByBusiness(busines);
           Assert.AreEqual(kupon.getID(),kuponList[0].getID());
       //   server.updateKupon(new Kupon("1234", 0, "testkupon", "des", KuponStatus.NEW, 100, 20, new DateTime(2017, 1, 1), "", busines,0));
        //   kuponList = server.searchKouponByBusiness(busines);
          // Assert.AreEqual(kuponList[0].getDicountPrice(),20);
          
           server.buyNewKupon("1234", "testclient", "paypal");
           kuponList = server.searchKouponByBusiness(busines);
           Assert.AreEqual(kuponList[0].getNumOfBuy(),1);
           server.deleteKupon(kupon);
           kuponList = server.searchKouponByBusiness(busines);
             Assert.IsEmpty(kuponList);
       }

       [Test]
       public void business_logic()
       {

           List<Business> busList = server.searchBusinessByName("testbusiness");
           Assert.AreEqual(busines.getName(),   busList[0].getName());
           busines = new Business("testbusiness", "testbusiness", "city2", "street", 10, "bus descreption", buisnessCategory.Food, manager, 0, 0);
           server.updateBusiness(busines);
           busList = server.searchBusinessByName("testbusiness");
           Assert.AreEqual(busList[0].getCity(),"city2");
           server.deleteBusiness(busines);
           busList = server.searchBusinessByName("testbusiness");
           Assert.IsEmpty(busList);
       }

       [Test]
        public void client_logic()
           {
            try{
             Client client2 = (Client)server.logIn("testclient", "123", 100, 100);
            Assert.AreEqual(client2.getName(),client.getName());
            server.sendMail("blabla",client.getEmail(),"blabla");
            server.logOut("testclient");
            client = new Client("testclient", "123", "client123@mail", "083333", "firstname", "lastname", new List<buisnessCategory>() { buisnessCategory.Food, buisnessCategory.Games }, new List<Kupon>(), "city", "address", 10);

          server.updateUser(client);
          client = (Client)server.logIn("testclient", "123", 100, 100);
            Assert.AreEqual(client.getEmail(),"client123@mail");
            server.deleteUser(client);
                try{
                    client = (Client)server.logIn("testclient", "123", 100, 100);
                    Assert.Fail();
                }catch{
                     
                }

            }catch(Exception Ex){
                Assert.Fail(Ex.ToString());
            }
         
       }


 [TearDown]
       public void tearDown()
       {
           Admin admin = new Admin("testadmin", "123", "Aa", "33", "ss", "ss");
           Manager manager = new Manager("manger", "123", "Aa", "33", "ss", "ss");
           Business business = new Business("testbusiness", "defualt", "city", "street", 10, "bus descreption", buisnessCategory.Food, manager, 0, 0);
           Client client = new Client("testclient", "123", "client@mail", "083333", "firstname", "lastname", new List<buisnessCategory>() { buisnessCategory.Food, buisnessCategory.Games }, new List<Kupon>(), "city", "address", 10);

           try
               {
                server.deleteBusiness(business);
               }catch{}

          try
               {
                  server.deleteUser(admin);
               }catch{}
            try
               {
                 server.deleteBusiness(business);
               }catch{}
           try
               {
                  server.deleteUser(client);
               }catch{}  
                
       }

       }
    
}
