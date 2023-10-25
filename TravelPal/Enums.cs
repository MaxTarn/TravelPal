using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal;

public enum EUCountries
{
    [Description("Austria")]
    Austria,
    [Description("Belgium")]
    Belgium,
    [Description("Bulgaria")]
    Bulgaria,
    [Description("Croatia")]
    Croatia,
    [Description("Republic of Cyprus")]
    RepublicOfCyprus,
    [Description("Czech Republic")]
    CzechRepublic,
    [Description("Denmark")]
    Denmark,
    [Description("Estonia")]
    Estonia,
    [Description("Finland")]
    Finland,
    [Description("France")]
    France,
    [Description("Germany")]
    Germany,
    [Description("Greece")]
    Greece,
    [Description("Hungary")]
    Hungary,
    [Description("Ireland")]
    Ireland,
    [Description("Italy")]
    Italy,
    [Description("Latvia")]
    Latvia,
    [Description("Lithuania")]
    Lithuania,
    [Description("Luxembourg")]
    Luxembourg,
    [Description("Malta")]
    Malta,
    [Description("Netherlands")]
    Netherlands,
    [Description("Poland")]
    Poland,
    [Description("Portugal")]
    Portugal,
    [Description("Romania")]
    Romania,
    [Description("Slovakia")]
    Slovakia,
    [Description("Slovenia")]
    Slovenia,
    [Description("Spain")]
    Spain,
    [Description("Sweden")]
    Sweden

}

