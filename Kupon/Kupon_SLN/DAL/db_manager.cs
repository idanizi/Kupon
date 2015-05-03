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
            connetionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename='" + System.IO.Directory.GetCurrentDirectory() + "\\KuponDatabase.mdf';Integrated Security=True;Connect Timeout=30";
            cnn = new SqlConnection(connetionString);
        }

        public void add_kupon(Kupon kupon)
        {
             string query = "insert into [Kupon] values ('" + kupon.getID() + "','" + kupon.getName() + "','" + kupon.getDescription() + "'," + kupon.getOriginalPrice() + "," + kupon.getDicountPrice() + ",'" + kupon.getLastDate() + "','" + kupon.getBusiness().getId() + "','" + kupon.getStatus() + "');";
             sendQuery(query);
        }

        public void update_kupon(Kupon kupon)
        {
             string query = "UPDATE [Kupon] set  ID='" + kupon.getID() + "',name='" + kupon.getName() + "',description='" + kupon.getDescription() + "',originalPrice=" + kupon.getOriginalPrice() + ",discountPrice=" + kupon.getDicountPrice() + ",expDate='" + kupon.getLastDate() + "',businessID='" + kupon.getBusiness().getId() + "',status='" + kupon.getStatus() + "' where [Kupon].ID='" + kupon.getID() + "'";
             sendQuery(query);
        }

        public void delete_kupon(Kupon kupon)
        {
            string query = "delete from [Kupon] where ID='"+kupon.getID()+"';";
            sendQuery(query);
        }

        public void add_admin(Admin admin)
        {
            string query = "INSERT into [User] values ('" + admin.getName() + "','" + admin.getEmail() + "','" + admin.getPassword() + "'," + admin.getPhone() + ",'" + "Admin" + "','" + admin.getFirstName() + "','" + admin.getLastName() + "');";
            sendQuery(query);
        }

        public void delete_admin(Admin admin)
        {
              string query = "delete from [User]where name='"+admin.getName()+"';";
              sendQuery(query);
        }

        public void delete_manager(Manager manager)
        {
            string query = "delete from [User] where name='" + manager.getName() + "';";
            sendQuery(query);
        }

        public void add_manager(Manager manager)
        {
            string query = "INSERT into [User] values ('" + manager.getName() + "','" + manager.getEmail() + "','" + manager.getPassword() + "'," + manager.getPhone() + ",'" + "Manager" + "','" + manager.getFirstName() + "','" + manager.getLastName() + "');";
            sendQuery(query);
        }

        public void add_business(Business business)
        {
            string query = "INSERT into [Business] values ('" + business.getId() + "','" + business.getName() + "','" + business.getCity() + "','" + business.getStreet() + "'," + business.getNumber() + ",'" + business.getDescription() + "','" + business.getCatagory()+"','"+business.getManger().getName()+"');";
            sendQuery(query);
        }

        public void update_business(Business business)
        {
            string query = "UPDATE [Business] set  ID='" + business.getId() + "',name='" + business.getName() + "',city='"+business.getCity()+"',street='" + business.getStreet() + "',num=" + business.getNumber() + ",description='" + business.getDescription() + "',catagory='" + business.getCatagory() + "',manager='" + business.getManger().getName() + "'";
            sendQuery(query);
        }
        public void delete_business(Business business)
        {
            string query = "delete from [Business] where ID='" + business.getId() + "';";
            sendQuery(query);
        }

        public List<Business> searchBusinessByAdress(string city, string street, int number)
        {
            List<Business> business = new List<Business>();
            string query = "select * from [Business] where city='" + city + "' AND street='" + street + "' AND num=" + number + ";";
            SqlDataReader dr = sendAndReciveQuery(query);
            while (dr.Read())
            {
                business.Add(create_business(dr.GetString(0)));
            }
            dr.Close();
            return business;
        }

        public List<Business> searchBusinessBycatagory(string catagory)
        {
            List<Business> business = new List<Business>();
            string query = "select * from [Business] where catagory='" + catagory + "';";
            SqlDataReader dr = sendAndReciveQuery(query);
            while (dr.Read())
            {
                business.Add(create_business(dr.GetString(0)));
            }
            dr.Close();
            return business;
        }
        
        public List<Kupon> searchKuponByCatagory(string catagory)
        {
            List<Kupon> kupons = new List<Kupon>();
            string query = "select * from [kupon],[Businees] where [Kupon].businessID=[Business].ID AND catagory='" + catagory + "';";
            SqlDataReader dr = sendAndReciveQuery(query);
            while (dr.Read())
            {
                kupons.Add(create_kupon(dr));
            }
            dr.Close();
            return kupons;
        }

        List<Kupon> searchKuponByaddress(string city, string street, int number)
        {
            List<Kupon> kupons = new List<Kupon>();
            string query = "select * from [kupon],[Businees] where [Kupon].businessID=[Business].ID AND city='" + city + "' AND street='"+street+"' AND num="+number+";";
            SqlDataReader dr = sendAndReciveQuery(query);
            while (dr.Read())
            {
                kupons.Add(create_kupon(dr));
            }
            dr.Close();
            return kupons;
        }
        
        public List<Kupon> searchKuponByBuissnesName(string businessName)
        {
            List<Kupon> kupons = new List<Kupon>();
            string query = "select * from [kupon] where name='" + businessName + "';";
            SqlDataReader dr = sendAndReciveQuery(query);
            while (dr.Read())
            {
                kupons.Add(create_kupon(dr));
            }
            dr.Close();
            return kupons;
        }


        private Kupon create_kupon(SqlDataReader dr)
        {
            Business business = create_business(dr.GetString(6));
            DateTime date = dr.GetDateTime(5);
            Status status = craete_status(dr.GetString(7));
            return new Kupon(dr.GetString(0), dr.GetString(1), dr.GetString(2), status, dr.GetInt32(3), dr.GetInt32(4), date, null, business);
        }

        private Status craete_status(string status)
        {
           if(status.Equals(Status.ACTIVE.ToString()))return Status.ACTIVE;
           else if (status.Equals(Status.APPROVED.ToString())) return Status.APPROVED;
           else if (status.Equals(Status.NEW.ToString())) return Status.NEW;
           else return Status.USED;
        }

        private Business create_business(string businessID)
        {
            string query = "select * from [Business] where ID='" + businessID + "';";
            SqlDataReader dr = sendAndReciveQuery(query);
            dr.Read();
            Business business = new Business(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetInt32(4), dr.GetString(5), dr.GetString(6), create_manager(dr.GetString(7)));
            dr.Close();
            return business;
        }

        private Manager create_manager(string userName) 
        {
            string query = "select * from [User] where name='" + userName + "';";
            SqlDataReader dr = sendAndReciveQuery(query);
            dr.Read();
            Manager manager=new Manager(dr.GetString(0), dr.GetString(2), dr.GetString(1), dr.GetInt16(3), dr.GetString(5), dr.GetString(6));
            dr.Close();
            return manager;
        }

        //recive query and return the result
        private SqlDataReader sendAndReciveQuery(string query)
        {
            SqlDataReader dr=null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                cnn.Close();
            }
            return dr;
        }

        //recive query and send the query to the data base
        private void sendQuery(string query)
        {
            try
            {
                cnn.Open();
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
    }
}
