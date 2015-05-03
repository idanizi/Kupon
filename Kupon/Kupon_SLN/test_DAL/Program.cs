using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Util;

namespace test_DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            DB_manager dataBase = new DB_manager();

            dataBase.delete_admin(new Admin("matan", "blabla", "matan@gmail.com", 9511749, "matan", "bezen"));
        }
    }
}
