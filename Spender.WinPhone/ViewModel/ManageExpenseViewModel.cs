using System;
using System.Collections.Generic;
using System.Linq;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Spender.Common.Entities;
using Spender.Model.Entities;
using Spender.WinPhone.DataService;

namespace Spender.WinPhone.ViewModel
{
	public class ManageExpenseViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService = new NavigationService();
		private string _note =string.Empty;
		private string _name = string.Empty;
		private string _imageSource = string.Empty;
		private DateTime _date = new DateTime();
		private Location _location = new Location();
		private Category _category = new Category();
		private decimal _amount;

		public ManageExpenseViewModel()
		{
			if (StaticDataHolder.SelectedExpense != null)
			{
				Note = StaticDataHolder.SelectedExpense.Note;
				Name = StaticDataHolder.SelectedExpense.Name;
				ImageSource = StaticDataHolder.SelectedExpense.Image;
				Date = StaticDataHolder.SelectedExpense.Date;
				Location = StaticDataHolder.SelectedExpense.Location;
				Category = StaticDataHolder.SelectedExpense.Category;
				Amount = StaticDataHolder.SelectedExpense.Amount;
			}
		}

		public string Note
		{
			get { return _note; }
			set
			{
				if (_note != value)
				{
					_note = value;
					RaisePropertyChanged("Note");
				}
			}
		}

		public string Name
		{
			get { return _name; }
			set
			{
				if (_name != value)
				{
					_name = value;
					RaisePropertyChanged("Name");
				}
			}
		}

		public decimal Amount
		{
			get { return _amount; }
			set
			{
				if (_amount != value)
				{
					_amount = value;
					RaisePropertyChanged("Amount");
				}
			}
		}

		public Category Category
		{
			get { return _category; }
			set
			{
				if (_category != value)
				{
					_category = value;
					RaisePropertyChanged("Category");
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

		public DateTime Date
		{
			get { return _date; }
			set
			{
				if (_date != value)
				{
					_date = value;
					RaisePropertyChanged("Date");
				}
			}
		}

		public Location Location
		{
			get { return _location; }
			set
			{
				if (_location != value)
				{
					_location = value;
					RaisePropertyChanged("Location");
				}
			}
		}

		public List<Category> Categories { get { return StaticDataHolder.Categories; } } 
	}
}