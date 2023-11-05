using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Classes;
using TravelPal.Interfaces;

namespace TravelPal.Managers;


public class UserManager : INotifyPropertyChanged
{

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }




    public List<IUser> Users = new();
    private IUser? _signedInUser;
    public IUser? SignedInUser
    {
        get => _signedInUser;
        set
        {
            if (_signedInUser == value) return;
            _signedInUser = value;
            OnPropertyChanged(nameof(SignedInUser));
            Manager.UserDetailsPage.UpdateGUI();
        }
    }


    public string AddUser(IUser addThisUser)
    {
        if (UserAlreadyExists(addThisUser)) return "User with that username already exists";
        Users.Add(addThisUser);
        return "User Added";
    }

    private bool UserAlreadyExists(IUser checkThisUser)
    {
        foreach (IUser user in Users)
        {
            if (user.UserName == checkThisUser.UserName) return true;
        }

        return false;
    }

    /// <summary>
    /// Loggs in the user with given userName and Password.
    /// If the given username doesnt exist or the password is wrong
    /// returns a non empty string with the error messege
    /// When all is good returns string.empty
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <returns>Returns string.empty when given username and password is good, else return is a error messege as string</returns>
    public string LogIn(string? userName, string? password)
    {
        if (userName == null) return "Write your user name!";
        if (password == null) return "Write your password!";
        if (userName.Trim().Equals("")) return "User name is empty!";
        if (password.Trim().Equals("")) return "Password is empty!";

        foreach (IUser user in Users)
        {
            if (!user.UserName.Equals(userName) || !user.Password.Equals(password)) continue;
            SignedInUser = user;
            return string.Empty;

        }
        return "User name or password is wrong!";
    }

    public string LogIn(IUser usr)
    {
        return LogIn(usr.UserName, usr.Password);
    }

    public UserManager()
    {
        Users.Add(new User("user", "password", new Country(EUCountries.Sweden)));
        Users.Add(new Admin("admin", "password", new Country(EUCountries.Finland)));

        User usr = (User)Users.Find(user => user.UserName == "user");

        usr.Travels.Add(new Travel()
        {
            TravelName = "Travel one",
            Destination = "london",
            FromCountry = new Country(NonEUcountries.UnitedKingdom),
            ToCountry = new Country(NonEUcountries.Afghanistan),
            Travellers = 2,
            PackingList = new List<IPackingListItem>()
            {
                new TravelDocument("passport", true)
            },
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(3),
            IsVacation = true,
            IsAllInclusive = true,

        });

        usr.Travels.Add(new Travel()
        {
            TravelName = "Travel two",
            Destination = "spain pain",
            FromCountry = new Country(NonEUcountries.UnitedKingdom),
            ToCountry = new Country(EUCountries.Spain),
            Travellers = 6,
            PackingList = new List<IPackingListItem>()
            {
                new TravelDocument("passport", true)
            },
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(2),
            IsWorkTrip = true,
            WorkTripDetails = "gonna do some work?"

        });

    }


}

