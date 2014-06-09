// // -----------------------------------------------------------------------
// // <copyright file="ExpenseBusiness.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Spender.Model.Business
{
	#region Using

	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using Spender.Model.Entities;
	using Spender.Model.Repository;

	#endregion

	public class ExpenseBusiness : IExpenseBusiness
	{
		private readonly IRepository<Expense> _repository;

		public ExpenseBusiness(IRepository<Expense> repository)
		{
			_repository = repository;
		}

		public Expense GetExpenseById(ExpenseUser user, string id)
		{
			return _repository.Query().Include(e => e.Category).FirstOrDefault(e => e.Id == id && e.User.Id == user.Id);
		}

		public IEnumerable<Expense> GetExpenses(ExpenseUser user)
		{
			return _repository.Query().Include(e => e.Category).Where(e => e.User.Id == user.Id);
		}

		public IEnumerable<Expense> GetExpenses(ExpenseUser user, Category category)
		{
			return _repository.Query().Include(e => e.Category).Where(e => e.User.Id == user.Id && e.Category.Id == category.Id);
		}

		public IEnumerable<Expense> GetExpenses(ExpenseUser user, Category category, DateTime start, DateTime end)
		{
			return
				_repository.Query().Include(e => e.Category)
					.Where(e => e.User.Id == user.Id && e.Category.Id == category.Id && e.Date >= start && e.Date <= end);
		}

		public IEnumerable<Expense> GetExpenses(ExpenseUser user, DateTime start, DateTime end)
		{
			return _repository.Query().Include(e => e.Category).Where(e => e.User.Id == user.Id && e.Date >= start && e.Date <= end);
		}

		public void AddExpense(Expense expense)
		{
			_repository.Add(expense);
		}

		public void AddExpense(IEnumerable<Expense> expenses)
		{
			foreach (var expense in expenses)
			{
				AddExpense(expense);
			}
		}

		public void RemoveExpense(Expense expense)
		{
			_repository.Remove(expense);
		}

		public void RemoveExpense(IEnumerable<Expense> expenses)
		{
			foreach (var expense in expenses)
			{
				RemoveExpense(expense);
			}
		}
	}
}