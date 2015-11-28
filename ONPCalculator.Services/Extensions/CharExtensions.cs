using ONPCalculator.Data.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ONPCalculator.Services.Extensions
{
    public static class CharExtensions
    {
        public static bool IsOperator(this char character)
        {
            switch (character)
            {
                case Operators.Addition:
                case Operators.Subtraction:
                case Operators.Multiplication:
                case Operators.Division:
                case Operators.OpenBracket:
                case Operators.CloseBracket:
                    return true;
                default:
                    return false;
            }
        }
    }
}
