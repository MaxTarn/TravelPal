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
    public string? TravelName { get; set; }
    public string? Destination { get; set; }
    public Country? FromCountry { get; set; }
    public Country? ToCountry { get; set; }
    public int? Travellers { get; set; }
    public List<IPackingListItem> PackingList { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? TravelDays { get; set; }

    public bool? IsWorkTrip { get; set; }
    public string? WorkTripDetails { get; set; } = null;
    public bool? IsVacation { get; set; }
    public bool? IsAllInclusive { get; set; } = null;


    public Travel(string destination, Country FromCountry, Country ToCountry, DateTime startDate, DateTime endDate)
    {
        this.Destination = destination;
        this.FromCountry = FromCountry;
        this.ToCountry = ToCountry;
        this.StartDate = startDate;
        this.EndDate = endDate;
        TravelDays = endDate.Subtract(startDate).Days;
        PackingList = new();
    }

    public Travel()
    {
        PackingList = new();
    }
}

