using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;

namespace TravelPal.Classes
{

    public class OtherItem : IPackingListItem
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public int Quantity { get; set; }

        public OtherItem(string name, int quantity)
        {

        }
    }
}
