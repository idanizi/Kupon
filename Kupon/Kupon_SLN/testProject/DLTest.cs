using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using DAL_server;
using NUnit.Framework;

namespace SolutionTest
{

    [TestFixture]
    public class DBTest
    {


        DB_manager server = new DB_manager();
        Admin admin;
        Manager manager;
        Business busines;
        Client client;
        List<Kupon> kuponList;

        [SetUp]
        public void setUP()
        {
            admin = new Admin("testadmin", "123", "Aa", "33", "ss", "ss");
            manager = new Manager("testmanger", "123", "Aa", "33", "ss", "ss");
            busines = new Business("testbusiness", "testbusiness", "city", "street", 10, "bus descreption", buisnessCategory.Food, manager, 0, 0);
            client = new Client("testclient", "123", "client@mail", "083333", "firstname", "lastname", new List<buisnessCategory>() { buisnessCategory.Food, buisnessCategory.Games }, new List<Kupon>(), "city", "address", 10);
            try{
                 Admin admin1 = new Admin("testadmin1", "123", "Aa", "33", "ss", "ss");
                 server.delete_admin(admin1);
            }catch{}
            try{
                Kupon kupon1 = new Kupon("abcx1234", 0, "testkupon1", "des", KuponStatus.APPROVED, 100, 50, new DateTime(2017, 1, 1), "", busines, 0);
                 server.delete_kupon(kupon1);
            }catch{}
              try{
                  Client client1 = new Client("testclient1", "123", "client@mail", "083333", "firstname", "lastname", new List<buisnessCategory>() { buisnessCategory.Food, buisnessCategory.Games }, new List<Kupon>(), "city", "address", 10);
                  server.delete_client(client1);
            }catch{}
              try
              {
                  Manager manager1 = new Manager("testmanger1", "123", "Aa", "33", "ss", "ss");
                  server.delete_manager(manager1);
              }
              catch { }
            try
            {
                server.delete_business(busines);
            }
            catch { }
            try
            {
                server.delete_manager(manager);

            }
            catch { }
            try
            {
                server.delete_business(busines);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }

            try
            {
                server.delete_admin(admin);
            }
            catch { }

            try
            {
                server.add_admin(admin);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }

   
            try
            {
                server.delete_client(client);
            }
            catch { }

            try
            {
                server.add_client(client);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }



        //kupon logic
        [Test]
        public void add_kupon()
        {
            server.add_manager(manager);
            server.add_business(busines);
            Kupon kupon1 = new Kupon("abcx12jj4", 0, "testkupon11221", "des", KuponStatus.NEW, 100, 50, new DateTime(2017, 1, 1), "", busines, 0);
            server.add_kupon(kupon1);
            Assert.IsNotNull(server.searchKuponByBusinesName("testbusiness"));
            server.delete_kupon(kupon1);
            server.delete_business(busines);
        }

        [Test]
        public void update_kupon()
        {
            server.add_manager(manager);
            server.add_business(busines);
            Kupon kupon1 = new Kupon("abcx1234", 0, "testkupon1", "des", KuponStatus.APPROVED, 100, 50, new DateTime(2017, 1, 1), "", busines, 0);
            server.add_kupon(kupon1);
            kupon1 = new Kupon("abcx1234", 5, "testkupon1", "des", KuponStatus.APPROVED, 100, 50, new DateTime(2017, 1, 1), "", busines, 0);
            server.update_kupon(kupon1);
            kuponList = server.searchKuponByBusinesName("testbusiness");
            Assert.AreEqual(kupon1.getRank(), 5);
            server.delete_business(busines);
        }

      
        [Test]
        public void searchKuponByID()
        {
            server.add_manager(manager);
            server.add_business(busines);
            Kupon kupon1 = new Kupon("abcx1234", 0, "testkupon1", "des", KuponStatus.APPROVED, 100, 50, new DateTime(2017, 1, 1), "", busines, 0);
            server.add_kupon(kupon1);
            kupon1 = server.searchKuponByID(kupon1);
            Assert.IsNotNull(kupon1);
            server.delete_business(busines);
        }


      
        [Test]
        public void add_admin()
        {

            Admin admin1 = new Admin("testadmin1", "123", "Aa", "33", "ss", "ss");
            server.add_admin(admin1);
            Assert.IsNotNull(server.searchUser(admin1));
            server.delete_admin(admin1);
        }
        [Test]
        public void update_admin()
        {
            Admin admin1 = new Admin("testadmin1", "123", "Aa", "33", "ss", "ss");
            server.add_admin(admin1);
            admin1 = new Admin("testadmin1", "123", "Bb", "33", "ss", "ss");
            server.update_admin(admin1);
            admin1 = server.searchAdmin(admin1);
            Assert.AreEqual(admin1.getEmail(), "Bb");
            server.delete_admin(admin1);
        }
        [Test]
        public void delete_admin()
        {
            Admin admin1 = new Admin("testadmin1", "123", "Aa", "33", "ss", "ss");
            server.add_admin(admin1);
            server.delete_admin(admin1);
            Assert.IsNull(server.searchUser(admin1));
        }
        [Test]
        public void searchAdmin()
        {
            Admin admin1 = new Admin("testadmin1", "123", "Aa", "33", "ss", "ss");
            server.add_admin(admin1);
            server.delete_admin(admin1);
            Assert.IsNull(server.searchAdmin(admin1));
        }
        //manager
        [Test]
        public void add_manager()
        {
            Manager manager1 = new Manager("testmanger1", "123", "Aa", "33", "ss", "ss");
            server.add_manager(manager1);
            Assert.IsNotNull(server.searchUser(manager1));
            server.delete_manager(manager1);
        }
        [Test]
        public void update_manager()
        {

            Manager manager1 = new Manager("testmanger1", "123", "Aa", "33", "ss", "ss");
            server.add_manager(manager1);
            manager1 = new Manager("testmanger1", "123", "Bb", "33", "ss", "ss");
            server.update_manager(manager1);
            manager1 = server.searchManager(manager1);
            Assert.AreEqual(manager1.getEmail(), "Bb");
            server.delete_manager(manager1);

        }
        [Test]
        public void delete_manager()
        {
            Manager manager1 = new Manager("testmanger1", "123", "Aa", "33", "ss", "ss");
            server.add_manager(manager1);
            server.delete_manager(manager1);
            Assert.IsNull(server.searchUser(manager1));

        }
        [Test]
        public void searchManager()
        {
            Manager manager1 = new Manager("testmanger1", "123", "Aa", "33", "ss", "ss");
            server.add_manager(manager1);
            server.delete_manager(manager1);
            Assert.IsNull(server.searchUser(manager1));
        }
        [Test]
        //client
        public void add_client()
        {
            Client client1 = new Client("testclient1", "123", "client@mail", "083333", "firstname", "lastname", new List<buisnessCategory>() { buisnessCategory.Food, buisnessCategory.Games }, new List<Kupon>(), "city", "address", 10);
            server.add_client(client1);
            Assert.IsNotNull(server.searchUser(client1));
            server.delete_client(client1);
        }
        [Test]
        public void update_client()
        {
            Client client1 = new Client("testclient1", "123", "client@mail", "083333", "firstname", "lastname", new List<buisnessCategory>() { buisnessCategory.Food, buisnessCategory.Games }, new List<Kupon>(), "city", "address", 10);
            server.add_client(client1);
            client1 = new Client("testclient", "123", "Bb", "083333", "firstname", "lastname", new List<buisnessCategory>() { buisnessCategory.Food, buisnessCategory.Games }, new List<Kupon>(), "city", "address", 10);
            server.update_client(client1);
            client1 = server.searchClient(client1);
            Assert.AreEqual(client1.getEmail(), "Bb");
            server.delete_client(client1);
        }
        [Test]
        public void delete_client()
        {
            Client client1 = new Client("testclient1", "123", "client@mail", "083333", "firstname", "lastname", new List<buisnessCategory>() { buisnessCategory.Food, buisnessCategory.Games }, new List<Kupon>(), "city", "address", 10);
            server.add_client(client1);
            server.delete_client(client1);
            Assert.IsNull(server.searchUser(client1));
        }
        [Test]
        public void searchClient() {
            Client client1 = new Client("testclient1", "123", "client@mail", "083333", "firstname", "lastname", new List<buisnessCategory>() { buisnessCategory.Food, buisnessCategory.Games }, new List<Kupon>(), "city", "address", 10);
            server.add_client(client1);
            Assert.IsNotNull(server.searchUser(client1));
            server.delete_client(client1);
        }

         [Test]
        public void add_business() {
            server.add_manager(manager);
            busines = new Business("testbusiness", "testbusiness", "city", "street", 10, "bus descreption", buisnessCategory.Food, manager, 0, 0);
            server.add_business(busines);
            Assert.IsNotNull(server.searchBusinnesByName("testbusiness"));
            server.delete_business(busines);
            server.delete_manager(manager);
        }


           [Test]
        public void update_business() {
            try
            {
                server.add_manager(manager);
                busines = new Business("testbusiness", "testbusiness", "city", "street", 10, "bus descreption", buisnessCategory.Food, manager, 0, 0);
                server.add_business(busines);
                busines = new Business("testbusiness", "testbusiness", "city2", "street", 10, "bus descreption", buisnessCategory.Food, manager, 0, 0);
                Assert.AreEqual(server.searchBusinnesByName("testbusiness")[0].getCity(), "city2");
                server.delete_business(busines);
            }
            catch { }
        
        }

        
           [Test]
        public void delete_business() {
            server.add_manager(manager);
           busines = new Business("testbusiness", "testbusiness", "city", "street", 10, "bus descreption", buisnessCategory.Food, manager, 0, 0);
            server.add_business(busines);
            server.delete_business(busines);
            Assert.IsEmpty(server.searchBusinnesByName("testbusiness"));
            server.delete_business(busines);
        }
        public void searchBusinnesByName() {
            server.add_manager(manager);
            busines = new Business("testbusiness", "testbusiness", "city", "street", 10, "bus descreption", buisnessCategory.Food, manager, 0, 0);
            server.add_business(busines);
            Assert.IsNotNull(server.searchBusinnesByName("testbusiness"));
            server.delete_business(busines);
        }
       
        public void searchKuponByBusinesName(string businessName) {
            server.add_business(busines);
            Kupon kupon1 = new Kupon("abcx1234", 0, "testkupon1", "des", KuponStatus.APPROVED, 100, 50, new DateTime(2017, 1, 1), "qwertyuiop", busines, 0);
            server.add_kupon(kupon1);
            kuponList = server.searchKuponByBusinesName("testbusiness");
            Assert.IsNotEmpty(kuponList);
            server.delete_business(busines);
        }



        [TearDown]
        public void tearDown()
        {
            Admin admin = new Admin("testadmin", "123", "Aa", "33", "ss", "ss");
            Manager manager = new Manager("manger", "123", "Aa", "33", "ss", "ss");
            Business business = new Business("testbusiness", "defualt", "city", "street", 10, "bus descreption", buisnessCategory.Food, manager, 0, 0);
            Client client = new Client("testclient", "123", "client@mail", "083333", "firstname", "lastname", new List<buisnessCategory>() { buisnessCategory.Food, buisnessCategory.Games }, new List<Kupon>(), "city", "address", 10);
            Kupon kupon2 = new Kupon("1234", 0, "testkupon", "des", KuponStatus.APPROVED, 100, 50, new DateTime(2017, 1, 1), "", busines, 0);

            try
            {
                server.delete_business(busines);
            }
            catch { }
            try
            {
                server.delete_business(busines);
            }
            catch { }

            try
            {

                server.delete_kupon(kupon2);

                try
                {
                    server.delete_business(business);
                }
                catch { }

                try
                {
                    server.delete_admin(admin);
                }
                catch { }
                try
                {
                    server.delete_business(business);
                }
                catch { }
                try
                {
                    server.delete_client(client);
                }
                catch { }

            }
            catch { }
            try
            {
                Admin admin1 = new Admin("testadmin1", "123", "Aa", "33", "ss", "ss");
                server.delete_admin(admin1);
            }
            catch { }
            try
            {
                Kupon kupon1 = new Kupon("123456", 0, "testkupon1", "des", KuponStatus.APPROVED, 100, 50, new DateTime(2017, 1, 1), "", busines, 0);
                server.delete_kupon(kupon1);
            }
            catch { }
            try
            {
                Client client1 = new Client("testclient1", "123", "client@mail", "083333", "firstname", "lastname", new List<buisnessCategory>() { buisnessCategory.Food, buisnessCategory.Games }, new List<Kupon>(), "city", "address", 10);
                server.delete_client(client1);
            }
            catch { }
            try
            {
                Manager manager1 = new Manager("testmanger1", "123", "Aa", "33", "ss", "ss");
                server.delete_manager(manager1);
            }
            catch { }
        }
    }
}
