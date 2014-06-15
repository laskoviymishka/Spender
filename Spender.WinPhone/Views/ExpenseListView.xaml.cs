
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Cimbalino.Phone.Toolkit.Services;
using Microsoft.Phone.Controls;
using Telerik.Windows.Controls;

namespace Spender.WinPhone.Views
{
	public partial class ExpenseListView : PhoneApplicationPage
	{
		public ExpenseListView()
		{
			InitializeComponent();
		}

		private void ExpandExpander(object sender, System.Windows.Input.GestureEventArgs e)
		{
			HyperlinkButton b = sender as HyperlinkButton;
			RadExpanderControl expander = ElementTreeHelper.FindVisualAncestor<RadExpanderControl>(b);
			if (expander != null)
			{
				expander.IsExpanded = true;
			}
		}

		private void CollapseExpander(object sender, System.Windows.Input.GestureEventArgs e)
		{
			HyperlinkButton b = sender as HyperlinkButton;
			RadExpanderControl expander = ElementTreeHelper.FindVisualAncestor<RadExpanderControl>(b);
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
