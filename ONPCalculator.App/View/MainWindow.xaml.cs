﻿using ONPCalculator.App.ViewModel;
using ONPCalculator.Data.Entities;
using ONPCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ONPCalculator.App.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		public MainViewModel ViewModel
		{
			get
			{
				return (MainViewModel)DataContext;
			}
			set
			{
				DataContext = value;
			}
		}

        public MainWindow()
        {
			InitializeComponent();
			ViewModel = new MainViewModel();
        }
    }
}
