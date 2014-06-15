using System;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Spender.WinPhone.Model;

namespace Spender.WinPhone.ViewModel
{
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// <para>
	/// See http://www.galasoft.ch/mvvm
	/// </para>
	/// </summary>
	public class MainViewModel : ViewModelBase
	{
		private INavigationService _navigationService = new NavigationService();


		private readonly IDataService _dataService;

		/// <summary>
		/// The <see cref="WelcomeTitle" /> property's name.
		/// </summary>
		public const string WelcomeTitlePropertyName = "WelcomeTitle";

		private string _welcomeTitle = string.Empty;

		/// <summary>
		/// Gets the WelcomeTitle property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public string WelcomeTitle
		{
			get
			{
				return _welcomeTitle;
			}

			set
			{
				if (_welcomeTitle == value)
				{
					return;
				}

				_welcomeTitle = value;
				RaisePropertyChanged(WelcomeTitlePropertyName);
			}
		}

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel(IDataService dataService)
		{
			_dataService = dataService;
			_dataService.GetData(
				(item, error) =>
				{
					if (error != null)
					{
						// Report error here
						return;
					}

					WelcomeTitle = item.Title;
				});
		}

		public RelayCommand LogInCommand
		{
			get
			{
				return new RelayCommand(() => _navigationService.NavigateTo("/Views/SignInView.xaml"));
			}
		}

		public RelayCommand HomeCommand { get { return new RelayCommand(Home); } }
		public RelayCommand ExpenseListCommand { get { return new RelayCommand(ExpenseList); } }

		private void Home()
		{
			_navigationService.NavigateTo("/Views/HomeView.xaml");
		}
		private void ExpenseList()
		{
			_navigationService.NavigateTo("/Views/ExpenseListView.xaml");
		}
	}
}