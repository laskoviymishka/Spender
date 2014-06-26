
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cimbalino.Phone.Toolkit.Services;
using Microsoft.Phone.Controls;
using Spender.WinPhone.DataService;
using NavigationService = Cimbalino.Phone.Toolkit.Services.NavigationService;

namespace Spender.WinPhone.Views
{
	public partial class ExpenseDetailsView : PhoneApplicationPage
	{
		private readonly INavigationService _navigationService = new NavigationService();

		public ExpenseDetailsView()
		{
			this.Loaded += OnLoaded;
			InitializeComponent();
		}

		private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
		{
			DataContext = StaticDataHolder.SelectedExpenseViewModel;
		}

		private void Option1_Tap(object sender, Object e)
		{
			this.NoteViewer.Visibility = System.Windows.Visibility.Visible;
			this.Option1Arrow.Visibility = System.Windows.Visibility.Visible;
			this.CheckImageViewer.Visibility = System.Windows.Visibility.Collapsed;
			this.Option2Arrow.Visibility = System.Windows.Visibility.Collapsed;
			this.LocationViewer.Visibility = System.Windows.Visibility.Collapsed;
			this.Option3Arrow.Visibility = System.Windows.Visibility.Collapsed;
		}

		private void Option2_Tap(object sender, Object e)
		{
			this.NoteViewer.Visibility = System.Windows.Visibility.Collapsed;
			this.Option1Arrow.Visibility = System.Windows.Visibility.Collapsed;
			this.CheckImageViewer.Visibility = System.Windows.Visibility.Visible;
			this.Option2Arrow.Visibility = System.Windows.Visibility.Visible;
			this.LocationViewer.Visibility = System.Windows.Visibility.Collapsed;
			this.Option3Arrow.Visibility = System.Windows.Visibility.Collapsed;
		}

		private void Option3_Tap(object sender, Object e)
		{
			this.NoteViewer.Visibility = System.Windows.Visibility.Collapsed;
			this.Option1Arrow.Visibility = System.Windows.Visibility.Collapsed;
			this.CheckImageViewer.Visibility = System.Windows.Visibility.Collapsed;
			this.Option2Arrow.Visibility = System.Windows.Visibility.Collapsed;
			this.LocationViewer.Visibility = System.Windows.Visibility.Visible;
			this.Option3Arrow.Visibility = System.Windows.Visibility.Visible;
		}
	}
}
