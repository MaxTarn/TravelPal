using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Classes;
using TravelPal.Interfaces;

namespace TravelPal.Managers
{
    internal class UserManager
    {
        public List<IUser> Users = new();
        public IUser SignedInUser { get; set; } = null;


        public void AddUser(User addThisUser)
        {

        }

        public UserManager()
        {
            Users.Add(new User("user", "password", AllCountries.Sweden));
        }
    }
}
