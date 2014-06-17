// // -----------------------------------------------------------------------
// // <copyright file="BudgetBusiness.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Spender.Common.Entities;
using Spender.Model.Entities;
using Spender.Model.Repository;

namespace Spender.Model.Business
{
	#region Using

	

	#endregion

	public class BudgetBusiness : IBudgetBusiness
	{
		private readonly IRepository<Budget> _repository;

		public BudgetBusiness(IRepository<Budget> repository)
		{
			_repository = repository;
		}

		public Budget GetBudgetForCategory(ExpenseUser user, DateInterval interval, Category category)
		{
			Budget result = _repository.Query().First(b => b.Category.Id == category.Id && b.User.Id == user.Id);
			result.Interval = interval;
			return result;
		}

		public IEnumerable<Budget> GetBudgets(ExpenseUser user, DateInterval interval)
		{
			IQueryable<Budget> result = _repository.Query().Where(b => b.User.Id == user.Id);
			foreach (Budget budget in result)
			{
				budget.Interval = interval;
			}
			return result;
		}

		public IEnumerable<Budget> GetBudgets(ExpenseUser user)
		{
			return GetBudgets(user, DateInterval.Month);
		}

		public void SaveBudget(Budget budget)
		{
			switch (budget.Interval)
			{
				case DateInterval.Year:
					budget.Interval = DateInterval.Month;
					budget.Value = budget.Value/12;
					break;
				case DateInterval.Quarter:
					budget.Interval = DateInterval.Month;
					budget.Value = budget.Value/4;
					break;
				case DateInterval.Month:
					break;
				case DateInterval.Day:
					budget.Interval = DateInterval.Month;
					budget.Value = budget.Value*30;
					break;
				case DateInterval.WeekOfYear:
					budget.Interval = DateInterval.Month;
					budget.Value = (budget.Value/7)*30;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			RemoveBudget(budget);
			_repository.Add(budget);
		}

		public void RemoveBudget(Budget budget)
		{
			Budget result =
				_repository.Query().FirstOrDefault(b => b.Category.Id == budget.Category.Id && b.User.Id == budget.User.Id);
			if (result != null)
			{
				_repository.Remove(result);
			}
		}
	}
}