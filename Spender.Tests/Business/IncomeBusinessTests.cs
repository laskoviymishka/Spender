// // -----------------------------------------------------------------------
// // <copyright file="IncomeBusinessTests.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Spender.Tests.Business
{
	#region Using

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;
	using Spender.Model.Business;
	using Spender.Model.Entities;
	using Spender.Model.Repository;

	#endregion

	[TestClass]
	public class IncomeBusinessTests
	{
		#region Private Fields

		private readonly IList<Income> _copyIncomes = new List<Income>();
		private readonly IList<Income> _incomes = new List<Income>();
		private Category _firstCategory;
		private IIncomeBusiness _incomeBusiness;
		private Mock<IRepository<Income>> _mockRepository;
		private Category _secondCategory;
		private ExpenseUser _user;

		#endregion

		#region Tests Initialization

		[TestInitialize]
		public void Init()
		{
			_firstCategory = new Category {Id = "1", Name = "Test", Type = CategoryType.Expense};
			_secondCategory = new Category {Id = "2", Name = "Test2", Type = CategoryType.Expense};
			_user = new ExpenseUser {Id = "1"};
			_mockRepository = new Mock<IRepository<Income>>();
			_mockRepository.Setup(m => m.Add(It.IsAny<Income>())).Callback<Income>(b => _incomes.Add(b));
			_mockRepository.Setup(m => m.Remove(It.IsAny<Income>())).Callback<Income>(b => _incomes.Remove(b));
			_mockRepository.Setup(m => m.Query()).Returns(_incomes.AsQueryable());
			_incomeBusiness = new IncomeBusiness(_mockRepository.Object);
			_incomes.Add(new Income
			{
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now
			});
			_incomes.Add(new Income
			{
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-5)
			});
			_incomes.Add(new Income
			{
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-25)
			});
			_incomes.Add(new Income
			{
				Category = _secondCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-55)
			});
			_incomes.Add(new Income
			{
				Category = _secondCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-254)
			});
			_incomes.Add(new Income
			{
				Id = "Test1",
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(75)
			});
		}

		#endregion

		#region GetIncomes Tests

		[TestMethod]
		public void OnGetIncomes_without_params_should_retrun_all()
		{
			var result = _incomeBusiness.GetIncomes(_user).ToList();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count() == _incomes.Count);
		}

		[TestMethod]
		public void OnGetIncomes_with_category_should_return_allTime_for_this_category()
		{
			var result = _incomeBusiness.GetIncomes(_user, _firstCategory);
			Assert.IsNotNull(result);
			foreach (var income in result)
			{
				Assert.IsTrue(income.Category == _firstCategory);
			}
		}

		[TestMethod]
		public void OnGetIncomes_with_category_and_time_should_return_this_time_for_this_category()
		{
			var result = _incomeBusiness.GetIncomes(_user, _firstCategory, DateTime.Now.AddDays(-215), DateTime.Now);
			Assert.IsNotNull(result);
			foreach (var income in result)
			{
				Assert.IsTrue(income.Date > DateTime.Now.AddDays(-215));
				Assert.IsTrue(income.Date < DateTime.Now);
				Assert.IsTrue(income.Category.Id == _firstCategory.Id);
			}
		}

		[TestMethod]
		public void OnGetIncomes_with_only_time_should_return_this_time_for_this_category()
		{
			var result = _incomeBusiness.GetIncomes(_user, DateTime.Now.AddDays(-215), DateTime.Now).ToList();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Any(r => r.Category.Id == _firstCategory.Id));
			Assert.IsTrue(result.Any(r => r.Category.Id == _secondCategory.Id));
			foreach (var income in result)
			{
				Assert.IsTrue(income.Date > DateTime.Now.AddDays(-215));
				Assert.IsTrue(income.Date < DateTime.Now);
			}
		}

		[TestMethod]
		public void OnGetOnById_should_return_income_whith_such_id()
		{
			var result = _incomeBusiness.GetIncomeById(_user, "Test1");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Id == "Test1");
		}

		#endregion

		#region Add Income

		[TestMethod]
		public void OnAddIncome_with_one_should_add_one()
		{
			var income = new Income
			{
				Id = "Test",
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-25)
			};
			_incomeBusiness.AddIncome(income);

			var result = _incomeBusiness.GetIncomeById(_user, "Test");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Id == "Test");
		}

		[TestMethod]
		public void OnAddIncome_with_anye_should_add_many()
		{
			var income = new Income
			{
				Id = "Test",
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-25)
			};
			var income2 = new Income
			{
				Id = "Test2",
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-25)
			};
			_incomeBusiness.AddIncome(income);
			_incomeBusiness.AddIncome(income2);

			var result = _incomeBusiness.GetIncomeById(_user, "Test");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Id == "Test");

			result = _incomeBusiness.GetIncomeById(_user, "Test2");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Id == "Test2");
		}

		#endregion

		#region RemoveIncome Tests

		[TestMethod]
		public void OnRemover_with_one_should_remove_one()
		{
			var result = _incomeBusiness.GetIncomeById(_user, "Test1");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Id == "Test1");
			_incomeBusiness.RemoveIncome(result);
			result = _incomeBusiness.GetIncomeById(_user, "Test1");
			Assert.IsNull(result);
		}

		[TestMethod]
		public void OnRemover_with_many_should_remove_many()
		{
			var income = new Income
			{
				Id = "Test",
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-25)
			};
			var income2 = new Income
			{
				Id = "Test2",
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-25)
			};
			var list = new List<Income>();
			list.Add(income);
			list.Add(income2);
			_incomeBusiness.AddIncome(list);
			var result = _incomeBusiness.GetIncomeById(_user, "Test");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Id == "Test");
			result = _incomeBusiness.GetIncomeById(_user, "Test2");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Id == "Test2");

			_incomeBusiness.RemoveIncome(list);
			result = _incomeBusiness.GetIncomeById(_user, "Test");
			Assert.IsNull(result);
			result = _incomeBusiness.GetIncomeById(_user, "Test2");
			Assert.IsNull(result);
		}

		#endregion
	}
}