using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Spender.WinPhone.ViewModel;

namespace Spender.WinPhone.Views
{
	public partial class ManageCategoryView : PhoneApplicationPage
	{
		public ManageCategoryView()
		{
			InitializeComponent();
			this.Loaded += (sender, args) =>
			{
				//((ManageCategoryViewModel)DataContext).UpdateContext();
			};
		}

		private void ApplicationBarOkButton_Click(object sender, EventArgs e)
		{
			((ManageCategoryViewModel)DataContext).Save();
		}

		private void ApplicationBarCancelButton_OnClick(object sender, EventArgs e)
		{
			((ManageCategoryViewModel)DataContext).Cancel();
		}
	}
}