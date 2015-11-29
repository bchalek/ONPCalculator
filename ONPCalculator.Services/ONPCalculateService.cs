using ONPCalculator.Data.Dictionaries;
using ONPCalculator.Data.Entities;
using ONPCalculator.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ONPCalculator.Services
{
	public class ONPCalculateService
	{
		private InternalBuffer<OutputOperation> OutputOperationBuffer;
		public ObservableCollection<OutputOperation> OutputOperationList
		{
			get
			{
				ObservableCollection<OutputOperation> result = new ObservableCollection<OutputOperation>();
				while (OutputOperationBuffer != null && OutputOperationBuffer.Any())
				{
					result.Add(OutputOperationBuffer.Pop());
				}
				return result;
			}
		}

		public float CalculateONPExpresion(string onpExpression)
		{
			int id = 0;
			OutputOperationBuffer = new InternalBuffer<OutputOperation>();

			InternalStack<string> stack = new InternalStack<string>();

			List<string> tokenList = onpExpression.Trim().Split(' ').ToList();
			string input = onpExpression.Trim();

			OutputOperationBuffer.Push(new OutputOperation(id++, input, stack.ToReverseString(), string.Empty));

			foreach (string token in tokenList)
			{
				if (!string.IsNullOrEmpty(input.Trim()))
					input = input.Trim().Remove(0, 1);

				if (token.IsOperator())
				{
					string secondToken = stack.Pop();
					string firstToken = stack.Pop();
					string result = Calculate(token, firstToken, secondToken);

					OutputOperationBuffer.Push(new OutputOperation(id++, input, stack.ToReverseString(), string.Format("{0} {1} {2}", firstToken, token, secondToken)));

					stack.Push(result);

					OutputOperationBuffer.Push(new OutputOperation(id++, input, stack.ToReverseString(), string.Empty));
				}
				else
				{
					stack.Push(token);

					OutputOperationBuffer.Push(new OutputOperation(id++, input, stack.ToReverseString(), string.Empty));
				}
			}

			string resultToken = stack.Pop();
			float resultValue = float.Parse(resultToken);
			return resultValue;
		}

		private string Calculate(string operatorValue, string firstToken, string secondToken)
		{
			float firstValue;
			float secondValue;

			if (float.TryParse(firstToken, out firstValue)
				&& float.TryParse(secondToken, out secondValue))
				return Calculate(operatorValue, firstValue, secondValue).ToString();

			return string.Empty;
        }

		private float Calculate(string operatorValue, float firstValue, float secondValue)
		{
			switch (operatorValue[0])
			{
				case Operators.Addition:
					return firstValue + secondValue;
				case Operators.Subtraction:
					return firstValue - secondValue;
				case Operators.Multiplication:
					return firstValue * secondValue;
				case Operators.Division:
					return firstValue / secondValue;
				default:
					return 0;
			}

		}
	}
}
