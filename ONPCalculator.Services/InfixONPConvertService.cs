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
	public class InfixONPConvertService
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

		public string ConvertToONP(string infix)
		{
			int id = 0;
			OutputOperationBuffer = new InternalBuffer<OutputOperation>();
			InternalStack<Operator> stack = new InternalStack<Operator>();

			string output = string.Empty;
			char[] infixArray = infix.Trim().ToArray();
			string input = infix;
			OutputOperationBuffer.Push(new OutputOperation(id++, input, stack.ToReverseString(), output));

			foreach (char infixChar in infixArray)
			{
				if(!string.IsNullOrEmpty(input))
					input = input.Remove(0, 1);

				if (!infixChar.IsOperator())
				{
					AddToOutput(ref output, infixChar);

					OutputOperationBuffer.Push(new OutputOperation(id++, input, stack.ToReverseString(), output));
				}
				else if (infixChar == Operators.OpenBracket)
				{
					AddToOutput(ref output);

					Operator newOperator = new Operator(infixChar);
					stack.Push(newOperator);

					OutputOperationBuffer.Push(new OutputOperation(id++, input, stack.ToReverseString(), output));
				}
				else if (infixChar == Operators.CloseBracket)
				{
					AddToOutput(ref output);

					Operator newOperator = new Operator(infixChar);
					while (stack.Any() && stack.Peek().OperatorType != Operators.OpenBracket)
					{
						AddToOutput(ref output, stack.Pop());
						OutputOperationBuffer.Push(new OutputOperation(id++, input, stack.ToReverseString(), output));
					}
					stack.Pop();

					OutputOperationBuffer.Push(new OutputOperation(id++, input, stack.ToReverseString(), output));
				}
				else
				{
					AddToOutput(ref output);

					Operator newOperator = new Operator(infixChar);
					while (stack.Any() && stack.Peek().Priority >= newOperator.Priority)
					{
						AddToOutput(ref output, stack.Pop());
					}
					stack.Push(newOperator);

					OutputOperationBuffer.Push(new OutputOperation(id++, input, stack.ToReverseString(), output));
				}
			}
			while (stack.Any())
			{
				AddToOutput(ref output, stack.Pop());
			}

			return output;
		}

		private void AddToOutput(ref string _output, Operator _operator = null)
		{
			_output = _output.TrimEnd();
			_output += " ";
			if (_operator != null)
				_output += _operator.OperatorType;
		}

		private void AddToOutput(ref string _output, char _character)
		{
			_output = _output.TrimEnd();
			_output += " ";
			_output += _character;
		}
	}
}
