
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
using Microsoft.Phone.Shell;
using Spender.WinPhone.DataService;
using Spender.WinPhone.Views.ViewModels;
using Telerik.Windows.Controls;

namespace Spender.WinPhone.Views
{
	public partial class CategoryListView : PhoneApplicationPage
	{
		private readonly INavigationService _navigationService = new NavigationService();

		public CategoryListView()
		{
			InitializeComponent();
		}

		private void ApplicationBarIconButton_Click(object sender, EventArgs e)
		{
			this.DataBoundListBox.IsCheckModeActive ^= true;
		}

		private void DataBoundListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selected = DataBoundListBox.SelectedItem as CategoryViewModel;
			if (selected!= null)
			{
				StaticDataHolder.SelectedCategory = StaticDataHolder.Categories.First(c => c.Id == selected.Id);
				var btn = ApplicationBar.Buttons[1] as ApplicationBarIconButton;
				btn.IsEnabled = true;
				btn = ApplicationBar.Buttons[2] as ApplicationBarIconButton;
				btn.IsEnabled = true;
			}
			else
			{
				var btn = ApplicationBar.Buttons[1] as ApplicationBarIconButton;
				btn.IsEnabled = false;
				btn = ApplicationBar.Buttons[2] as ApplicationBarIconButton;
				btn.IsEnabled = false;
			}
		}

		private void DeleteButton_OnClick(object sender, EventArgs e)
		{
			((CategoryListViewModel) DataContext).DeleteCategory((CategoryViewModel) DataBoundListBox.SelectedItem);
		}

		private void NewCategory_OnClick(object sender, EventArgs e)
		{
			StaticDataHolder.SelectedCategory = null;
			_navigationService.NavigateTo("/Views/ManageCategoryView.xaml");
		}

		private void EditButton_OnClick(object sender, EventArgs e)
		{
			_navigationService.NavigateTo("/Views/ManageCategoryView.xaml");
		}
	}
}
