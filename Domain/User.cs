using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        
        public User(string username, string password, string salt)
        {
            Username = username;
            Password = password;
            Salt = salt;
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
