using System;
using System.Windows.Input;
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
			DataForm.Commit();
		}

		private void btnNewPhoto_Tap(object sender, GestureEventArgs e)
		{
		}
	}
}