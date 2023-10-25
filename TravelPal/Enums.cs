using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal;

public enum EUCountries
{
    Austria,
    Belgium,
    Bulgaria,
    Croatia,
    [Description("Republic of Cyprus")]
    RepublicOfCyprus,
    [Description("Czech Republic")]
    CzechRepublic,
    Denmark,
    Estonia,
    Finland,
    France,
    Germany,
    Greece,
    Hungary,
    Ireland,
    Italy,
    Latvia,
    Lithuania,
    Luxembourg,
    Malta,
    Netherlands,
    Poland,
    Portugal,
    Romania,
    Slovakia,
    Slovenia,
    Spain,
    Sweden

}

public enum NonEUcountries
{
    //according to https://www.britannica.com/topic/list-of-countries-1993160
    //this was taken from a list of ALL countries
    // I tried my best to remove all the contries that are EU countries, based on the EUCountries
    //There might be some countries that I didnt get
    Afghanistan,
    Albania,
    Algeria,
    Andorra,
    Angola,
    [Description("Antigua and Barbuda")]
    AntiguaAndBarbuda,
    Argentina,
    Armenia,
    Australia,
    Azerbaijan,
    TheBahamas,
    Bahrain,
    Bangladesh,
    Barbados,
    Belarus,
    Belize,
    Benin,
    Bhutan,
    Bolivia,
    [Description("Bosnia and Herzegovina")]
    BosniaAndHerzegovina,
    Botswana,
    Brazil,
    Brunei,
    [Description("Burkina Faso")]
    BurkinaFaso,
    Burundi,
    [Description("Cabo Verde")]
    CaboVerde,
    Cambodia,
    Cameroon,
    Canada,
    [Description("CentralAfricanRepublic")]
    CentralAfricanRepublic,
    Chad,
    Chile,
    China,
    Colombia,
    Comoros,
    [Description("Democratic Republic of the Congo")]
    DemocraticRepublicOfTheCongo,
    [Description("Republic of the Congo")]
    RepublicOfTheCongo,
    [Description("Costa Rica")]
    CostaRica,
    Cuba,
    Djibouti,
    Dominica,
    [Description("Dominican Republic")]
    DominicanRepublic,
    [Description("East Timor")]
    EastTimor,
    Ecuador,
    Egypt,
    [Description("El Salvador")]
    ElSalvador,
    [Description("Equatorial Guinea")]
    EquatorialGuinea,
    Eritrea,
    Eswatini,
    Ethiopia,
    Fiji,
    Gabon,
    Gambia,
    Georgia,
    Ghana,
    Grenada,
    Guatemala,
    Guinea,
    [Description("Guinea Bissau")]
    GuineaBissau,
    Guyana,
    Haiti,
    Honduras,
    Iceland,
    India,
    Indonesia,
    Iran,
    Iraq,
    Israel,
    Jamaica,
    Japan,
    Jordan,
    Kazakhstan,
    Kenya,
    Kiribati,
    [Description("Korea North")]
    KoreaNorth,
    [Description("Korea South")]
    KoreaSouth,
    Kosovo,
    Kuwait,
    Kyrgyzstan,
    Laos,
    Lebanon,
    Lesotho,
    Liberia,
    Libya,
    Liechtenstein,
    Madagascar,
    Malawi,
    Malaysia,
    Maldives,
    Mali,
    MarshallIslands,
    Mauritania,
    Mauritius,
    Mexico,
    [Description("Federated States of Micronesia")]
    FederatedStatesOfMicronesia,
    Moldova,
    Monaco,
    Mongolia,
    Montenegro,
    Morocco,
    Mozambique,
    Myanmar,
    Namibia,
    Nauru,
    Nepal,
    [Description("New Zealand")]
    NewZealand,
    Nicaragua,
    Niger,
    Nigeria,
    [Description("North Macedonia")]
    NorthMacedonia,
    Norway,
    Oman,
    Pakistan,
    Palau,
    Panama,
    [Description("Papua New Guinea")]
    PapuaNewGuinea,
    Paraguay,
    Peru,
    Philippines,
    Qatar,
    Russia,
    Rwanda,
    [Description("Saint Kitts and Nevis")]
    SaintKittsAndNevis,
    [Description("Saint Lucia")]
    SaintLucia,
    [Description("Saint Vincent and the Grenadines")]
    SaintVincentAndTheGrenadines,
    Samoa,
    [Description("San Marino")]
    SanMarino,
    [Description("Sao Tome and Principe")]
    SaoTomeAndPrincipe,
    [Description("Saudi Arabia")]
    SaudiArabia,
    Senegal,
    Serbia,
    Seychelles,
    [Description("Sierra Leone")]
    SierraLeone,
    Singapore,
    [Description("Solomon Islands")]
    SolomonIslands,
    Somalia,
    [Description("South Africa")]
    SouthAfrica,
    [Description("Sri Lanka")]
    SriLanka,
    Sudan,
    [Description("South Sudan")]
    SouthSudan,
    Suriname,
    Switzerland,
    Syria,
    Taiwan,
    Tajikistan,
    Tanzania,
    Thailand,
    Togo,
    Tonga,
    [Description("Trinidad and Tobago")]
    TrinidadAndTobago,
    Tunisia,
    Turkey,
    Turkmenistan,
    Tuvalu,
    Uganda,
    Ukraine,
    [Description("United Arab Emirates")]
    UnitedArabEmirates,
    [Description("United Kingdom")]
    UnitedKingdom,
    [Description("United States of 'murrica")]
    UnitedStates,
    Uruguay,
    Uzbekistan,
    Vanuatu,
    [Description("Vatican City")]
    VaticanCity,
    Venezuela,
    Vietnam,
    Yemen,
    Zambia,
    Zimbabwe,
}

