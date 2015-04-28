using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace DAL
{
    public interface IDAL
    {
        void add_kupon(Kupon kupon);
        void add_Admin(Admin kupon);
        void add_Manager(Manager kupon);
        void add_Client(Client kupon);
        void add_kupon(Business kupon);

    }
}
