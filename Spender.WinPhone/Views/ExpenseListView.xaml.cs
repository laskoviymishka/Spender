using System;
using System.Windows.Controls;
using Cimbalino.Phone.Toolkit.Services;
using Microsoft.Phone.Controls;
using Telerik.Windows.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Spender.WinPhone.Views
{
	public partial class ExpenseListView : PhoneApplicationPage
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

		private void ApplicationBarIconButton_Click(object sender, EventArgs e)
		{
			new NavigationService().NavigateTo("/Views/AddExpenseView.xaml");
		}
	}
}