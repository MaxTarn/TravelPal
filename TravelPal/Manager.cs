using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelPal;
using TravelPal.Managers;
using TravelPal.Pages;



public class Manager
{

    //---------- Managers ----------


    public static TravelManager TravelManager = new();
    public static UserManager UserManager = new();


    //---------- Managers END ----------



    //---------- Pages ----------


    public static HeaderPage HeaderPage = new();
    public static LogInPage LogInPage = new();
    public static SplashScreenPage SplashScreenPage = new();
    public static RegisterPage RegisterPage = new();
    public static TravelPage TravelPage = new();
    public static AddNewTravelPage AddNewTravelPage = new();
    public static PackingListPage PackingListPage = new();
    public static ChooseTravelPage ChooseTravelPage = new();
    public static UserDetailsPage UserDetailsPage = new();
    public static ViewTheTravelPage ViewTheTravelPage = new();

    //---------- Pages END ----------


    //---------- The Main window ----------
    public static MainWindow Window = (MainWindow)Application.Current.MainWindow; // took me an entire day to debug and find that this worked


}

