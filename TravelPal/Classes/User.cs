using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;

namespace TravelPal.Classes
{

    public class User : IUser
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public string UserName { get; set; }
        public string Password { get; set; }
        public Country CountryOfOrigin { get; set; }
        public List<Travel> Travels { get; set; }

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
            Travels = new();
            UserName = userName;
            Password = password;
            CountryOfOrigin = countryOfOrigin;
        }


    }
}
