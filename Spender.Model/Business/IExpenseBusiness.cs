// // -----------------------------------------------------------------------
// // <copyright file="IExpenseBusiness.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Spender.Model.Entities;

namespace Spender.Model.Business
{
	#region Using

	

	#endregion

	public interface IExpenseBusiness
	{
		Expense GetExpenseById(ExpenseUser user, string id);

		IEnumerable<Expense> GetExpenses(ExpenseUser user);
		IEnumerable<Expense> GetExpenses(ExpenseUser user, Category category);
		IEnumerable<Expense> GetExpenses(ExpenseUser user, Category category, DateTime start, DateTime end);
		IEnumerable<Expense> GetExpenses(ExpenseUser user, DateTime start, DateTime end);

		void AddExpense(Expense expense);
		void AddExpense(IEnumerable<Expense> expenses);

		void RemoveExpense(Expense expense);
		void RemoveExpense(IEnumerable<Expense> expenses);
	}
}