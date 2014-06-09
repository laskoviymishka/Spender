// // -----------------------------------------------------------------------
// // <copyright file="CategoryBusinessTests.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Spender.Tests.Business
{
	#region Using

	using System.Collections.Generic;
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;
	using Spender.Model.Business;
	using Spender.Model.Entities;
	using Spender.Model.Repository;

	#endregion

	[TestClass]
	public class CategoryBusinessTests
	{
		#region Private Fields

		private readonly IList<Category> _Categorys = new List<Category>();
		private readonly IList<Category> _copyCategorys = new List<Category>();
		private ICategoryBusiness _CategoryBusiness;
		private Category _firstCategory;
		private Mock<IRepository<Category>> _mockRepository;
		private Category _secondCategory;
		private ExpenseUser _user;

		#endregion

		#region Tests Initialization

		[TestInitialize]
		public void Init()
		{
			_firstCategory = new Category { Id = "1", Name = "Test", Type = CategoryType.Expense };
			_secondCategory = new Category { Id = "2", Name = "Test2", Type = CategoryType.Income };
			_user = new ExpenseUser { Id = "1" };
			_mockRepository = new Mock<IRepository<Category>>();
			_mockRepository.Setup(m => m.Add(It.IsAny<Category>())).Callback<Category>(b => _Categorys.Add(b));
			_mockRepository.Setup(m => m.Remove(It.IsAny<Category>())).Callback<Category>(b => _Categorys.Remove(b));
			_mockRepository.Setup(m => m.Query()).Returns(_Categorys.AsQueryable());
			_CategoryBusiness = new CategoryBusiness(_mockRepository.Object);
			_Categorys.Add(new Category
			{
				Id = "Test",
				User = _user
			});
			_Categorys.Add(new Category
			{
				User = _user
			});
		}

		#endregion

		#region GetCategorys Tests

		[TestMethod]
		public void OnGetCategorys_without_params_should_retrun_all()
		{
			var result = _CategoryBusiness.GetUserCategories(_user, CategoryType.Expense).ToList();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count() == _Categorys.Count);
		}

		[TestMethod]
		public void OnGetCategorys_with_category_should_return_allTime_for_this_category()
		{
			var result = _CategoryBusiness.GetCategoryById("Test");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Id == "Test");
		}

		#endregion

		#region Add Category

		[TestMethod]
		public void OnAddCategory_with_one_should_add_one()
		{
			var Category = new Category
			{
				Id = "Test1",
				User = _user,
			};
			_CategoryBusiness.SaveCategory(Category);

			var result = _CategoryBusiness.GetCategoryById("Test");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Id == "Test");
		}

		#endregion

		#region RemoveCategory Tests

		[TestMethod]
		public void OnRemover_with_one_should_remove_one()
		{
			var result = _CategoryBusiness.GetCategoryById("Test");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Id == "Test");
			_CategoryBusiness.RemoveCategory(result);
			result = _CategoryBusiness.GetCategoryById("Test");
			Assert.IsNull(result);
		}

		#endregion
	}
}