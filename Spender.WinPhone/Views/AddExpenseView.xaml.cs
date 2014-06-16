
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
using Microsoft.Phone.Controls;

namespace Spender.WinPhone.Views
{
	public partial class AddExpenseView : PhoneApplicationPage
	{
		public AddExpenseView()
		{
			InitializeComponent();
		}

		private void ApplicationBarIconButton_Click(object sender, EventArgs e)
		{
			this.DataForm.Commit();
		}

		private void btnNewPhoto_Tap(object sender, GestureEventArgs e)
		{

		}
	}
}
