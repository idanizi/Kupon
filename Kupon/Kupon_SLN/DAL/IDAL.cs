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
        void add_Admin(Admin admin);
        void add_Manager(Manager manager);
        void add_Client(Client client);
        void add_Business(Business business);

        void update_kupon(Kupon kupon);
        void update_Admin(Admin admin);
        void update_Manager(Manager manager);
        void update_Client(Client client);
        void update_Business(Business business);

        void delete_kupon(Kupon kupon);
        void delete_Admin(Admin admin);
        void delete_Manager(Manager manager);
        void delete_Client(Client client);
        void delete_Business(Business business);

    }
}
