using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Spender.WinPhone.ViewModel
{
	/// <summary>
	/// This class contains properties that a View can data bind to.
	/// <para>
	/// See http://www.galasoft.ch/mvvm
	/// </para>
	/// </summary>
	public class SignInViewModel : ViewModelBase
	{
		private INavigationService _navigationService = new NavigationService();

		/// <summary>
		/// Initializes a new instance of the SignInViewModel class.
		/// </summary>
		public SignInViewModel()
		{
		}

		public RelayCommand SignUp { get { return new RelayCommand(NavigateToSignUp); } }

		private void NavigateToSignUp()
		{
			_navigationService.NavigateTo("/Views/SignUpView.xaml");
		}
	}
}