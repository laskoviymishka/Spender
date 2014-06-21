using System;
using System.Windows.Controls;
using Cimbalino.Phone.Toolkit.Services;
using Microsoft.Phone.Controls;
using Spender.Model.Entities;
using Spender.WinPhone.DataService;
using Spender.WinPhone.ViewModels;
using Telerik.Windows.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Spender.WinPhone.Views
{
	public partial class ExpenseListView : UserControl
	{
		public ExpenseListView()
		{
			InitializeComponent();
		}

		private void ExpandExpander(object sender, GestureEventArgs e)
		{
			var b = sender as HyperlinkButton;
			var expander = ElementTreeHelper.FindVisualAncestor<RadExpanderControl>(b);
			if (expander != null)
			{
				expander.IsExpanded = true;
			}
		}

		private void CollapseExpander(object sender, GestureEventArgs e)
		{
			var b = sender as HyperlinkButton;
			var expander = ElementTreeHelper.FindVisualAncestor<RadExpanderControl>(b);
			if (expander != null)
			{
				expander.IsExpanded = false;
			}
		}

		private void ExpenseItem_OnTap(object sender, GestureEventArgs e)
		{
			new NavigationService().NavigateTo("/Views/ExpenseDetailsView.Xaml");
		}

		private void RadDataBoundListBox_OnItemTap(object sender, ListBoxItemTapEventArgs e)
		{
			StaticDataHolder.SelectedExpense = e.Item.DataContext as ExpenseViewModel;
			new NavigationService().NavigateTo("/Views/ExpenseDetailsView.Xaml");
		}
	}
}