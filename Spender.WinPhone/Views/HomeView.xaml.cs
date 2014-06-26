using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using NavigationService = Cimbalino.Phone.Toolkit.Services.NavigationService;

namespace Spender.WinPhone.Views
{
	public partial class HomeView : PhoneApplicationPage
	{
		public HomeView()
		{
			InitializeComponent();
		}

		private void CategoryMenuItem_OnClick(object sender, EventArgs e)
		{
			new NavigationService().NavigateTo("/Views/CategoryListView.Xaml");
		}

		private void ApplicationBarIconButton_Click(object sender, EventArgs e)
		{
			new NavigationService().NavigateTo("/Views/ManageExpenseView.xaml");
		}
	}
}