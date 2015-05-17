using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using BSL;
namespace test_DAL
{
    class Program
    {
        static void Main(string[] args)
        {
         /*   IDAL dataBase = new DB_manager();
            Manager manager = new Manager("matan", "blabla", "matan@gmail.com", "9511749", "matan", "bezen");
            Manager manager2 = new Manager("ran", "blabla", "matan@gmail.com", "9511749", "matan", "bezen");
            Business business = new Business("1", "mega", "rishon", "lala", 12, "mega is the best", "shop", manager,100.12,123.23);
            Business business2 = new Business("2", "mega6", "beersheva", "rager", 166, "mega is the best", "shop", manager2,125.32,189.23);
            Kupon kupon = new Kupon("1", 0, "nasa", "10% dis", Status.ACTIVE, 100, 12, new DateTime(2018, 11, 11), "s;s23pd3", business);
            Kupon kupon3 = new Kupon("2", 0, "matat", "89% dis", Status.ACTIVE, 123, 13, new DateTime(2016, 11, 11), "s;sdlk", business);
            Kupon kupon2 = new Kupon("3", 0, "kup", "40% dis", Status.ACTIVE, 120, 12, new DateTime(2020, 11, 11), "s;ss332", business2);
            List<Kupon> kupons = new List<Kupon>();
            kupons.Add(kupon);
            List<string> favor = new List<string>();
            favor.Add("shop");
            favor.Add("sport");
            favor.Add("games");
            Client client = new Client("lior", "1212", "gmail..", "020203", "lior", "nans", favor, kupons, "naharia", "mama", 23);
            //dataBase.delete_admin(new Admin("matan", "blabla", "matan@gmail.com", 9511749, "matan", "bezen"));
            //dataBase.add_admin(new Admin("matan", "blabla", "matan@gmail.com", 9511749, "matan", "bezen"));
            //dataBase.add_manager(new Manager("ran", "blabla", "matan@gmail.com", 9511749, "matan", "bezen"));
            //dataBase.delete_manager(new Manager("ran", "blabla", "matan@gmail.com", 9511749, "matan", "bezen"));
            // dataBase.add_business(business2);
            // dataBase.delete_business(business);
            // dataBase.update_business(business2);
            //dataBase.add_kupon(kupon);
            //dataBase.update_kupon(kupon);
            //dataBase.delete_kupon(kupon);
            /* List<Business> bus=dataBase.searchBusinessBycatagory("shop");
             foreach (Business busi in bus) Console.WriteLine(busi.getId() + "\n");*/
            /*List<Business> bus=dataBase.searchBusinessByAddress("rishon","lala",166);
            foreach (Business busi in bus) Console.WriteLine(busi.getId() + "\n");*/
            //dataBase.add_client(client);
            //dataBase.delete_client(client);
            // dataBase.add_kupon(kupon2);
            /*   kupons=dataBase.searchKuponByCatagory("shop");
               foreach (Kupon kup in kupons) Console.WriteLine(kup.getID() + "  ");
           }*/
            /*
            kupons = dataBase.searchKuponByAddress("beersheva", "rager", 166);
            foreach (Kupon kup in kupons) Console.WriteLine(kup.getID() + "  ");
            */
           /* dataBase.add_kupon(kupon3);
            kupons = dataBase.searchKuponByBusinesName("mega2");
            foreach (Kupon kup in kupons) Console.WriteLine(kup.getID() + "  ");*/
            /*dataBase.add_location_user(client,12.001, 122.03);
            dataBase.add_location_user(client, 12.04401, 122.03);
            dataBase.add_location_user(client, 12.00451, 1422.03);
            dataBase.add_location_user(client, 132.0301, 1252.03);
            dataBase.add_location_user(client, 142.001, 1322.03);*/
           /* kupons = dataBase.searchKuponByUser(client);
            foreach (Kupon kup in kupons) Console.WriteLine(kup.getID() + "  ");
            Console.ReadLine();*/
            /*
            for (int i=0;i<1000;i++){
                Console.WriteLine(Guid.NewGuid().ToString("N"));
            }
            Console.ReadLine();*/
        }
    }
}
