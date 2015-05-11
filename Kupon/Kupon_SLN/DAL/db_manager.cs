using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace DAL
{
    public class DB_manager:IDAL
    {
        string connetionString;
        SqlConnection cnn;

        public DB_manager()
        {
            //connetionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename='" + System.IO.Directory.GetCurrentDirectory() + "\\KuponDatabase.mdf';Integrated Security=True;Connect Timeout=30";
            connetionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename='C:\\Users\\user\\matan\\לימודים\\Kupon\\Kupon\\Kupon_SLN\\DAL\\KuponDatabase.mdf';Integrated Security=True;Connect Timeout=30";
            cnn = new SqlConnection(connetionString);
        }

        public void add_kupon(Kupon kupon)
        {
             string query = "insert into [Kupon] values ('" + kupon.getID() + "','" + kupon.getName() + "','" + kupon.getDescription() + "'," + kupon.getOriginalPrice() + "," + kupon.getDicountPrice() + ",'" + kupon.getLastDate() + "','" + kupon.getBusiness().getId() + "','" + kupon.getStatus() + "');";
             sendQuery(query);
        }

        public void update_kupon(Kupon kupon)
        {
             string query = "UPDATE [Kupon] set  ID='" + kupon.getID() + "',name='" + kupon.getName() + "',description='" + kupon.getDescription() + "',originalPrice=" + kupon.getOriginalPrice() + ",discountPrice=" + kupon.getDicountPrice() + ",expDate='" + kupon.getLastDate() + "',businessID='" + kupon.getBusiness().getId() + "',status='" + kupon.getStatus() + "' where [Kupon].ID='" + kupon.getID() + "';"; 
            sendQuery(query);
        }

        public void delete_kupon(Kupon kupon)
        {
            string query = "delete from [Kupon] where ID='"+kupon.getID()+"';";
            sendQuery(query);
        }

        public void add_admin(Admin admin)
        {
            string query = "INSERT into [User] values ('" + admin.getName() + "','" + admin.getEmail() + "','" + admin.getPassword() + "','" + admin.getPhone() + "','" + "Admin" + "','" + admin.getFirstName() + "','" + admin.getLastName() + "',NULL,NULL,NULL);";
            sendQuery(query);
        }

        public void delete_admin(Admin admin)
        {
              string query = "delete from [User]where name='"+admin.getName()+"';";
              sendQuery(query);
        }

        public Kupon searchKuponByID(Kupon kupon)
        {
            return null;
        }

        public void delete_manager(Manager manager)
        {
            string query = "delete from [User] where name='" + manager.getName() + "';";
            sendQuery(query);
        }

        public void update_admin(Admin admin)
        {
            delete_admin(admin);
            add_admin(admin);
        }

        public void update_manager(Manager manager)
        {
            delete_manager(manager);
            add_manager(manager);
        }

        public void add_manager(Manager manager)
        {
            string query = "INSERT into [User] values ('" + manager.getName() + "','" + manager.getEmail() + "','" + manager.getPassword() + "','" + manager.getPhone() + "','" + "Manager" + "','" + manager.getFirstName() + "','" + manager.getLastName() + "',NULL,NULL,NULL);";
            sendQuery(query);
        }

        public void add_business(Business business)
        {
            string query = "INSERT into [Business] values ('" + business.getId() + "','" + business.getName() + "','" + business.getCity() + "','" + business.getStreet() + "'," + business.getNumber() + ",'" + business.getDescription() + "','" + business.getCatagory()+"','"+business.getManger().getName()+"',"+business.getVertical()+","+business.getHorizontal()+");";
            sendQuery(query);
        }

        public void add_client(Client client)
        {
            string query = "INSERT into [User] values ('" + client.getName() + "','" + client.getEmail() + "','" + client.getPassword() + "','" + client.getPhone() + "','" + "Client" + "','" + client.getFirstName() + "','" + client.getLastName() + "','"+client.getCity()+"','"+client.getStreet()+"',"+client.getNumber()+");";
            sendQuery(query);
            foreach (string favor in client.getFavor())
            {
                query = "INSERT into [userFavorites] values ('" + client.getName() + "','" + favor + "');";
                sendQuery(query);
            }

            foreach (Kupon kupon in client.getKupon())
            {
                query="INSERT into [UsersKupon] values ('"+kupon.getSerialKey()+"','"+client.getName()+"','"+kupon.getID()+"',"+kupon.getRank()+");";
                sendQuery(query);
            }
        }

        public void update_client(Client client)
        {
            delete_client(client);
            add_client(client);
        }

        public void delete_client(Client client)
        {
            string query = "delete from [User] where name='" + client.getName() + "';";
            sendQuery(query);
        }

        public void update_business(Business business)
        {
            string query = "UPDATE [Business] set  name='" + business.getName() + "',city='"+business.getCity()+"',street='" + business.getStreet() + "',num=" + business.getNumber() + ",description='" + business.getDescription() + "',category='" + business.getCatagory() + "',manager='" + business.getManger().getName() +"',vertical="+business.getVertical()+",horizontal= "+business.getHorizontal()+" WHERE ID='"+business.getId()+"';";
            sendQuery(query);
        }

        public void delete_business(Business business)
        {
            string query = "delete from [Business] where ID='" + business.getId() + "';";
            sendQuery(query);
        }

        public List<Business> searchBusinessByAddress(string city, string street, int number)
        {
            List<Business> business = new List<Business>();
            List<string> businessID = new List<string>();
            string query = "select * from [Business] where city='" + city + "' AND street='" + street + "' AND num=" + number + ";";
            SqlDataReader dr = sendAndReciveQuery(query);
            while (dr.Read())
            {
                businessID.Add(dr.GetString(0));
            }
            dr.Close();
            cnn.Close();
            foreach (string businessName in businessID)
            {
                business.Add(create_business(businessName));
            }
            return business;
        }

        public List<Business> searchBusinessBycatagory(string catagory)
        {
            List<Business> business = new List<Business>();
            List<string> businessID = new List<string>();
            string query = "select * from [Business] where category='" + catagory + "';";
            SqlDataReader dr = sendAndReciveQuery(query);
            while (dr.Read())
            {
                businessID.Add(dr.GetString(0));
            }
            dr.Close();
            cnn.Close();
            foreach (string businessName in businessID)
            {
                business.Add(create_business(businessName));
            }
            return business;
        }
        
        public List<Kupon> searchKuponByCatagory(string catagory)
        {
            List<string> kuponId = new List<string>();
            List<Kupon> kupons = new List<Kupon>();
            string query = "select * from [kupon],[Business] where [Kupon].businessID=[Business].ID AND category='" + catagory + "';";
            SqlDataReader dr = sendAndReciveQuery(query);
            while (dr.Read())
            {
                kuponId.Add(dr.GetString(0));
            }
            dr.Close();
            cnn.Close();
            foreach (string kupon in kuponId)
            {
                kupons.Add(create_kupon(kupon));
            }
            return kupons;
        }

        public List<Kupon> searchKuponByAddress(string city, string street, int number)
        {
            List<string> kuponId = new List<string>();
            List<Kupon> kupons = new List<Kupon>();
            string query = "select * from [kupon],[Business] where [Kupon].businessID=[Business].ID AND city='" + city + "' AND street='"+street+"' AND num="+number+";";
            SqlDataReader dr = sendAndReciveQuery(query);
            while (dr.Read())
            {
                kuponId.Add(dr.GetString(0));
            }
            dr.Close();
            cnn.Close();
            foreach (string kupon in kuponId)
            {
                kupons.Add(create_kupon(kupon));
            }
            return kupons;
        }

        public List<Kupon> searchKuponByUser(User user)
        {
            List<string> kuponId = new List<string>();
            List<Kupon> kupons = new List<Kupon>();
            string query = "select * from [kupon] where ID in (select DISTINCT kuponID from [UsersKupon] where username='" + user.getName() + "');";
            SqlDataReader dr = sendAndReciveQuery(query);
            while (dr.Read())
            {
                kuponId.Add(dr.GetString(0));
            }
            dr.Close();
            cnn.Close();
            foreach (string kupon in kuponId)
            {
                kupons.Add(create_kupon(kupon));
            }
            return kupons;
        }

        public List<Kupon> searchKuponByBusinesName(string businessName)
        {
            List<string> kuponId = new List<string>();
            List<Kupon> kupons = new List<Kupon>();
            string query = "select * from [kupon] where businessID in (select ID from [Business] where name='" + businessName + "');";
            SqlDataReader dr = sendAndReciveQuery(query);
            while (dr.Read())
            {
                kuponId.Add(dr.GetString(0));
            }
            dr.Close();
            cnn.Close();
            foreach (string kupon in kuponId)
            {
                kupons.Add(create_kupon(kupon));
            }
            return kupons;
        }

        public void add_location_user(User user,double vertical,double horizontal)
        {
            string query = "INSERT into [userLocation] values ('" + user.getName() + "','" + DateTime.Now + "'," + vertical + "," + horizontal + ");";
            sendQuery(query);
        }

        public void add_userKupon(User user,Kupon kupon)
        {
            string query = "INSERT into [UserKupon] values ('" + kupon.getSerialKey() + "','" + user.getName() + "','" + kupon.getID() + "'," + kupon.getRank() + ");";
            sendQuery(query);
        }

        public List<Kupon> searchKuponByStatus(KuponStatus status)
        {
            List<string> kuponId = new List<string>();
            List<Kupon> kupons = new List<Kupon>();
            string query = "select * from [kupon] where status='"+status+ "';";
            SqlDataReader dr = sendAndReciveQuery(query);
            while (dr.Read())
            {
                kuponId.Add(dr.GetString(0));
            }
            dr.Close();
            cnn.Close();
            foreach (string kupon in kuponId)
            {
                kupons.Add(create_kupon(kupon));
            }
            return kupons;
        }

        public Admin searchAdmin(Admin admin)
        {
            string username;
            string query = "select * from [User] where [User].name = '"+admin.getName()+"' AND [User].access='"+"Admin"+"';";
            SqlDataReader dr = sendAndReciveQuery(query);
            if (dr.Read())
            {
            username = dr.GetString(0);
            dr.Close();
            cnn.Close();
            return create_admin(username);
            }else return null;
        }

        public Kupon searchKuponBySerialID(Kupon kupon)

        {
            string query = "select * from [kupon] where status='" + kupon.getSerialKey() + "';";
            SqlDataReader dr = sendAndReciveQuery(query);
            dr.Read();
            string kuponId = dr.GetString(0);
            dr.Close();
            cnn.Close();
            return create_kupon(kuponId);
        }

        public Manager searchManager(Manager manager)
        {
            string username;
            string query = "select * from [User] where [User].name = '" + manager.getName() + "' AND [User].access='" + "Manager" + "';";
            SqlDataReader dr = sendAndReciveQuery(query);
            if (dr.Read())
            {
                username = dr.GetString(0);
                dr.Close();
                cnn.Close();
                return create_manager(username);
            }
            else return null;
        }

        public Client searchClient(Client client)
        {
            throw new NotImplementedException();
        }

        private Admin create_admin(string username)
        {
            string query = "select * from [User] where name='" + username + "';";
            SqlDataReader dr = sendAndReciveQuery(query);
            dr.Read();
            Admin admin = new Admin(dr.GetString(0), dr.GetString(2), dr.GetString(1), dr.GetString(3), dr.GetString(5), dr.GetString(6));
            dr.Close();
            cnn.Close();
            return admin;
        }
        public void update_userKupom(Kupon kupon)
        {
            string query = "UPDATE [UserKupon] set  status='" + kupon.getStatus() +"' where [Kupon].authorizationID='" + kupon.getSerialKey() + "';";
            sendQuery(query);
        }

        private Kupon create_kupon(string kuponId)
        {
            string query = "select * from [kupon] where [Kupon].ID='" + kuponId +"';";
            SqlDataReader dr = sendAndReciveQuery(query);
            dr.Read();
            string businessId = dr.GetString(6);
            DateTime date = dr.GetDateTime(5);
            KuponStatus status = craete_status(dr.GetString(7));
            int originalPrice=dr.GetInt32(3);
            int discountPrice=dr.GetInt32(4);
            Kupon kupon = new Kupon(dr.GetString(0), -1, dr.GetString(1), dr.GetString(2), status, originalPrice, discountPrice, date, null, null);
            dr.Close();
            cnn.Close();
            Business business = create_business(businessId);
            kupon.setBusiness(business);
            return kupon;
        }

        private KuponStatus craete_status(string status)
        {
            if (status.Equals(KuponStatus.ACTIVE.ToString())) return KuponStatus.ACTIVE;
            else if (status.Equals(KuponStatus.APPROVED.ToString())) return KuponStatus.APPROVED;
            else if (status.Equals(KuponStatus.NEW.ToString())) return KuponStatus.NEW;
            else return KuponStatus.USED;
        }

        private Business create_business(string businessID)
        {
            string query = "select * from [Business] where ID='" + businessID + "';";
            SqlDataReader dr = sendAndReciveQuery(query);
            dr.Read();
            Business business = new Business(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetInt32(4), dr.GetString(5), dr.GetString(6),null,dr.GetDouble(8),dr.GetDouble(9));
            string managerName=dr.GetString(7);
            dr.Close();
            cnn.Close();
            business.setManager(create_manager(managerName));
            return business;
        }

        private Manager create_manager(string userName) 
        {
            string query = "select * from [User] where name='" + userName + "';";
            SqlDataReader dr = sendAndReciveQuery(query);
            dr.Read();
            Manager manager = new Manager(dr.GetString(0), dr.GetString(2), dr.GetString(1), dr.GetString(3), dr.GetString(5), dr.GetString(6));
            dr.Close();
            cnn.Close();
            return manager;
        }


        //recive query and return the result
        private SqlDataReader sendAndReciveQuery(string query)
        {
            SqlDataReader dr=null;
            try
            {
                cnn.Open();
                Console.WriteLine(query);
                Console.ReadLine();
                SqlCommand cmd = new SqlCommand(query, cnn);
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.Read();
            }
            return dr;
        }

        //recive query and send the query to the data base
        private void sendQuery(string query)
        {
            try
            {
                cnn.Open();
                Console.WriteLine(query);
                Console.ReadLine();
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                cnn.Close();
            }
        }



        public List<Business> searchBusinessBycatagory_location(string catagory, double vertical, double horizontal, int radius)
        {
            List<Business> business = new List<Business>();
            List<string> businessID = new List<string>();
            string query = "select * from [Business] where category='" + catagory + "' AND vertical BETWEEN " + (vertical - radius) + " AND " + (vertical + radius) + " AND horizontal BETWEEN " + (horizontal - radius) + " AND " + (horizontal + radius) + ";";
            SqlDataReader dr = sendAndReciveQuery(query);
            while (dr.Read())
            {
                businessID.Add(dr.GetString(0));
            }
            dr.Close();
            cnn.Close();
            foreach (string businessName in businessID)
            {
                business.Add(create_business(businessName));
            }
            return business;
        }

        public List<Kupon> searchKuponByCatagory_location(string catagory, double vertical, double horizontal, int radius)
        {
            List<string> kuponId = new List<string>();
            List<Kupon> kupons = new List<Kupon>();
            string query = "select * from [kupon],[Business] where [Kupon].businessID=[Business].ID AND category='" + catagory + "' AND vertical BETWEEN " + (vertical - radius) + " AND " + (vertical + radius) + " AND horizontal BETWEEN " + (horizontal - radius) + " AND " + (horizontal + radius) + ";";
            SqlDataReader dr = sendAndReciveQuery(query);
            while (dr.Read())
            {
                kuponId.Add(dr.GetString(0));
            }
            dr.Close();
            cnn.Close();
            foreach (string kupon in kuponId)
            {
                kupons.Add(create_kupon(kupon));
            }
            return kupons;
        }
    }
}
