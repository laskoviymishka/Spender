using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Spender.WinPhone.ViewModel
{
	/// <summary>
	///     This class contains properties that the main View can data bind to.
	///     <para>
	///         Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
	///     </para>
	///     <para>
	///         You can also use Blend to data bind with the tool's support.
	///     </para>
	///     <para>
	///         See http://www.galasoft.ch/mvvm
	///     </para>
	/// </summary>
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