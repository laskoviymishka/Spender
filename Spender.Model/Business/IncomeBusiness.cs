// // -----------------------------------------------------------------------
// // <copyright file="IncomeBusiness.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Spender.Model.Entities;
using Spender.Model.Repository;

namespace Spender.Model.Business
{
	#region Using

	

	#endregion

	public class IncomeBusiness : IIncomeBusiness
	{
		#region Private Fields

		private readonly IRepository<Income> _repository;

		#endregion

		#region Constructor

		public IncomeBusiness(IRepository<Income> repository)
		{
			_repository = repository;
		}

		#endregion

		#region IIncomeBusiness implementation

		public IEnumerable<Income> GetIncomes(ExpenseUser user)
		{
			return _repository.Query().Include(i => i.Category).Where(e => e.User.Id == user.Id);
		}

		public IEnumerable<Income> GetIncomes(ExpenseUser user, Category category)
		{
			return _repository.Query().Include(i => i.Category).Where(e => e.User.Id == user.Id && e.Category.Id == category.Id);
		}

		public IEnumerable<Income> GetIncomes(ExpenseUser user, Category category, DateTime start, DateTime end)
		{
			return
				_repository.Query().Include(i => i.Category)
					.Where(e => e.User.Id == user.Id && e.Category.Id == category.Id && e.Date >= start && e.Date <= end);
		}

		public IEnumerable<Income> GetIncomes(ExpenseUser user, DateTime start, DateTime end)
		{
			return
				_repository.Query().Include(i => i.Category)
					.Where(e => e.User.Id == user.Id && e.Date >= start && e.Date <= end);
		}

		public Income GetIncomeById(ExpenseUser user, string id)
		{
			return _repository.Query().Include(i => i.Category).FirstOrDefault(e => e.Id == id && e.User.Id == user.Id);
		}

		public void AddIncome(Income expense)
		{
			_repository.Add(expense);
		}

		public void AddIncome(IEnumerable<Income> expenses)
		{
			foreach (Income expense in expenses)
			{
				AddIncome(expense);
			}
		}

		public void RemoveIncome(Income income)
		{
			_repository.Remove(income);
		}

		public void RemoveIncome(IEnumerable<Income> incomes)
		{
			foreach (Income income in incomes)
			{
				RemoveIncome(income);
			}
		}

		#endregion
	}
}