using System;
using System.Collections.ObjectModel;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight.Command;
using Spender.WinPhone.DataService;
using Spender.WinPhone.DataService.Interfaces;
using Spender.WinPhone.ViewModel;
using Telerik.Windows.Controls;

namespace Spender.WinPhone.ViewModels
{
	public class ExpenseAgregateViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService = new NavigationService();
		private IExpenseService _expenseService;
		private ObservableCollection<ExpenseListViewModel> items;

		public ObservableCollection<ExpenseListViewModel> Items
		{
			get
			{
				if (items == null)
				{
					InitializeItems();
				}
				return items;
			}
			private set { items = value; }
		}


		public RelayCommand ManageCategory
		{
			get { return new RelayCommand(() => _navigationService.NavigateTo("/Views/ManageCategoryView.xaml")); }
		}

		public RelayCommand Settings
		{
			get { return new RelayCommand(() => _navigationService.NavigateTo("/Views/SettingsView.xaml")); }
		}

		private void InitializeItems()
		{
			_expenseService = new ExpenseService();
			items = new ObservableCollection<ExpenseListViewModel>(_expenseService.GenerateExpenseList());
		}

		public void AddExpense(object sender, EventArgs e)
		{
			_navigationService.NavigateTo("/Views/ManageExpenseView.xaml");
		}
	}
}