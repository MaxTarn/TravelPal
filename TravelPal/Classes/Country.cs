using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Classes
{
    public class Country
    {
        private EUCountries? euCountry = null;
        private NonEUcountries? nonEuCountry = null;

        public bool IsEUCountry()
        {
            return nonEuCountry == null;
        }

        public bool IsNonEUCountry()
        {
            return euCountry == null;
        }
        public Country(EUCountries country)
        {
            euCountry = country;
        }

        public Country(NonEUcountries country)
        {
            nonEuCountry = country;
        }

        public void GetCountry(out EUCountries? country)
        {
            country = null;
            if (IsNonEUCountry()) return;

            country = (EUCountries)euCountry;
        }
        public void GetCountry(out NonEUcountries? country)
        {
            country = null;
            if (IsEUCountry()) return;

            country = (NonEUcountries)nonEuCountry;
        }

        public new string GetType()
        {
            if (IsEUCountry()) return "EU Country";
            if (IsNonEUCountry()) return "Non EU country";
            return "If you see this text then something is wrong with the TravelPal.Classes.Country Class";
        }

        public override string ToString()
        {
            if (IsEUCountry()) return euCountry.ToString();
            if (IsNonEUCountry()) return euCountry.ToString();
            return "If you see this text then something is wrong with the TravelPal.Classes.Country Class";
        }
    }
}
