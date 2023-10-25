﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;

namespace TravelPal.Classes
{

    public class User : IUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }
        public List<Travel> Travels { get; set; } = new();

        public User(string userName, string password, Country location)
        {
            UserName = userName;
            Password = password;
            Location = location;
        }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
