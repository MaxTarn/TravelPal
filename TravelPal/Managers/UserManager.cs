using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Classes;
using TravelPal.Interfaces;

namespace TravelPal.Managers;


public class UserManager
{
    public List<IUser> Users = new();
    public IUser SignedInUser { get; set; } = null;


    public void AddUser(IUser addThisUser)
    {
        Users.Add(addThisUser);
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


    public UserManager()
    {
        Users.Add(new User("user", "password", new Country(EUCountries.Sweden)));
        Users.Add(new Admin("admin", "password", new Country(EUCountries.Finland)));
    }
}

