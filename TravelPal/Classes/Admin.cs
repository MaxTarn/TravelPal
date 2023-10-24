using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;

namespace TravelPal.Classes
{
    internal class Admin : IUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public AllCountries Location { get; set; }


        public Admin(string username, string password, AllCountries location)
        {
            UserName = username;
            Password = password;
            Location = location;
        }
    }
}
