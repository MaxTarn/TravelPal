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

    public bool LogIn(string userName, string password)
    {
        if (userName.Trim().Equals("")) return false;
        if (password.Trim().Equals("")) return false;


        foreach (IUser user in Users)
        {
            if (user.UserName == userName && user.Password == password)
            {
                SignedInUser = user;
                return true;
            }
        }
        return false;
    }


    public UserManager()
    {
        Users.Add(new User("user", "password", AllCountries.Sweden));
        Users.Add(new Admin("admin", "password", AllCountries.Finland));
    }
}

