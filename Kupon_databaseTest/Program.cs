using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;


namespace Kupon_databaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ////open a new connection to the DB
            ////string path = "|DataDirectory|\\DB\\dataDB.accdb;";//DB path
            //string path = "IDAN-PC\\SQLEXPRESS\\KuponDatabase.accdb";

            //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source =" + path + "; Persist Security Info=False;"); //connect to the DB
            //OleDbCommand cmd = new OleDbCommand();//the command line to the DB

            ////SqlConnection conn = 

            //cmd = new OleDbCommand("select [User].name from [User];");
            //cmd.Connection = conn;
            //conn.Open();
            //OleDbDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    Console.WriteLine(dr.GetString(0));
            //}


            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=IDAN-PC\\SQLEXPRESS;Initial Catalog=KuponDatabase;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            SqlCommand cmd;
            try
            {
                Console.WriteLine("try to open");
                cnn.Open();
                Console.WriteLine("Connection Open ! ");

                string sqlLine = "select [User].name from [User];";
                cmd = new SqlCommand(sqlLine, cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr.GetString(0));
                }
                
                
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
                Console.WriteLine(ex.StackTrace);
            }
            finally{
                Console.ReadLine();
                Console.WriteLine("finish");
            }
        }
    }
}
