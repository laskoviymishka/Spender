// // -----------------------------------------------------------------------
// // <copyright file="BudgetBusinessTests.cs"  company="One Call Care Management, Inc.">
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
	using Spender.Common.Entities;
	using Spender.Model.Business;
	using Spender.Model.Entities;
	using Spender.Model.Repository;

	#endregion

	[TestClass]
	public class BudgetBusinessTests
	{
		#region Private Fields

		private readonly IList<Budget> _budgets = new List<Budget>();
		private readonly IList<Budget> _copyBudgets = new List<Budget>();
		private IBudgetBusiness _budgetBusiness;
		private Budget _firstBudget;
		private Category _firstCategory;
		private Mock<IRepository<Budget>> _mockRepository;
		private Budget _secondBudget;
		private Category _secondCategory;
		private ExpenseUser _user;

		#endregion

		#region Init Test

		[TestInitialize]
		public void Init()
		{
			_firstCategory = new Category {Id = "1", Name = "Test", Type = CategoryType.Expense};
			_secondCategory = new Category {Id = "2", Name = "Test2", Type = CategoryType.Expense};
			_user = new ExpenseUser {Id = "1"};
			_firstBudget = new Budget
			{
				Id = "1",
				Category = _firstCategory,
				Interval = DateInterval.Month,
				Value = 25,
				User = new ExpenseUser {Id = "1"}
			};
			_secondBudget = new Budget
			{
				Id = "2",
				Category = _secondCategory,
				Interval = DateInterval.Month,
				Value = 71,
				User = new ExpenseUser {Id = "1"}
			};
			_copyBudgets.Add(_firstBudget);
			_copyBudgets.Add(_secondBudget);
			var firstBudget = new Budget
			{
				Id = "1",
				Category = _firstCategory,
				Interval = DateInterval.Month,
				Value = 25,
				User = new ExpenseUser {Id = "1"}
			};

			var secondBudget = new Budget
			{
				Id = "2",
				Category = _secondCategory,
				Interval = DateInterval.Month,
				Value = 71,
				User = new ExpenseUser {Id = "1"}
			};

			_budgets.Clear();
			_budgets.Add(firstBudget);
			_budgets.Add(secondBudget);
			_mockRepository = new Mock<IRepository<Budget>>();
			_mockRepository.Setup(m => m.Add(It.IsAny<Budget>())).Callback<Budget>(b => { _budgets.Add(b); });
			_mockRepository.Setup(m => m.Remove(It.IsAny<Budget>())).Callback<Budget>(b => { _budgets.Remove(b); });
			_mockRepository.Setup(m => m.Query()).Returns(_budgets.AsQueryable());
			_budgetBusiness = new BudgetBusiness(_mockRepository.Object);
		}

		#endregion

		#region GetBudgetForCategory Tests

		[TestMethod]
		public void Should_return_budget_for_category_according_to_interval_month()
		{
			var budget = _budgetBusiness.GetBudgetForCategory(_user, DateInterval.Month, _firstCategory);
			Assert.IsTrue(budget.Id == _firstBudget.Id);
			Assert.IsTrue(budget.Value == _firstBudget.Value);
		}

		[TestMethod]
		public void Should_return_budget_for_category_according_to_interval_Year()
		{
			var budget = _budgetBusiness.GetBudgetForCategory(_user, DateInterval.Year, _firstCategory);
			Assert.IsTrue(budget.Value == (_firstBudget.Value*12));
		}

		[TestMethod]
		public void Should_return_budget_for_category_according_to_interval_Quarter()
		{
			var budget = _budgetBusiness.GetBudgetForCategory(_user, DateInterval.Quarter, _firstCategory);
			Assert.IsTrue(budget.Value == (_firstBudget.Value*4));
		}

		[TestMethod]
		public void Should_return_budget_for_category_according_to_interval_Day()
		{
			var budget = _budgetBusiness.GetBudgetForCategory(_user, DateInterval.Day, _firstCategory);
			Assert.IsTrue(budget.Value == (_firstBudget.Value/30));
		}

		[TestMethod]
		public void Should_return_budget_for_category_according_to_interval_WeekOfYear()
		{
			var budget = _budgetBusiness.GetBudgetForCategory(_user, DateInterval.WeekOfYear, _firstCategory);
			Assert.IsTrue(budget.Value == ((_firstBudget.Value/30)*7));
		}

		#endregion

		#region GetBudgets Tests

		[TestMethod]
		public void Should_retrun_all_budgets_for_interval_dafeault_month()
		{
			var budgets = _budgetBusiness.GetBudgets(_user).ToList();
			Assert.IsNotNull(budgets);
			Assert.IsTrue(budgets.Count() == _budgets.Count());
			Assert.IsTrue(budgets[0].Id == _budgets[0].Id);
			Assert.IsTrue(budgets[0].Interval == DateInterval.Month);
			Assert.IsTrue(budgets[0].Value == _budgets[0].Value);
		}

		[TestMethod]
		public void Should_retrun_all_budgets_for_interval_month()
		{
			var budgets = _budgetBusiness.GetBudgets(_user, DateInterval.Month).ToList();
			Assert.IsNotNull(budgets);
			Assert.IsTrue(budgets.Count() == _budgets.Count());
			Assert.IsTrue(budgets[0].Id == _budgets[0].Id);
			for (int i = 0; i < budgets.Count; i++)
			{
				var budget = budgets[i];
				Assert.IsTrue(budget.Interval == DateInterval.Month);
				Assert.IsTrue(budget.Value == _copyBudgets[i].Value);
			}
		}


		[TestMethod]
		public void Should_retrun_all_budgets_for_interval_Year()
		{
			var budgets = _budgetBusiness.GetBudgets(_user, DateInterval.Year).ToList();
			Assert.IsNotNull(budgets);
			Assert.IsTrue(budgets.Count() == _budgets.Count());
			Assert.IsTrue(budgets[0].Id == _budgets[0].Id);
			for (int i = 0; i < budgets.Count; i++)
			{
				var budget = budgets[i];
				Assert.IsTrue(budget.Interval == DateInterval.Year);
				Assert.IsTrue(budget.Value == _copyBudgets[i].Value*12);
			}
		}

		[TestMethod]
		public void Should_retrun_all_budgets_for_interval_WeekOfYear()
		{
			var budgets = _budgetBusiness.GetBudgets(_user, DateInterval.WeekOfYear).ToList();
			Assert.IsNotNull(budgets);
			Assert.IsTrue(budgets.Count() == _budgets.Count());
			Assert.IsTrue(budgets[0].Id == _budgets[0].Id);
			for (int i = 0; i < budgets.Count; i++)
			{
				var budget = budgets[i];
				Assert.IsTrue(budget.Interval == DateInterval.WeekOfYear);
				Assert.IsTrue(budget.Value == (_copyBudgets[i].Value/30)*7);
			}
		}

		[TestMethod]
		public void Should_retrun_all_budgets_for_interval_Quarter()
		{
			var budgets = _budgetBusiness.GetBudgets(_user, DateInterval.Quarter).ToList();
			Assert.IsNotNull(budgets);
			Assert.IsTrue(budgets.Count() == _budgets.Count());
			Assert.IsTrue(budgets[0].Id == _copyBudgets[0].Id);
			for (int i = 0; i < budgets.Count; i++)
			{
				var budget = budgets[i];
				Assert.IsTrue(budget.Interval == DateInterval.Quarter);
				Assert.IsTrue(budget.Value == _copyBudgets[i].Value*4);
			}
		}

		[TestMethod]
		public void Should_retrun_all_budgets_for_interval_Day()
		{
			var budgets = _budgetBusiness.GetBudgets(_user, DateInterval.Day).ToList();
			Assert.IsNotNull(budgets);
			Assert.IsTrue(budgets.Count() == _budgets.Count());
			Assert.IsTrue(budgets[0].Id == _budgets[0].Id);
			for (int i = 0; i < budgets.Count; i++)
			{
				var budget = budgets[i];
				Assert.IsTrue(budget.Interval == DateInterval.Day);
				Assert.IsTrue(budget.Value == _copyBudgets[i].Value/30);
			}
		}

		#endregion

		#region SaveBuget Tests

		[TestMethod]
		public void Should_save_to_store_and_convert_to_month_from_month()
		{
			var category = new Category {Id = "3"};
			var budgetInput = new Budget
			{
				Id = "3",
				Interval = DateInterval.Month,
				Value = 30,
				User = _user,
				Category = category
			};
			_budgetBusiness.SaveBudget(budgetInput);
			var result = _budgetBusiness.GetBudgetForCategory(_user, DateInterval.Month, category);
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Category == category);
			Assert.IsTrue(result.Id == "3");
			Assert.IsTrue(result.Value == 30);

			var otherBudgetInput = new Budget
			{
				Id = "4",
				Interval = DateInterval.Month,
				Value = 40,
				User = _user,
				Category = category
			};
			_budgetBusiness.SaveBudget(otherBudgetInput);
			result = _budgetBusiness.GetBudgetForCategory(_user, DateInterval.Month, category);
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Category == category);
			Assert.IsTrue(result.Id == "4");
			Assert.IsTrue(result.Value == 40);
		}

		[TestMethod]
		public void Should_save_to_store_and_convert_to_month_from_year()
		{
			var category = new Category {Id = "3"};
			var budgetInput = new Budget
			{
				Id = "3",
				Interval = DateInterval.Year,
				Value = 120,
				User = _user,
				Category = category
			};
			_budgetBusiness.SaveBudget(budgetInput);
			var result = _budgetBusiness.GetBudgetForCategory(_user, DateInterval.Month, category);
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Category == category);
			Assert.IsTrue(result.Id == "3");
			Assert.IsTrue(result.Value == 10);
			Assert.IsTrue(result.Interval == DateInterval.Month);
		}

		[TestMethod]
		public void Should_save_to_store_and_convert_to_month_from_quater()
		{
			var category = new Category {Id = "3"};
			var budgetInput = new Budget
			{
				Id = "3",
				Interval = DateInterval.Quarter,
				Value = 120,
				User = _user,
				Category = category
			};
			_budgetBusiness.SaveBudget(budgetInput);
			var result = _budgetBusiness.GetBudgetForCategory(_user, DateInterval.Month, category);
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Category == category);
			Assert.IsTrue(result.Id == "3");
			Assert.IsTrue(result.Value == 30);
			Assert.IsTrue(result.Interval == DateInterval.Month);
		}

		[TestMethod]
		public void Should_save_to_store_and_convert_to_month_from_day()
		{
			var category = new Category {Id = "3"};
			var budgetInput = new Budget
			{
				Id = "3",
				Interval = DateInterval.Day,
				Value = 10,
				User = _user,
				Category = category
			};
			_budgetBusiness.SaveBudget(budgetInput);
			var result = _budgetBusiness.GetBudgetForCategory(_user, DateInterval.Month, category);
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Category == category);
			Assert.IsTrue(result.Id == "3");
			Assert.IsTrue(result.Value == 300);
			Assert.IsTrue(result.Interval == DateInterval.Month);
		}

		[TestMethod]
		public void Should_save_to_store_and_convert_to_month_from_week()
		{
			var category = new Category {Id = "3"};
			var budgetInput = new Budget
			{
				Id = "3",
				Interval = DateInterval.WeekOfYear,
				Value = 7,
				User = _user,
				Category = category
			};
			_budgetBusiness.SaveBudget(budgetInput);
			var result = _budgetBusiness.GetBudgetForCategory(_user, DateInterval.Month, category);
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Category == category);
			Assert.IsTrue(result.Id == "3");
			Assert.IsTrue(result.Value == 30);
			Assert.IsTrue(result.Interval == DateInterval.Month);
		}

		#endregion

		#region Remove Tests

		[TestMethod]
		public void On_Remove_should_remove()
		{
			_budgetBusiness.RemoveBudget(_firstBudget);
			var budgets = _budgetBusiness.GetBudgets(_user).ToList();
			Assert.IsTrue(budgets.Count() == 1);
			Assert.IsTrue(budgets[0].Id == _secondBudget.Id);
		}

		#endregion
	}
}