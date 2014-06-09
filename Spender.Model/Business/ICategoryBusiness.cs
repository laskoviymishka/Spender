// // -----------------------------------------------------------------------
// // <copyright file="ICategoryBusiness.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Spender.Model.Business
{
	#region Using

	using System.Collections.Generic;
	using Spender.Model.Entities;

	#endregion

	public interface ICategoryBusiness
	{
		Category GetCategoryById(string id);
		IEnumerable<Category> GetUserCategories(ExpenseUser user, CategoryType categoryType);
		void AddDefaultCategoryList(ExpenseUser user);
		void SaveCategory(Category category);
		void RemoveCategory(Category category);
	}
}