using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ONPCalculator.Data.Entities
{
	public class InternalBuffer<T>
	{
		private List<T> buffer;

		public int Count
		{
			get
			{
				return buffer.Count;
			}
		}

		public InternalBuffer()
		{
			buffer = new List<T>();
		}

		public bool Any(Func<T, bool> predicate = null)
		{
			if(predicate!=null)
				return buffer.Any(predicate);
			return buffer.Any();
		}

		public List<T> ToList()
		{
			return buffer.ToList();
		}

		public void Push(T obj)
		{
			buffer.Add(obj);
		}
		
		public T Pop()
		{
			T obj = Peek();
			buffer.Remove(obj);

			return obj;
		}

		public T Peek()
		{
			T obj = buffer.FirstOrDefault();

			return obj;
		}
	}
}
