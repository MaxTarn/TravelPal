using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Classes;

namespace TravelPal.Interfaces;


public interface IUser
{
    string UserName { get; set; }
    string Password { get; set; }
    Country Location { get; set; }
    List<Travel> Travels { get; }
    public void AddTravel(Travel travel);
    public void RemoveTravel(Travel travel);
}

