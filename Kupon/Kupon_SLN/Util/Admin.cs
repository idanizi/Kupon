using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Admin: User
    {
        public Admin(string name, string password, string email, string phone, string firstName, string lastName)
            : base(name,password,email,phone,firstName,lastName)
        {
        }

        public Admin(string username)
            : base(username){}
    }
}
