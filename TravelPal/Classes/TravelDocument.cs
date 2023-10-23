using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;

namespace TravelPal.Classes;

internal class TravelDocument : IPackingListItem
{
    public string Name { get; set; }
    public string Info { get; set; }
    public bool Required { get; set; }


    public TravelDocument(string name, bool required)
    {

    }
}

