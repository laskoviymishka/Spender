using System;
using Telerik.Windows.Controls;

namespace Spender.WinPhone.Views.ViewModels
{
	public class CategoryViewModel : ViewModelBase
	{
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
					OnPropertyChanged("Information");
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

		public string Id { get; set; }
		public override string ToString()
		{
			return title;
		}

		public override bool Equals(object obj)
		{
			var typedObject = obj as DataItemViewModel;
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