using System;
using Spender.Common.Entities;
using Telerik.Windows.Controls;

namespace Spender.WinPhone.ViewModels
{
	public class ExpenseViewModel : ViewModelBase
	{
		private string _note;
		private string group;
		private Uri imageSource;
		private Uri imageThumbnailSource;
		private string information;
		private string title;

		public Uri ImageSource
		{
			get { return imageSource; }
			set
			{
				if (imageSource != value)
				{
					imageSource = value;
					OnPropertyChanged("ImageSource");
				}
			}
		}

		public Uri ImageThumbnailSource
		{
			get { return imageThumbnailSource; }
			set
			{
				if (imageThumbnailSource != value)
				{
					imageThumbnailSource = value;
					OnPropertyChanged("ImageThumbnailSource");
				}
			}
		}

		public string Title
		{
			get { return title; }
			set
			{
				if (title != value)
				{
					title = value;
					OnPropertyChanged("Title");
				}
			}
		}

		public string Information
		{
			get { return information; }
			set
			{
				if (information != value)
				{
					information = value;
					OnPropertyChanged("TotalDescription");
				}
			}
		}

		public string Group
		{
			get { return @group; }
			set
			{
				if (@group != value)
				{
					@group = value;
					OnPropertyChanged("Group");
				}
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
					OnPropertyChanged("Note");
				}
			}
		}

		public string CheckImageSource { get; set; }
		public Location Location { get; set; }

		public override string ToString()
		{
			return title;
		}

		public override bool Equals(object obj)
		{
			var typedObject = obj as ExpenseViewModel;
			if (typedObject == null)
			{
				return false;
			}
			return Title == typedObject.Title && Information == typedObject.Information;
		}

		public override int GetHashCode()
		{
			return Title.GetHashCode() ^ Information.GetHashCode();
		}
	}
}