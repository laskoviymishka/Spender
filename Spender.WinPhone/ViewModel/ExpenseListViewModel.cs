using System.Collections.ObjectModel;
using Cimbalino.Phone.Toolkit.Services;
using Spender.WinPhone.ViewModels;
using Telerik.Windows.Controls;

namespace Spender.WinPhone.ViewModel
{
	public class ExpenseListViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService = new NavigationService();
		private string _information;
		private ObservableCollection<ExpenseViewModel> _items;
		private string _title;


		public ExpenseListViewModel()
		{
			InitializeItems();
		}

		public ExpenseListViewModel(string title, string information = null)
		{
			_title = title;
			_information = information;
			InitializeItems();
		}

		/// <summary>
		///     Gets or sets the title of the collection.
		/// </summary>
		public string Title
		{
			get { return _title; }
			set
			{
				if (_title != value)
				{
					_title = value;
					OnPropertyChanged("Title");
				}
			}
		}

		/// <summary>
		///     Gets or sets the information for the collection.
		/// </summary>
		public string TotalDescription
		{
			get { return string.Format("Total spend {0}", Total); }
		}

		public decimal Total { get; set; }

		/// <summary>
		///     A collection for <see cref="ExpenseViewModel" /> objects.
		/// </summary>
		public ObservableCollection<ExpenseViewModel> Items
		{
			get { return _items; }
			set { _items = value; }
		}


		/// <summary>
		///     Initializes the items.
		/// </summary>
		private void InitializeItems()
		{
			_items = new ObservableCollection<ExpenseViewModel>();
		}
	}
}