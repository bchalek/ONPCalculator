using ONPCalculator.Data.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ONPCalculator.Data.Entities
{
    public class Operator
    {
        public char OperatorType { get; set; }
        public int Priority { get; set; }

        public Operator(char operatorType)
        {
            OperatorType = operatorType;
            switch (OperatorType)
            {
                case Operators.Addition:
                    Priority = 2;
                    break;
                case Operators.Subtraction:
                    Priority = 2;
                    break;
                case Operators.Multiplication:
                    Priority = 3;
                    break;
                case Operators.Division:
                    Priority = 3;
                    break;
                case Operators.OpenBracket:
                    Priority = 1;
                    break;
                case Operators.CloseBracket:
                    Priority = 2;
                    break;
                default: 
                    Priority = 0;
                    break;
            }
        }

        public Operator(string operatorType)
        {
            OperatorType = operatorType[0];
            switch (OperatorType)
            {
                case Operators.Addition:
                    Priority = 1;
                    break;
                case Operators.Subtraction:
                    Priority = 2;
                    break;
                case Operators.Multiplication:
                    Priority = 3;
                    break;
                case Operators.Division:
                    Priority = 3;
                    break;
                case Operators.OpenBracket:
                    Priority = 1;
                    break;
                case Operators.CloseBracket:
                    Priority = 2;
                    break;
                default:
                    Priority = 0;
                    break;
            }
        }
    }
}
