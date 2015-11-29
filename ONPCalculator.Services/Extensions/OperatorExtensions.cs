using ONPCalculator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ONPCalculator.Services.Extensions
{
    public static class OperatorExtensions
    {
		public static string ToReverseString(this List<Operator> operatorList)
		{
			string result = string.Empty;
			operatorList.Reverse();
			operatorList.ForEach(obj => result += obj.OperatorType + " ");
			return result;
		}

		public static string ToReverseString(this InternalStack<Operator> operatorStack)
		{
			string result = string.Empty;
			List<Operator> operatorList = operatorStack.ToList();
            operatorList.Reverse();
			operatorList.ForEach(obj => result += obj.OperatorType + " ");
			return result;
		}
	}
}
