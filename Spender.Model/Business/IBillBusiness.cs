// // -----------------------------------------------------------------------
// // <copyright file="IBillBusiness.cs"  company="One Call Care Management, Inc.">
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

	public interface IBillBusiness
	{
		Bill GetBillById(string id);

		IEnumerable<Bill> GetBills(ExpenseUser user);
		IEnumerable<Bill> GetBills(ExpenseUser user, Category category);
		IEnumerable<Bill> GetBills(ExpenseUser user, DateTime deadline);
		IEnumerable<Bill> GetBills(ExpenseUser user, Category category, DateTime deadline);

		void PayBill(Bill bill);
		void PayBill(IEnumerable<Bill> bills);

		void AddBill(Bill bill);
		void AddBill(IEnumerable<Bill> bills);
	}
}