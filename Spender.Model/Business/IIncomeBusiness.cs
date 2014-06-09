// // -----------------------------------------------------------------------
// // <copyright file="IIncomeBusiness.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Spender.Model.Business
{
	#region Using

	using System;
	using System.Collections.Generic;
	using Spender.Model.Entities;

	#endregion

	public interface IIncomeBusiness
	{
		Income GetIncomeById(ExpenseUser user, string id);

		IEnumerable<Income> GetIncomes(ExpenseUser user);
		IEnumerable<Income> GetIncomes(ExpenseUser user, Category category);
		IEnumerable<Income> GetIncomes(ExpenseUser user, Category category, DateTime start, DateTime end);
		IEnumerable<Income> GetIncomes(ExpenseUser user, DateTime start, DateTime end);

		void AddIncome(Income expense);
		void AddIncome(IEnumerable<Income> expenses);

		void RemoveIncome(Income income);
		void RemoveIncome(IEnumerable<Income> incomes);
	}
}