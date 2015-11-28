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
	public class InfixONPConverter
	{
		private InternalBuffer<OutputOperation> OutputOperationBuffer;
		public ObservableCollection<OutputOperation> OutputOperationList
		{
			get
			{
				ObservableCollection<OutputOperation> result = new ObservableCollection<OutputOperation>();
				while(OutputOperationBuffer != null && OutputOperationBuffer.Any())
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
			//OutputOperationList = new ObservableCollection<OutputOperation>();
			InternalStack<Operator> stack = new InternalStack<Operator>();

			string output = string.Empty;
			char[] infixArray = infix.Trim().ToArray();
			string input = infix;
			//OutputOperationList.Add
			OutputOperationBuffer.Push(new OutputOperation()
			{
				Id = id++,
				Input = input,
				Stack = stack.ToList().ToReverseString(),
				Output = output
			});

			foreach (char infixChar in infixArray)
			{
				input = input.Remove(0, 1);
				if (!infixChar.IsOperator())
				{
					output = output.TrimEnd();
					output += " ";
					output += infixChar;
					//OutputOperationList.Add
					OutputOperationBuffer.Push(new OutputOperation()
					{
						Id = id++,
						Input = input,
						Stack = stack.ToList().ToReverseString(),
						Output = output
					});
				}
				else if (infixChar == Operators.OpenBracket)
				{
					output = output.TrimEnd();
					output += " ";
					Operator newOperator = new Operator(infixChar);
					stack.Push(newOperator);
					//OutputOperationList.Add
					OutputOperationBuffer.Push(new OutputOperation()
					{
						Id = id++,
						Input = input,
						Stack = stack.ToList().ToReverseString(),
						Output = output
					});
				}
				else if (infixChar == Operators.CloseBracket)
				{
					output = output.TrimEnd();
					output += " ";
					Operator newOperator = new Operator(infixChar);
					while (stack.Any() && stack.Peek().OperatorType != Operators.OpenBracket)
					{
						output = output.TrimEnd();
						output += " ";
						output += stack.Pop().OperatorType;
						//OutputOperationList.Add
						OutputOperationBuffer.Push(new OutputOperation()
						{
							Id = id++,
							Input = input,
							Stack = stack.ToList().ToReverseString(),
							Output = output
						});
					}
					stack.Pop();
					//OutputOperationList.Add
					OutputOperationBuffer.Push(new OutputOperation()
					{
						Id = id++,
						Input = input,
						Stack = stack.ToList().ToReverseString(),
						Output = output
					});
				}
				else
				{
					output = output.TrimEnd();
					output += " ";
					Operator newOperator = new Operator(infixChar);
					while (stack.Any() && stack.Peek().Priority >= newOperator.Priority)
					{
						output = output.TrimEnd();
						output += " ";
						output += stack.Pop().OperatorType;
					}
					stack.Push(newOperator);
					//OutputOperationList.Add
					OutputOperationBuffer.Push(new OutputOperation()
					{
						Id = id++,
						Input = input,
						Stack = stack.ToList().ToReverseString(),
						Output = output
					});
				}
			}
			while (stack.Any())
			{
				output = output.TrimEnd();
				output += " ";
				output += stack.Pop().OperatorType;
				//OutputOperationList.Add
				OutputOperationBuffer.Push(new OutputOperation()
				{
					Id = id++,
					Input = input,
					Stack = stack.ToList().ToReverseString(),
					Output = output
				});
			}

			return output;
		}
	}
}
