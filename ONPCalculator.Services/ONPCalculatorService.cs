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
	public class ONPCalculatorService
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
			//OutputOperationList = new ObservableCollection<OutputOperation>();
			InternalStack<string> stack = new InternalStack<string>();
			List<string> tokenList = onpExpression.Trim().Split(' ').ToList();
			string input = onpExpression.Trim();
			//OutputOperationList.Add
			OutputOperationBuffer.Push(new OutputOperation()
			{
				Id = id++,
				Input = input,
				Stack = stack.ToList().ToReverseString(),
				Output = string.Empty
			});
			foreach (string token in tokenList)
			{
				if (!string.IsNullOrEmpty(input.Trim()))
					input = input.Trim().Remove(0, 1);

				if (token.IsOperator())
				{
					string secondToken = stack.Pop();
					string firstToken = stack.Pop();
					float firstValue = float.Parse(firstToken);
					float secondValue = float.Parse(secondToken);
					float result = Calculate(token, firstValue, secondValue);
					//OutputOperationList.Add
					OutputOperationBuffer.Push(new OutputOperation()
					{
						Id = id++,
						Input = input,
						Stack = stack.ToList().ToReverseString(),
						Output = string.Format("{0} {1} {2}", firstValue, token, secondValue)
					});
					stack.Push(result.ToString());
				}
				else
				{
					stack.Push(token);
					//OutputOperationList.Add
					OutputOperationBuffer.Push(new OutputOperation()
					{
						Id = id++,
						Input = input,
						Stack = stack.ToList().ToReverseString(),
						Output = string.Empty
					});
				}
			}

			string resultToken = stack.Pop();
			float resultValue = float.Parse(resultToken);
			return resultValue;
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
