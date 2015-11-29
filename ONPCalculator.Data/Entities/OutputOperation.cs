using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ONPCalculator.Data.Entities
{
	public class OutputOperation
	{
		public int Id {get;set;}

		public string Input {get;set;}

		public string Stack {get;set;}

		public string Output { get; set; }

	}
}
