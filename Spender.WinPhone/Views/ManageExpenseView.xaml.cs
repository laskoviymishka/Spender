using System;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Windows.Storage;
using Cimbalino.Phone.Toolkit.Services;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Spender.Model.Entities;
using Spender.WinPhone.DataService;
using Spender.WinPhone.Views.Models;

namespace Spender.WinPhone.Views
{
	public partial class ManageExpenseView : PhoneApplicationPage
	{
		private readonly INavigationService _navigationService = new NavigationService();
		private Stream _photoStream;
		private string fileName;

		public ManageExpenseView()
		{
			InitializeComponent();
		}

		private void ApplicationBarOkButton_Click(object sender, EventArgs e)
		{
			//DataForm.Commit();
			var currentItem = new ExpenseFormDataModel();//(ExpenseFormDataModel)DataForm.CurrentItem;
			var expnse = new Expense
			{
				Image = fileName,
				Name = currentItem.Name,
				Category = StaticDataHolder.Categories.FirstOrDefault(c => c.Name == currentItem.Category),
				Date = currentItem.Date != null ? currentItem.Date.Value : DateTime.Now,
				User = StaticDataHolder.User,
				Amount = currentItem.Amount,
				Note = currentItem.Note
			};
			StaticDataHolder.Expenses.Add(expnse);
			_navigationService.GoBack();
		}

		private void btnNewPhoto_Tap(object sender, Object e)
		{
			var task = new PhotoChooserTask();
			task.Completed += task_Completed;
			task.ShowCamera = true;
			task.Show();
		}

		private async void task_Completed(object sender, PhotoResult e)
		{
			_photoStream = e.ChosenPhoto;
			if (_photoStream != null)
			{
				fileName = Guid.NewGuid().ToString() + ".jpg";
				StorageFolder localFolder = ApplicationData.Current.LocalFolder;
				StorageFile storageFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
				using (Stream outputStream = await storageFile.OpenStreamForWriteAsync())
				{
					await _photoStream.CopyToAsync(outputStream);
				}
			}
		}

		private void ApplicationBarCancelButton_OnClick(object sender, EventArgs e)
		{
			_navigationService.GoBack();
		}
	}
}