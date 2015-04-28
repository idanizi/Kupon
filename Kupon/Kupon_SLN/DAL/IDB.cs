using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace DAL
{
    interface IDB
    {
        void add_kupon(Kupon kupon);
        void add_admin(Admin kupon);
        void add_manager(Manager kupon);
        void add_client(Client kupon);
        void add_business(Business kupon);

    }
}
