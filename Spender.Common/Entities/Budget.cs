using System;
using Spender.Common.Entities;

// // -----------------------------------------------------------------------
// // <copyright file="Budget.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Spender.Model.Entities
{
	#region Using

	

	#endregion

	public class Budget : IEntity
	{
		private DateInterval _interval = DateInterval.Month;

		public IPclUser User { get; set; }
		public Category Category { get; set; }
		public decimal Value { get; set; }

		public DateInterval Interval
		{
			get { return _interval; }
			set
			{
				_interval = value;
				switch (value)
				{
					case DateInterval.Year:
						Value = Value*12;
						break;
					case DateInterval.Quarter:
						Value = Value*4;
						break;
					case DateInterval.Month: //Default Interva which should store in DB
						break;
					case DateInterval.Day:
						Value = Value/30;
						break;
					case DateInterval.WeekOfYear:
						Value = (Value/30)*7;
						break;
					default:
						throw new ArgumentOutOfRangeException("Interval");
				}
			}
		}

		public string Id { get; set; }
	}
}