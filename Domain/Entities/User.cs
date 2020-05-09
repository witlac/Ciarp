using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User
    {
        private string Name { get; set; }
        private string Password { get; set; }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
