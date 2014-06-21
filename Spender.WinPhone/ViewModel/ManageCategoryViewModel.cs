using System;
using System.Linq;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Spender.Model.Entities;
using Spender.WinPhone.DataService;

namespace Spender.WinPhone.ViewModel
{
	public class ManageCategoryViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService = new NavigationService();
		private bool _isExpense;
		private bool _isIncome;
		private string _imageSource;
		private string _title;

		public ManageCategoryViewModel()
		{
			UpdateContext();
			_navigationService.Navigating +=_navigationService_Navigating;
		}

		private void _navigationService_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
		{
			ImageSource = StaticDataHolder.SelectedImage;
		}

		public void UpdateContext()
		{
			StaticDataHolder.SelectedImage = string.Empty;
			if (StaticDataHolder.SelectedCategory != null)
			{
				IsIncome = StaticDataHolder.SelectedCategory.Type == CategoryType.Income;
				IsExpense = StaticDataHolder.SelectedCategory.Type == CategoryType.Expense;
				Title = StaticDataHolder.SelectedCategory.Name;
				ImageSource = StaticDataHolder.SelectedCategory.Image;
			}
		}

		public bool IsExpense
		{
			get { return _isExpense; }
			set
			{
				if (_isExpense != value)
				{
					_isExpense = value;
					IsIncome = !_isExpense;
					RaisePropertyChanged("IsExpense");
				}
			}
		}
		public bool IsIncome
		{
			get { return _isIncome; }
			set
			{
				if (_isIncome != value)
				{
					_isIncome = value;
					IsExpense = !_isIncome;
					RaisePropertyChanged("IsIncome");
				}
			}
		}

		public string ImageSource
		{
			get { return _imageSource; }
			set
			{
				if (_imageSource != value)
				{
					_imageSource = value;
					RaisePropertyChanged("ImageSource");
				}
			}
		}
		public string Title
		{
			get { return _title; }
			set
			{
				if (_title != value)
				{
					_title = value;
					RaisePropertyChanged("Title");
				}
			}
		}

		public RelayCommand PickImage
		{
			get { return new RelayCommand(() => _navigationService.NavigateTo("/Views/CategoryImagePickerView.xaml")); }
		}

		internal void Save()
		{
			if (StaticDataHolder.SelectedCategory == null)
			{
				var item = new Category();
				item.Id = Guid.NewGuid().ToString();
				StaticDataHolder.Categories.Add(item);
				StaticDataHolder.SelectedCategory = item;
			}
			StaticDataHolder.Categories.First(c => c.Id == StaticDataHolder.SelectedCategory.Id).Image = ImageSource;
			StaticDataHolder.Categories.First(c => c.Id == StaticDataHolder.SelectedCategory.Id).Name = Title;
			if (IsIncome)
			{
				StaticDataHolder.Categories.First(c => c.Id == StaticDataHolder.SelectedCategory.Id).Type = CategoryType.Income;
			}
			else
			{
				StaticDataHolder.Categories.First(c => c.Id == StaticDataHolder.SelectedCategory.Id).Type = CategoryType.Expense;
			}

			_navigationService.GoBack();
		}

		internal void Cancel()
		{
			_navigationService.GoBack();
		}
	}
}
