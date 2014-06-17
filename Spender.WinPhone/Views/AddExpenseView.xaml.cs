using System;
using System.Windows.Input;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

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
			var task = new PhotoChooserTask();
			task.Completed += task_Completed;
			task.ShowCamera = true;
			task.PixelWidth = 1024;
			task.PixelHeight = 768;
			task.Show();
		}

		private void task_Completed(object sender, PhotoResult e)
		{
		}
	}
}