public enum NonEUcountries
{
    //according to https://www.britannica.com/topic/list-of-countries-1993160
    //this was taken from a list of ALL countries
    // I tried my best to remove all the contries that are EU countries, based on the EUCountries
    //There might be some countries that I didnt get
    [Description("Afghanistan")]
    Afghanistan,
    [Description("Albania")]
    Albania,
    [Description("Algeria")]
    Algeria,
    [Description("Andorra")]
    Andorra,
    [Description("Angola")]
    Angola,
    [Description("Antigua and Barbuda")]
    AntiguaAndBarbuda,
    [Description("Argentina")]
    Argentina,
    [Description("Armenia")]
    Armenia,
    [Description("Australia")]
    Australia,
    [Description("Azerbaijan")]
    Azerbaijan,
    [Description("The Bahamas")]
    TheBahamas,
    [Description("Bahrain")]
    Bahrain,
    [Description("Bangladesh")]
    Bangladesh,
    [Description("Barbados")]
    Barbados,
    [Description("Belarus")]
    Belarus,
    [Description("Belize")]
    Belize,
    [Description("Benin")]
    Benin,
    [Description("Bhutan")]
    Bhutan,
    [Description("Bolivia")]
    Bolivia,
    [Description("Bosnia and Herzegovina")]
    BosniaAndHerzegovina,
    [Description("Botswana")]
    Botswana,
    [Description("Brazil")]
    Brazil,
    [Description("Brunei")]
    Brunei,
    [Description("Burkina Faso")]
    BurkinaFaso,
    [Description("Burundi")]
    Burundi,
    [Description("Cabo Verde")]
    CaboVerde,
    [Description("Cambodia")]
    Cambodia,
    [Description("Cameroon")]
    Cameroon,
    [Description("Canada")]
    Canada,
    [Description("CentralAfricanRepublic")]
    CentralAfricanRepublic,
    [Description("Chad")]
    Chad,
    [Description("Chile")]
    Chile,
    [Description("China")]
    China,
    [Description("Colombia")]
    Colombia,
    [Description("Comoros")]
    Comoros,
    [Description("Democratic Republic of the Congo")]
    DemocraticRepublicOfTheCongo,
    [Description("Republic of the Congo")]
    RepublicOfTheCongo,
    [Description("Costa Rica")]
    CostaRica,
    [Description("Cuba")]
    Cuba,
    [Description("Djibouti")]
    Djibouti,
    [Description("Dominica")]
    Dominica,
    [Description("Dominican Republic")]
    DominicanRepublic,
    [Description("East Timor")]
    EastTimor,
    [Description("Ecuador")]
    Ecuador,
    [Description("Egypt")]
    Egypt,
    [Description("El Salvador")]
    ElSalvador,
    [Description("Equatorial Guinea")]
    EquatorialGuinea,
    [Description("Eritrea")]
    Eritrea,
    [Description("Eswatini")]
    Eswatini,
    [Description("Ethiopia")]
    Ethiopia,
    [Description("Fiji")]
    Fiji,
    [Description("Gabon")]
    Gabon,
    [Description("Gambia")]
    Gambia,
    [Description("Georgia")]
    Georgia,
    [Description("Ghana")]
    Ghana,
    [Description("Grenada")]
    Grenada,
    [Description("Guatemala")]
    Guatemala,
    [Description("Guinea")]
    Guinea,
    [Description("Guinea Bissau")]
    GuineaBissau,
    [Description("Guyana")]
    Guyana,
    [Description("Haiti")]
    Haiti,
    [Description("Honduras")]
    Honduras,
    [Description("Iceland")]
    Iceland,
    [Description("India")]
    India,
    [Description("Indonesia")]
    Indonesia,
    [Description("Iran")]
    Iran,
    [Description("Iraq")]
    Iraq,
    [Description("Israel")]
    Israel,
    [Description("Jamaica")]
    Jamaica,
    [Description("Japan")]
    Japan,
    [Description("Jordan")]
    Jordan,
    [Description("Kazakhstan")]
    Kazakhstan,
    [Description("Kenya")]
    Kenya,
    [Description("Kiribati")]
    Kiribati,
    [Description("Korea North")]
    KoreaNorth,
    [Description("Korea South")]
    KoreaSouth,
    [Description("Kosovo")]
    Kosovo,
    [Description("Kuwait")]
    Kuwait,
    [Description("Kyrgyzstan")]
    Kyrgyzstan,
    [Description("Laos")]
    Laos,
    [Description("Lebanon")]
    Lebanon,
    [Description("Lesotho")]
    Lesotho,
    [Description("Liberia")]
    Liberia,
    [Description("Libya")]
    Libya,
    [Description("Liechtenstein")]
    Liechtenstein,
    [Description("Madagascar")]
    Madagascar,
    [Description("Malawi")]
    Malawi,
    [Description("Malaysia")]
    Malaysia,
    [Description("Maldives")]
    Maldives,
    [Description("Mali")]
    Mali,
    [Description("MarshallIslands")]
    MarshallIslands,
    [Description("Mauritania")]
    Mauritania,
    [Description("Mauritius")]
    Mauritius,
    [Description("Mexico")]
    Mexico,
    [Description("Federated States of Micronesia")]
    FederatedStatesOfMicronesia,
    [Description("Moldova")]
    Moldova,
    [Description("Monaco")]
    Monaco,
    [Description("Mongolia")]
    Mongolia,
    [Description("Montenegro")]
    Montenegro,
    [Description("Morocco")]
    Morocco,
    [Description("Mozambique")]
    Mozambique,
    [Description("Myanmar")]
    Myanmar,
    [Description("Namibia")]
    Namibia,
    [Description("Nauru")]
    Nauru,
    [Description("Nepal")]
    Nepal,
    [Description("New Zealand")]
    NewZealand,
    [Description("Nicaragua")]
    Nicaragua,
    [Description("Niger")]
    Niger,
    [Description("Nigeria")]
    Nigeria,
    [Description("North Macedonia")]
    NorthMacedonia,
    [Description("Norway")]
    Norway,
    [Description("Oman")]
    Oman,
    [Description("Pakistan")]
    Pakistan,
    [Description("Palau")]
    Palau,
    [Description("Panama")]
    Panama,
    [Description("Papua New Guinea")]
    PapuaNewGuinea,
    [Description("Paraguay")]
    Paraguay,
    [Description("Peru")]
    Peru,
    [Description("Philippines")]
    Philippines,
    [Description("Qatar")]
    Qatar,
    [Description("Russia")]
    Russia,
    [Description("Rwanda")]
    Rwanda,
    [Description("Saint Kitts and Nevis")]
    SaintKittsAndNevis,
    [Description("Saint Lucia")]
    SaintLucia,
    [Description("Saint Vincent and the Grenadines")]
    SaintVincentAndTheGrenadines,
    [Description("")]
    Samoa,
    [Description("San Marino")]
    SanMarino,
    [Description("Sao Tome and Principe")]
    SaoTomeAndPrincipe,
    [Description("Saudi Arabia")]
    SaudiArabia,
    [Description("Senegal")]
    Senegal,
    [Description("Serbia")]
    Serbia,
    [Description("Seychelles")]
    Seychelles,
    [Description("Sierra Leone")]
    SierraLeone,
    [Description("Singapore")]
    Singapore,
    [Description("Solomon Islands")]
    SolomonIslands,
    [Description("Somalia")]
    Somalia,
    [Description("South Africa")]
    SouthAfrica,
    [Description("Sri Lanka")]
    SriLanka,
    [Description("Sudan")]
    Sudan,
    [Description("South Sudan")]
    SouthSudan,
    [Description("Suriname")]
    Suriname,
    [Description("Switzerland")]
    Switzerland,
    [Description("Syria")]
    Syria,
    [Description("Taiwan")]
    Taiwan,
    [Description("Tajikistan")]
    Tajikistan,
    [Description("Tanzania")]
    Tanzania,
    [Description("Thailand")]
    Thailand,
    [Description("Togo")]
    Togo,
    [Description("Tonga")]
    Tonga,
    [Description("Trinidad and Tobago")]
    TrinidadAndTobago,
    [Description("Tunisia")]
    Tunisia,
    [Description("Turkey")]
    Turkey,
    [Description("Turkmenistan")]
    Turkmenistan,
    [Description("Tuvalu")]
    Tuvalu,
    [Description("Uganda")]
    Uganda,
    [Description("Ukraine")]
    Ukraine,
    [Description("United Arab Emirates")]
    UnitedArabEmirates,
    [Description("United Kingdom")]
    UnitedKingdom,
    [Description("United States of 'murrica")]
    UnitedStates,
    [Description("Uruguay")]
    Uruguay,
    [Description("Uzbekistan")]
    Uzbekistan,
    [Description("Vanuatu")]
    Vanuatu,
    [Description("Vatican City")]
    VaticanCity,
    [Description("Venezuela")]
    Venezuela,
    [Description("Vietnam")]
    Vietnam,
    [Description("Yemen")]
    Yemen,
    [Description("Zambia")]
    Zambia,
    [Description("Zimbabwe")]
    Zimbabwe,
}
public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

        if (fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Length > 0)
        {
            return attributes[0].Description;
        }

        return value.ToString();
    }
}

