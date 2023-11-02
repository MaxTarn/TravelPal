using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Classes;

public static class Utility
{
    /// <summary>
    /// Returns a string with the given length, given string has either been padded with whitespaces
    /// or cut(from the right) to given length-3 and then added "..." at the end
    /// </summary>
    /// <param name="inputString"></param>
    /// <param name="maximumLength"></param>
    /// <returns></returns>
    public static string TruncateOrPadTo(string? inputString, int maximumLength)
    {
        if (inputString == null) return "";
        if (maximumLength <= 0) return "";

        inputString = inputString.Trim();
        string outPutString;

        if (inputString.Length > maximumLength)
        {
            outPutString = inputString.Substring(0, maximumLength - 3);
            outPutString += "...";
            return outPutString;
        }
        outPutString = inputString.PadRight(maximumLength);
        return outPutString;


    }
}

