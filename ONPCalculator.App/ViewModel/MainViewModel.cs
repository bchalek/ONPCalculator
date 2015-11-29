using GalaSoft.MvvmLight.Command;
using ONPCalculator.Data.Entities;
using ONPCalculator.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ONPCalculator.App.ViewModel
{
	public class MainViewModel : INotifyPropertyChanged
	{
		#region Fields

		string conversionInput;

		string conversionOutput;

		string calculationInput;

		string calculationOutput;

		InfixONPConvertService converter;

		ONPCalculateService calculator;

		#endregion Fields

		#region Public properties

		public ObservableCollection<OutputOperation> ConversionOperationList
		{
			get
			{
				return converter.OutputOperationList;
			}
		}

		public string ConversionInput
		{
			get
			{
				return conversionInput;
			}
			set
			{
				conversionInput = value;
				OnPropertyChanged("ConversionInput");
			}
		}

		public string ConversionOutput
		{
			get
			{
				return conversionOutput;
			}
			set
			{
				conversionOutput = value;
				OnPropertyChanged("ConversionOutput");
			}
		}

		public ObservableCollection<OutputOperation> CalculationOperationList
		{
			get
			{
				return calculator.OutputOperationList;
			}
		}

		public string CalculationInput
		{
			get
			{
				return calculationInput;
			}
			set
			{
				calculationInput = value;
				OnPropertyChanged("CalculationInput");
			}
		}

		public string CalculationOutput
		{
			get
			{
				return calculationOutput;
			}
			set
			{
				calculationOutput = value;
				OnPropertyChanged("CalculationOutput");
			}
		}

		#endregion Public properties

		#region Commands

		public ICommand ConversionCommand
		{
			get;
			internal set;
		}

		public ICommand CalculationCommand
		{
			get;
			internal set;
		}

		#endregion Commands

		#region Cstr

		public MainViewModel()
		{
			CreateCalculationCommand();
			CreateConversionCommand();
			ConversionInput = "3+4*2/(1-5)";
			converter = new InfixONPConvertService();
			calculator = new ONPCalculateService();
		}

		#endregion Cstr

		#region Private Methods

		private void CreateConversionCommand()
		{
			ConversionCommand = new RelayCommand(ConversionExecute, CanConversionExecute);
		}

		private void CreateCalculationCommand()
		{
			CalculationCommand = new RelayCommand(CalculationExecute, CanCalculationExecute);
		}

		private void ConversionExecute()
		{
			CalculationInput = ConversionOutput = converter.ConvertToONP(ConversionInput);
			OnPropertyChanged("ConversionOperationList");
		}

		private void CalculationExecute()
		{
			CalculationOutput = calculator.CalculateONPExpresion(CalculationInput).ToString();
			OnPropertyChanged("CalculationOperationList");
		}

		public bool CanConversionExecute()
		{
			return !string.IsNullOrEmpty(ConversionInput);
		}

		public bool CanCalculationExecute()
		{
			return !string.IsNullOrEmpty(CalculationInput);
		}

		#endregion Private Methods

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion INotifyPropertyChanged Members
	}
}
