using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Interfaces
{
    internal interface IPackingListItem
    {
        public string Name { get; set; }
        public string Info { get; set; }
        //public string GetInfo();
    }
}
