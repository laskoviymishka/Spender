// // -----------------------------------------------------------------------
// // <copyright file="ExpenseBusinessTests.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Spender.Model.Business;
using Spender.Model.Entities;
using Spender.Model.Repository;

namespace Spender.Tests.Business
{
	#region Using

	

	#endregion

	[TestClass]
	public class ExpenseBusinessTests
	{
		#region Private Fields

		private readonly IList<Expense> _Expenses = new List<Expense>();
		private readonly IList<Expense> _copyExpenses = new List<Expense>();
		private IExpenseBusiness _ExpenseBusiness;
		private Category _firstCategory;
		private Mock<IRepository<Expense>> _mockRepository;
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
			_mockRepository = new Mock<IRepository<Expense>>();
			_mockRepository.Setup(m => m.Add(It.IsAny<Expense>())).Callback<Expense>(b => _Expenses.Add(b));
			_mockRepository.Setup(m => m.Remove(It.IsAny<Expense>())).Callback<Expense>(b => _Expenses.Remove(b));
			_mockRepository.Setup(m => m.Query()).Returns(_Expenses.AsQueryable());
			_ExpenseBusiness = new ExpenseBusiness(_mockRepository.Object);
			_Expenses.Add(new Expense
			{
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now
			});
			_Expenses.Add(new Expense
			{
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-5)
			});
			_Expenses.Add(new Expense
			{
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-25)
			});
			_Expenses.Add(new Expense
			{
				Category = _secondCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-55)
			});
			_Expenses.Add(new Expense
			{
				Category = _secondCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-254)
			});
			_Expenses.Add(new Expense
			{
				Id = "Test1",
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(75)
			});
		}

		#endregion

		#region GetExpenses Tests

		[TestMethod]
		public void OnGetExpenses_without_params_should_retrun_all()
		{
			List<Expense> result = _ExpenseBusiness.GetExpenses(_user).ToList();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count() == _Expenses.Count);
		}

		[TestMethod]
		public void OnGetExpenses_with_category_should_return_allTime_for_this_category()
		{
			IEnumerable<Expense> result = _ExpenseBusiness.GetExpenses(_user, _firstCategory);
			Assert.IsNotNull(result);
			foreach (Expense Expense in result)
			{
				Assert.IsTrue(Expense.Category == _firstCategory);
			}
		}

		[TestMethod]
		public void OnGetExpenses_with_category_and_time_should_return_this_time_for_this_category()
		{
			IEnumerable<Expense> result = _ExpenseBusiness.GetExpenses(_user, _firstCategory, DateTime.Now.AddDays(-215),
				DateTime.Now);
			Assert.IsNotNull(result);
			foreach (Expense Expense in result)
			{
				Assert.IsTrue(Expense.Date > DateTime.Now.AddDays(-215));
				Assert.IsTrue(Expense.Date < DateTime.Now);
				Assert.IsTrue(Expense.Category.Id == _firstCategory.Id);
			}
		}

		[TestMethod]
		public void OnGetExpenses_with_only_time_should_return_this_time_for_this_category()
		{
			List<Expense> result = _ExpenseBusiness.GetExpenses(_user, DateTime.Now.AddDays(-215), DateTime.Now).ToList();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Any(r => r.Category.Id == _firstCategory.Id));
			Assert.IsTrue(result.Any(r => r.Category.Id == _secondCategory.Id));
			foreach (Expense Expense in result)
			{
				Assert.IsTrue(Expense.Date > DateTime.Now.AddDays(-215));
				Assert.IsTrue(Expense.Date < DateTime.Now);
			}
		}

		[TestMethod]
		public void OnGetOnById_should_return_Expense_whith_such_id()
		{
			Expense result = _ExpenseBusiness.GetExpenseById(_user, "Test1");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Id == "Test1");
		}

		#endregion

		#region Add Expense

		[TestMethod]
		public void OnAddExpense_with_one_should_add_one()
		{
			var Expense = new Expense
			{
				Id = "Test",
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-25)
			};
			_ExpenseBusiness.AddExpense(Expense);

			Expense result = _ExpenseBusiness.GetExpenseById(_user, "Test");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Id == "Test");
		}

		[TestMethod]
		public void OnAddExpense_with_anye_should_add_many()
		{
			var Expense = new Expense
			{
				Id = "Test",
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-25)
			};
			var Expense2 = new Expense
			{
				Id = "Test2",
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-25)
			};
			_ExpenseBusiness.AddExpense(Expense);
			_ExpenseBusiness.AddExpense(Expense2);

			Expense result = _ExpenseBusiness.GetExpenseById(_user, "Test");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Id == "Test");

			result = _ExpenseBusiness.GetExpenseById(_user, "Test2");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Id == "Test2");
		}

		#endregion

		#region RemoveExpense Tests

		[TestMethod]
		public void OnRemover_with_one_should_remove_one()
		{
			Expense result = _ExpenseBusiness.GetExpenseById(_user, "Test1");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Id == "Test1");
			_ExpenseBusiness.RemoveExpense(result);
			result = _ExpenseBusiness.GetExpenseById(_user, "Test1");
			Assert.IsNull(result);
		}

		[TestMethod]
		public void OnRemover_with_many_should_remove_many()
		{
			var Expense = new Expense
			{
				Id = "Test",
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-25)
			};
			var Expense2 = new Expense
			{
				Id = "Test2",
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-25)
			};
			var list = new List<Expense>();
			list.Add(Expense);
			list.Add(Expense2);
			_ExpenseBusiness.AddExpense(list);
			Expense result = _ExpenseBusiness.GetExpenseById(_user, "Test");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Id == "Test");
			result = _ExpenseBusiness.GetExpenseById(_user, "Test2");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Id == "Test2");

			_ExpenseBusiness.RemoveExpense(list);
			result = _ExpenseBusiness.GetExpenseById(_user, "Test");
			Assert.IsNull(result);
			result = _ExpenseBusiness.GetExpenseById(_user, "Test2");
			Assert.IsNull(result);
		}

		#endregion
	}
}