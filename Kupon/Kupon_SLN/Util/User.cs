using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class User
    {
        private string name;
        private string password;
        private string email;
        private int phone;
        private string firstName;
        private string lastName;
        private Boolean statusConnection;

        public User(string name, string password, string email, int phone, string firstName, string lastName)
        {
            this.name = name;
            this.password = password;
            this.email = email;
            this.phone = phone;
            this.firstName = firstName;
            this.lastName = lastName;
            this.statusConnection = false;
        }

        public  string getName()
        {
            return name;
        }
        public string getPassword()
        {
            return password;
        }

        public string getEmail()
        {
            return email;
        }

        public int getPhone()
        {
            return phone;
        }
        public string getFirstName()
        {
            return firstName;
        }

        public string getLastName()
        {
            return lastName;
        }

    }
}
