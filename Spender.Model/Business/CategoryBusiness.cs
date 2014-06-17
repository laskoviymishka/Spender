// // -----------------------------------------------------------------------
// // <copyright file="CategoryBusiness.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Spender.Model.Entities;
using Spender.Model.Repository;

namespace Spender.Model.Business
{
	#region Using

	

	#endregion

	public class CategoryBusiness : ICategoryBusiness
	{
		#region Private Fields

		private readonly IRepository<Category> _repository;

		#endregion

		#region Constructor

		public CategoryBusiness(IRepository<Category> repository)
		{
			_repository = repository;
		}

		#endregion

		#region ICategoryBusiness Implementation

		public Category GetCategoryById(string id)
		{
			return _repository.Query().FirstOrDefault(c => c.Id == id);
		}

		public IEnumerable<Category> GetUserCategories(ExpenseUser user, CategoryType categoryType)
		{
			return _repository.Query().Where(c => c.User.Id == user.Id && c.Type == categoryType);
		}

		public void SaveCategory(Category category)
		{
			if (!string.IsNullOrEmpty(category.Id) && GetCategoryById(category.Id) != null)
			{
				RemoveCategory(category);
			}

			_repository.Add(category);
		}

		public void RemoveCategory(Category category)
		{
			_repository.Remove(category);
		}

		#endregion

		public void AddDefaultCategoryList(ExpenseUser user)
		{
			var result = new List<Category>();
			result.Add(new Category
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Home Rent",
				Image = "Home Rent",
				Type = CategoryType.Expense,
				User = user
			});
			result.Add(new Category
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Utilities",
				Image = "Utilities",
				Type = CategoryType.Expense,
				User = user
			});
			result.Add(new Category
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Food",
				Image = "Food",
				Type = CategoryType.Expense,
				User = user
			});
			result.Add(new Category
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Entertaiment",
				Image = "Entertaiment",
				Type = CategoryType.Expense,
				User = user
			});
			result.Add(new Category
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Medical",
				Image = "Medical",
				Type = CategoryType.Expense,
				User = user
			});
			result.Add(new Category
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Transport",
				Image = "Transport",
				Type = CategoryType.Expense,
				User = user
			});
			result.Add(new Category
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Misc One-time",
				Image = "Misc One-time",
				Type = CategoryType.Expense,
				User = user
			});


			result.Add(new Category
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Salary",
				Image = "Salary",
				Type = CategoryType.Income,
				User = user
			});

			result.Add(new Category
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Other income",
				Image = "Other income",
				Type = CategoryType.Income,
				User = user
			});

			result.Add(new Category
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Gifts",
				Image = "Gifts",
				Type = CategoryType.Income,
				User = user
			});
			foreach (Category category in result)
			{
				_repository.Add(category);
			}
		}
	}
}