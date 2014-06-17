// // -----------------------------------------------------------------------
// // <copyright file="Bill.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System;

namespace Spender.Model.Entities
{
	#region Using

	

	#endregion

	public class Bill : BasePayment
	{
		public DateTime Deadline { get; set; }
		public Interval ReccuringInterval { get; set; }
	}

	public enum Interval
	{
		None,
		Weekly,
		BiWeekly,
		Monthly,
		Quater,
		HalfYear,
		Year
	}
}