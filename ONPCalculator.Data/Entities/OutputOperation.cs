using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ONPCalculator.Data.Entities
{
	public class OutputOperation //: INotifyPropertyChanged
	{
		int id;
		public int Id {get;set;}
		//{ 
		//	get
		//	{
		//		return id;
		//	}
		//	set
		//	{
		//		id = value;
		//		OnPropertyChanged("Id");
		//	}
		//}

		string input;
		public string Input {get;set;}
		//{
		//	get
		//	{
		//		return input;
		//	}
		//	set
		//	{
		//		input = value;
		//		OnPropertyChanged("Input");
		//	}
		//}

		string stack;
		public string Stack {get;set;}
		//{
		//	get
		//	{
		//		return stack;
		//	}
		//	set
		//	{
		//		stack = value;
		//		OnPropertyChanged("Stack");
		//	}
		//}

		string output;
		public string Output { get; set; }
		//{
		//	get
		//	{
		//		return output;
		//	}
		//	set
		//	{
		//		output = value;
		//		OnPropertyChanged("Output");
		//	}
		//}


		//#region INotifyPropertyChanged Members

		//public event PropertyChangedEventHandler PropertyChanged;

		//void OnPropertyChanged(string propertyName)
		//{
		//	PropertyChangedEventHandler handler = this.PropertyChanged;
		//	if (handler != null)
		//		handler(this, new PropertyChangedEventArgs(propertyName));
		//}

		//#endregion INotifyPropertyChanged Members
	}
}
