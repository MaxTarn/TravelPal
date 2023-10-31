using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;

namespace TravelPal.Classes;



public class Admin : IUser
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public Country? Location { get; set; }
    public List<Travel> Travels { get; } = new();
    public void AddTravel(Travel travel)
    {
        Travels.Add(travel);
    }

    public void RemoveTravel(Travel travel)
    {
        Travels.Remove(travel);
    }


    public Admin(string username, string password, Country location)
    {
        UserName = username;
        Password = password;
        Location = location;
    }
}

