
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls;
using Spender.WinPhone.DataService.Interfaces;
using Spender.WinPhone.DataService;
using Spender.WinPhone.ViewModel;
using GalaSoft.MvvmLight.Command;
using Cimbalino.Phone.Toolkit.Services;

namespace Spender.WinPhone.ViewModels
{
	public class ExpenseDateViewModel : ViewModelBase
	{
		private IExpenseService _expenseService;
		private ObservableCollection<ExpenseListItemViewModel> items;
		private INavigationService _navigationService = new NavigationService();

		/// <summary>
		/// Initializes the items.
		/// </summary>
		private void InitializeItems()
		{
			_expenseService = new ExpenseService();
			this.items = new ObservableCollection<ExpenseListItemViewModel>(_expenseService.GenerateExpenseList());
		}

		/// <summary>
		/// A collection for <see cref="ExpenseItemViewModel"/> objects.
		/// </summary>
		public ObservableCollection<ExpenseListItemViewModel> Items
		{
			get
			{
				if (this.items == null)
				{
					this.InitializeItems();
				}
				return this.items;
			}
			private set
			{
				this.items = value;
			}
		}

		public void AddExpense(object sender, EventArgs e)
		{
			_navigationService.NavigateTo("/Views/AddExpenseView.xaml");
		}


		public RelayCommand ManageCategory
		{
			get
			{
				return new RelayCommand(() => _navigationService.NavigateTo("/Views/ManageCategoryView.xaml"));
			}
		}

		public RelayCommand Settings
		{
			get
			{
				return new RelayCommand(() => _navigationService.NavigateTo("/Views/SettingsView.xaml"));
			}
		}
	}
}
