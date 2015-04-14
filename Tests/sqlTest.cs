using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data;
using System.Data.SqlClient;

namespace Tests
{
    [TestFixture]
    public class sqlTest
    {
        string connetionString;
        SqlConnection cnn;
        SqlCommand cmd;

        [SetUp]
        public void setUP()
        {
            connetionString = "Data Source=IDAN-PC\\SQLEXPRESS;Initial Catalog=KuponDatabase;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            try
            {
                Console.WriteLine("try to open");
                cnn.Open();
                Console.WriteLine("Connection Open ! ");

                string sqlLine = "insert into [User] (name,email,password,phone,access) values ('admin', 'admin@gmail.com','pass1','08-9992211','admin');" +
                "insert into [User] (name,email,password,phone,access,firstName, lastName) values ('moshe', 'moshe@gmail.com','pass2','08-9992233','manager', 'moshe', 'elzam');" +
                "insert into [User] (name,email,password,phone,access,firstName, lastName) values ('itzik', 'itzik@gmail.com','pass3','08-9992244','client', 'itzik', 'lebo');" +
                "insert into [Business] values ('1','shnitzale', 'Beer-sheva', 'itzhak rager', 10, 'shnitzel store for good shnitzel', 'food', 'itzik');" +
                "insert into [Favorites] values ('moshe', 'FOOD')" +
                "insert into [Kupon] values ('11', 'koko kupon', 'kupon with 10 present descount', 120.00, 108.00, '01/01/2016', '1','NEW');" +
                "insert into [UsersKupon] values ('1', 'itzik', '11', 4);";
                cmd = new SqlCommand(sqlLine, cnn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.ReadLine();
                Console.WriteLine("finish");
            }

        }

        [Test]
        public void select_userName()
        {
            string sqlLine = "select [User].name from [User];";
            cmd = new SqlCommand(sqlLine, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Assert.AreEqual(dr.GetString(0), "admin");
            }
            dr.Close();
        }


        [Test]
        public void select_userNameByCatagory()
        {
            string sqlLine = "select [Favorites].category from [User],[Favorites] where[User].name=[Favorites].username;";
            cmd = new SqlCommand(sqlLine, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Assert.AreEqual(dr.GetString(0), "FOOD");
            }
            dr.Close();
        }


        [Test]
        public void add_user()
        {
            string sqlLine = "insert into [User] (name,email,password,phone,access,firstName, lastName) values ('idan121', 'idan@gmail.com','pass2','08-9992233','manager', 'idan', 'izi');";
            cmd = new SqlCommand(sqlLine, cnn);
            cmd.ExecuteNonQuery();
            sqlLine = "select [User].name from [User] where [User].name = 'idan121';";
            cmd = new SqlCommand(sqlLine, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Assert.AreEqual("idan121", dr.GetString(0));
            }
            dr.Close();
        }

        [Test]
        public void search_businessByCatagory()
        {
            string sqlLine = "select [Business].name from [Business] where [Business].name='food';";
            cmd = new SqlCommand(sqlLine, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Assert.AreEqual(dr.GetString(0), "shnitzale");
            }
            dr.Close();
        }

        [Test]
        public void search_businessByCity()
        {
            String sqlLine = "UPDATE [User] set [User].email='bezen@gmail.com' where [User].name='moshe'";
            cmd = new SqlCommand(sqlLine, cnn);
            cmd.ExecuteNonQuery();
            sqlLine = "select [User].name from [User] where name='shnitzale' ;";
            cmd = new SqlCommand(sqlLine, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Assert.AreEqual(dr.GetString(0), "shnitzale");
            }
            dr.Close();
        }

        [Test]
        public void delete_kupon()
        {
            String sqlLine = "delete from [Kupon] where name ='koko kupon'";
            cmd = new SqlCommand(sqlLine, cnn);
            cmd.ExecuteNonQuery();
            sqlLine = "select [Kupon].name from [Kupon] where name='koko kupon' ;";
            cmd = new SqlCommand(sqlLine, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Assert.AreNotEqual(dr.GetString(0), "koko kupon");
            }
            else
            {
                Console.WriteLine("delete kupon pass");
                dr.Close();
                Assert.Pass();
            }
            dr.Close();
        }

        [Test]
        public void delete_user()
        {
            String sqlLine = "delete from [User] where name ='moshe'";
            cmd = new SqlCommand(sqlLine, cnn);
            cmd.ExecuteNonQuery();
            sqlLine = "select [User].name from [User] where name='moshe' ;";
            cmd = new SqlCommand(sqlLine, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Assert.AreNotEqual(dr.GetString(0), "moshe");
            }
            else
            {
                Console.WriteLine("delete user pass");
                dr.Close();
                Assert.Pass();
            }
            dr.Close();
        }

        [Test]
        public void update_statusKupon()
        {
            String sqlLine = "UPDATE [Kupon] set [Kupon].status='APPROVED' where [Kupon].name='koko kupon'";
            cmd = new SqlCommand(sqlLine, cnn);
            cmd.ExecuteNonQuery();
            sqlLine = "select [Kupon].status from [Kupon] where name='koko kupon' ;";
            cmd = new SqlCommand(sqlLine, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Assert.AreEqual(dr.GetString(0), "APPROVED");
            }
            dr.Close();
        }

        [Test]
        public void add_kupon()
        {
            String sqlLine = "insert into [Kupon] values ('12', 'zizi kupon', 'kupon with 103 present descount', 120.00, 108.00, '01/01/2016', '1','NEW');";
            cmd = new SqlCommand(sqlLine, cnn);
            cmd.ExecuteNonQuery();
            sqlLine = "select [Kupon].name from [Kupon] where name='zizi kupon' ;";
            cmd = new SqlCommand(sqlLine, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Assert.AreEqual(dr.GetString(0), "zizi kupon");
            }
            dr.Close();
        }

        [Test]
        public void search_KuponsOfUser()
        {
            String sqlLine = "select count(*) from [UsersKupon] where [UsersKupon].username='itzik'";
            cmd = new SqlCommand(sqlLine, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Assert.AreEqual(dr.GetInt32(0), 1);
            }
            dr.Close();
        }

        [TearDown]
        public void tearDown()
        {
            String sqlLine = "delete from [KuponDatabase].dbo.[UsersKupon];";
            sqlLine += "delete from [KuponDatabase].dbo.[Kupon];";
            sqlLine += "delete from [KuponDatabase].dbo.[Business];";
            sqlLine += "delete from [KuponDatabase].dbo.[Favorites];";
            sqlLine += "delete from [KuponDatabase].dbo.[User];";
            cmd = new SqlCommand(sqlLine, cnn);
            cmd.ExecuteNonQuery();
            try
            {
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }


    }
}
