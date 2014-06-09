// // -----------------------------------------------------------------------
// // <copyright file="IdentityModels.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Spender.Models
{
	#region Using

	using System.Data.Entity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using Spender.Model.Entities;

	#endregion

	public class ApplicationDbContext : IdentityDbContext<ExpenseUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection")
		{
		}

		public IDbSet<Expense> Expenses { get; set; }
		public IDbSet<Income> Incomes { get; set; }
		public IDbSet<Budget> Budgets { get; set; }
		public IDbSet<Category> Categories { get; set; }
		public IDbSet<KnownLocation> Locations { get; set; }
		public IDbSet<Bill> Bills { get; set; }
	}
}