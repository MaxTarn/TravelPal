using System;
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
        public Country CountryOfOrigin { get; set; }
        public List<Travel> Travels { get; set; } = new();
        public void AddTravel(Travel travel)
        {
            Travels.Add(travel);
        }

        public void RemoveTravel(Travel travel)
        {
            Travels.Remove(travel);
        }

        public User(string userName, string password, Country countryOfOrigin)
        {
            UserName = userName;
            Password = password;
            CountryOfOrigin = countryOfOrigin;
        }
    }
}
