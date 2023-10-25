using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;

namespace TravelPal.Classes;


public class Travel
{
    public string Destination { get; set; }
    public Country ChosenCountry { get; set; }
    public int Travellers { get; set; }
    public List<IPackingListItem> PackingList;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TravelDays { get; set; }

    public Travel(string destination, Country chosenCountry, DateTime startDate, DateTime endDate)
    {
        this.Destination = destination;
        this.ChosenCountry = chosenCountry;
        this.StartDate = startDate;
        this.EndDate = endDate;
        TravelDays = endDate.Subtract(startDate).Days;

        if (TravelDays <= 0)
        {
            //TODO implement error messege to the user
            throw new NotImplementedException();
        }
    }
}

