using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Pages;

namespace TravelPal.Managers;

internal static class Manager
{
    //---------- Pages ----------


    internal static HeaderPage HeaderPage = new();
    internal static LogInPage LogInPage = new();
    internal static SplashScreenPage SplashScreenPage = new();


    //---------- Pages END ----------



    //---------- Managers ----------


    internal static TravelManager TravelManager = new();
    internal static UserManager UserManager = new();


    //---------- Managers END ----------



    //---------- The Main window ----------
    internal static MainWindow MainWindow = new();
}

