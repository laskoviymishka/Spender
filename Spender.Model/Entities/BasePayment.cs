// // -----------------------------------------------------------------------
// // <copyright file="BasePayment.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Spender.Model.Entities
{
	#region Using

	using System;
	using System.Data.Entity.Spatial;

	#endregion

	public class BasePayment : IEntity
	{
		public string Name { get; set; }
		public string Note { get; set; }
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
		public Category Category { get; set; }
		public DbGeography Location { get; set; }
		public ExpenseUser User { get; set; }
		public string Image { get; set; }
		public string Id { get; set; }
	}
}