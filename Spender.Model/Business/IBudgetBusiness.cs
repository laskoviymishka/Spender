// // -----------------------------------------------------------------------
// // <copyright file="IBudgetBusiness.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Collections.Generic;
using Spender.Common.Entities;
using Spender.Model.Entities;

namespace Spender.Model.Business
{
	#region Using

	

	#endregion

	public interface IBudgetBusiness
	{
		Budget GetBudgetForCategory(ExpenseUser user, DateInterval interval, Category category);
		IEnumerable<Budget> GetBudgets(ExpenseUser user, DateInterval interval);
		IEnumerable<Budget> GetBudgets(ExpenseUser user);

		void SaveBudget(Budget budget);
		void RemoveBudget(Budget budget);
	}
}