using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight.Command;
using Spender.WinPhone.DataService;
using Telerik.Windows.Controls;

namespace Spender.WinPhone.ViewModel
{
	public class CategoryImageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService = new NavigationService();

		public string ImageSource { get; set; }
		public RelayCommand ImageSelected
		{
			get
			{
				return new RelayCommand(() =>
					{
						StaticDataHolder.SelectedImage = ImageSource;
						_navigationService.GoBack();
					});
			}
		}
	}
}