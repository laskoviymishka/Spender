using System.Collections.ObjectModel;
using Spender.WinPhone.ViewModels;
using Telerik.Windows.Controls;

namespace Spender.WinPhone.ViewModel
{
	public class ExpenseListItemViewModel : ViewModelBase
	{
		private string information;
		private ObservableCollection<ExpenseItemViewModel> items;
		private string title;

		public ExpenseListItemViewModel()
		{
			InitializeItems();
		}

		public ExpenseListItemViewModel(string title, string information = null)
		{
			this.title = title;
			this.information = information;
			InitializeItems();
		}

		/// <summary>
		///     Gets or sets the title of the collection.
		/// </summary>
		public string Title
		{
			get { return title; }
			set
			{
				if (title != value)
				{
					title = value;
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
		///     A collection for <see cref="ExpenseItemViewModel" /> objects.
		/// </summary>
		public ObservableCollection<ExpenseItemViewModel> Items
		{
			get { return items; }
			set { items = value; }
		}

		/// <summary>
		///     Initializes the items.
		/// </summary>
		private void InitializeItems()
		{
			items = new ObservableCollection<ExpenseItemViewModel>();
			//for (int i = 1; i <= 3; i++)
			//{
			//	this.items.Add(new ExpenseItemViewModel()
			//	{
			//		ImageSource = new Uri("Assets/Images/Frame.png", UriKind.RelativeOrAbsolute),
			//		ImageThumbnailSource = new Uri("Assets/Images/FrameThumbnail.png", UriKind.RelativeOrAbsolute),
			//		Title = "Title " + i,
			//		Information = "TotalDescription " + i,
			//		Group = (i % 2 == 0) ? "EVEN" : "ODD"
			//	});
			//}
		}
	}
}