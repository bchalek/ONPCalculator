using ONPCalculator.Data.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ONPCalculator.Services.Extensions
{
    public static class StringExtensions
    {
        public static bool IsOperator(this string operatorString)
        {
            if (operatorString.Length == 1)
                return operatorString[0].IsOperator();
            else
                return false;
        }

        public static string ToReverseString(this List<string> stringList)
        {
            string result = string.Empty;
            stringList.Reverse();
            stringList.ForEach(obj => result += obj + " ");
            return result;
        }
    }
}
