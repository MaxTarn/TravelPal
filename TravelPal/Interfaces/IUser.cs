using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Classes;

namespace TravelPal.Interfaces;


public interface IUser : INotifyPropertyChanged
{
    string UserName { get; set; }
    string Password { get; set; }
    Country CountryOfOrigin { get; set; }
    List<Travel> Travels { get; }
    public void AddTravel(Travel travel);
    public void RemoveTravel(Travel travel);
}

