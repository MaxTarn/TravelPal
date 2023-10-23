﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal;

internal enum EUCountries
{
    Austria,
    Belgium,
    Bulgaria,
    Croatia,
    RepublicOfCyprus,
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

internal enum NonEUcountries
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
    BosniaAndHerzegovina,
    Botswana,
    Brazil,
    Brunei,
    BurkinaFaso,
    Burundi,
    CaboVerde,
    Cambodia,
    Cameroon,
    Canada,
    CentralAfricanRepublic,
    Chad,
    Chile,
    China,
    Colombia,
    Comoros,
    DemocraticRepublicOfTheCongo,
    RepublicOfTheCongo,
    CostaRica,
    Cuba,
    Djibouti,
    Dominica,
    DominicanRepublic,
    EastTimor,
    Ecuador,
    Egypt,
    ElSalvador,
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
    KoreaNorth,
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
    NewZealand,
    Nicaragua,
    Niger,
    Nigeria,
    NorthMacedonia,
    Norway,
    Oman,
    Pakistan,
    Palau,
    Panama,
    PapuaNewGuinea,
    Paraguay,
    Peru,
    Philippines,
    Qatar,
    Russia,
    Rwanda,
    SaintKittsAndNevis,
    SaintLucia,
    SaintVincentAndTheGrenadines,
    Samoa,
    SanMarino,
    SaoTomeAndPrincipe,
    SaudiArabia,
    Senegal,
    Serbia,
    Seychelles,
    SierraLeone,
    Singapore,
    SolomonIslands,
    Somalia,
    SouthAfrica,
    Sri, Lanka,
    Sudan,
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
    TrinidadAndTobago,
    Tunisia,
    Turkey,
    Turkmenistan,
    Tuvalu,
    Uganda,
    Ukraine,
    UnitedArabEmirates,
    UnitedKingdom,
    UnitedStates,
    Uruguay,
    Uzbekistan,
    Vanuatu,
    VaticanCity,
    Venezuela,
    Vietnam,
    Yemen,
    Zambia,
    Zimbabwe,
}
