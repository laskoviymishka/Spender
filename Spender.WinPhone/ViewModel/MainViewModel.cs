using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Spender.WinPhone.ViewModel
{
	public class MainViewModel : ViewModelBase
	{
		public RelayCommand ExpenseListCommand
		{
			get { return new RelayCommand(() => new NavigationService().NavigateTo("/Views/ExpenseListView.xaml")); }
		}

		public RelayCommand HomeCommand
		{
			get { return new RelayCommand(() => new NavigationService().NavigateTo("/Views/HomeView.xaml")); }
		}

		public RelayCommand LogInCommand
		{
			get { return new RelayCommand(() => new NavigationService().NavigateTo("/Views/LogInView.xaml")); }
		}
	}
}