using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spender.WinPhone.ViewModels;
using Telerik.Windows.Controls;

namespace Spender.WinPhone.ViewModel
{
	public class ExpenseListItemViewModel : ViewModelBase
	{
		private ObservableCollection<ExpenseItemViewModel> items;
		private string title;
		private string information;

		public ExpenseListItemViewModel()
		{
			this.InitializeItems();
		}

		public ExpenseListItemViewModel(string title, string information = null)
		{
			this.title = title;
			this.information = information;
			this.InitializeItems();
		}

		/// <summary>
		/// Gets or sets the title of the collection.
		/// </summary>
		public string Title
		{
			get
			{
				return this.title;
			}
			set
			{
				if (this.title != value)
				{
					this.title = value;
					this.OnPropertyChanged("Title");
				}
			}
		}

		/// <summary>
		/// Gets or sets the information for the collection.
		/// </summary>
		public string TotalDescription
		{
			get
			{
				return string.Format("Total spend {0}", Total);
			}
		}

		public decimal Total { get; set; }

		/// <summary>
		/// A collection for <see cref="ExpenseItemViewModel"/> objects.
		/// </summary>
		public ObservableCollection<ExpenseItemViewModel> Items
		{
			get
			{
				return this.items;
			}
			set
			{
				this.items = value;
			}
		}

		/// <summary>
		/// Initializes the items.
		/// </summary>
		private void InitializeItems()
		{
			this.items = new ObservableCollection<ExpenseItemViewModel>();
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
