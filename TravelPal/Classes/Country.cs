using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Classes
{
    public class Country
    {
        public static List<Country> EUCountries = new();
        public static List<Country> NonEUCountries = new();

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

        public string GetCountryType()
        {
            if (IsEUCountry()) return "EUCountry";
            if (IsNonEUCountry()) return "NonEUCountry";
            return "If you see this text then something is wrong with the TravelPal.Classes.Country Class";
        }

        public override string ToString()
        {
            if (IsEUCountry()) return euCountry.GetDescription();
            return nonEuCountry.GetDescription();
        }


        static Country()
        {
            foreach (EUCountries country in Enum.GetValues(typeof(EUCountries)))
            {
                EUCountries.Add(new Country(country));
            }
            foreach (NonEUcountries country in Enum.GetValues(typeof(NonEUcountries)))
            {
                NonEUCountries.Add(new Country(country));
            }
        }
    }
}
