using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ONPCalculator.Data.Entities
{
	public class InternalStack<T>
	{
		private List<T> stack;

		public int Count
		{
			get
			{
				return stack.Count;
			}
		}

		public InternalStack()
		{
			stack = new List<T>();
		}

		public bool Any(Func<T, bool> predicate = null)
		{
			if(predicate!=null)
				return stack.Any(predicate);
			return stack.Any();
		}

		public List<T> ToList()
		{
			return stack.ToList();
		}

		public void Push(T obj)
		{
			stack.Add(obj);
		}
		
		public T Pop()
		{
			T obj = Peek();
			stack.Remove(obj);

			return obj;
		}

		public T Peek()
		{
			T obj = stack.LastOrDefault();

			return obj;
		}
	}
}
