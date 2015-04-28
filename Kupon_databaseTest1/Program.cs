using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Kupon_databaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //open a new connection to the DB
            string path = "|DataDirectory|\\DB\\dataDB.accdb;";//DB path

            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" + path + "; Persist Security Info=False;"); //connect to the DB
            OleDbCommand cmd = new OleDbCommand();//the command line to the DB

            cmd = new OleDbCommand("select [User].name from [User];");
            cmd.Connection = conn;
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr.GetString(0));
            }
        }
    }
}
