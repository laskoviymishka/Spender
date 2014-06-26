using System;
using System.Collections.ObjectModel;
using Spender.Model.Entities;
using Spender.WinPhone.DataService;
using Telerik.Windows.Controls;

namespace Spender.WinPhone.Views.ViewModels
{
	public class CategoryListViewModel : ViewModelBase
	{
		private ObservableCollection<CategoryViewModel> items;

		public ObservableCollection<CategoryViewModel> Items
		{
			get
			{
				if (items == null)
				{
					InitializeItems();
				}
				return items;
			}
			private set { items = value; }
		}

		public void DeleteCategory(CategoryViewModel category)
		{
			StaticDataHolder.Categories.RemoveAll(c => c.Id == category.Id);
			InitializeItems();
		}

		public void AddCategory(CategoryViewModel category)
		{
			StaticDataHolder.Categories.Add(new Category
			{
				Id = category.Id,
				Image = category.ImageSource.AbsoluteUri,
				Name = category.Title,
				Type = CategoryType.Expense,
				User = StaticDataHolder.User
			});

			InitializeItems();
		}

		private void InitializeItems()
		{
			items = new ObservableCollection<CategoryViewModel>();
			foreach (var cat in StaticDataHolder.Categories)
			{
				items.Add(new CategoryViewModel
				{
					Id = cat.Id,
					ImageSource = new Uri(cat.Image, UriKind.Relative),
					Title = cat.Name,
				});
			}
		}
	}
}