using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

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
    public static string TruncateOrPadStringTo(string? inputString, int maximumLength)
    {
        if (inputString == null) return new string(' ', maximumLength);
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

    public static string TruncateOrPadIntTo(int? inputNumber)
    {
        if (inputNumber == null) return "";
        string outPutString;

        int lengthOfInputNumber = inputNumber.ToString().Length;

        if (inputNumber > 999) outPutString = ">999";
        else if (lengthOfInputNumber == 1) outPutString = "   " + inputNumber.ToString();
        else if (lengthOfInputNumber == 2) outPutString = "  " + inputNumber.ToString();
        else outPutString = " " + inputNumber.ToString();

        return outPutString;
    }
}

