using System;
using System.Collections.ObjectModel;
using Spender.WinPhone.ViewModels;
using Telerik.Windows.Controls;

namespace Spender.WinPhone.Views.ViewModels
{
	public class MainDataViewModel : ViewModelBase
	{
		private ObservableCollection<ExpenseViewModel> items;

		public ObservableCollection<ExpenseViewModel> Items
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

		private void InitializeItems()
		{
			items = new ObservableCollection<ExpenseViewModel>();
			for (int i = 1; i <= 7; i++)
			{
				items.Add(new ExpenseViewModel
				{
					ImageSource = new Uri("Images/Frame.png", UriKind.RelativeOrAbsolute),
					ImageThumbnailSource = new Uri("Images/FrameThumbnail.png", UriKind.RelativeOrAbsolute),
					Title = "Title " + i,
					Information = "Information " + i,
					Group = (i%2 == 0) ? "EVEN" : "ODD"
				});
			}
		}
	}
}