using ONPCalculator.Data.Dictionaries;
using ONPCalculator.Data.Entities;
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

		public static string ToReverseString(this InternalStack<string> stringStack)
		{
			string result = string.Empty;
			List<string> stringList = stringStack.ToList();
			stringList.Reverse();
			stringList.ForEach(obj => result += obj + " ");
			return result;
		}
	}
}
