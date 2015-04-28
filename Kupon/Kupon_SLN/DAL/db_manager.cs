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
        SqlCommand cmd;

        public DB_manager()
        {
            connetionString = connetionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename='" + System.IO.Directory.GetCurrentDirectory() + "\\KuponDatabase.mdf';Integrated Security=True;Connect Timeout=30";
            cnn = new SqlConnection(connetionString);
            cmd = new SqlCommand();
            initDataBase();
        }
        //init the coonection
        private void initDataBase() {
            try{
                Console.WriteLine("try to open connection ");
            cnn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("finish");
            }
        }

        public void add_kupon(Kupon kupon)
        {
            throw new NotImplementedException();
        }

        public void add_Admin(Admin kupon)
        {
            throw new NotImplementedException();
        }

        public void add_Manager(Manager kupon)
        {
            throw new NotImplementedException();
        }

        public void add_Client(Client kupon)
        {
            throw new NotImplementedException();
        }

        public void add_kupon(Util.Business kupon)
        {
            throw new NotImplementedException();
        }
    }
}
