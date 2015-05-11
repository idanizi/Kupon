using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public enum UserParameters
    {
        USERNAME,
        PASSOWRD,
        EMAIL,
        PHONE,
        FIRSTNAME,
        LASTNAME
    };

    public class User
    {
        private string name;
        private string password;
        private string email;
        private string phone;
        private string firstName;
        private string lastName;
        private Boolean statusConnection;

        public User(string name, string password, string email, string phone, string firstName, string lastName)
        {
            this.name = name;
            this.password = password;
            this.email = email;
            this.phone = phone;
            this.firstName = firstName;
            this.lastName = lastName;
            this.statusConnection = false;
        }

        public User(string username)
        {
            this.name = username;
            this.password = null;
            this.email = null;
            this.phone = null;
            this.firstName = null;
            this.lastName = null;
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

        public string getPhone()
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

        public void logIn()
        {
            statusConnection = true;
        }

        public void logOut()
        {
            statusConnection = false;
        }

    }
}
