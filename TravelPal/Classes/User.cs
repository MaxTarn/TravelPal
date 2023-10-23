using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;

namespace TravelPal.Classes
{
    internal class User : IUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public AllCountries Location { get; set; }
        public List<Travel> Travels { get; set; } = new List<Travel>();

        public User(string userName, string password, AllCountries location)
        {
            UserName = userName;
            Password = password;
            Location = location;
        }
    }
}
