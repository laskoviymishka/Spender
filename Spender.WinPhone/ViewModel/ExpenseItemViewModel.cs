using System;
using Telerik.Windows.Controls;

namespace Spender.WinPhone.ViewModels
{
	public class ExpenseItemViewModel : ViewModelBase
	{
		private string group;
		private Uri imageSource;
		private Uri imageThumbnailSource;
		private string information;
		private string title;

		/// <summary>
		///     Gets or sets the image source.
		/// </summary>
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

		/// <summary>
		///     Gets or sets the image thumbnail source.
		/// </summary>
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

		/// <summary>
		///     Gets or sets the title.
		/// </summary>
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

		/// <summary>
		///     Gets or sets the information.
		/// </summary>
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

		/// <summary>
		///     Gets or sets the group.
		/// </summary>
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

		/// <summary>
		///     Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		///     A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return title;
		}

		/// <summary>
		///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
		/// <returns>
		///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals(object obj)
		{
			var typedObject = obj as ExpenseItemViewModel;
			if (typedObject == null)
			{
				return false;
			}
			return Title == typedObject.Title && Information == typedObject.Information;
		}

		/// <summary>
		///     Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
		/// </returns>
		public override int GetHashCode()
		{
			return Title.GetHashCode() ^ Information.GetHashCode();
		}
	}
}