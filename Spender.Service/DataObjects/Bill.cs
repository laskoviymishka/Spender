﻿using System;
using Microsoft.WindowsAzure.Mobile.Service;

namespace Spender.Service.DataObjects
{
	public class Bill : EntityData
	{
		public string UserId { get; set; }
		public string Description { get; set; }
		public decimal Amount { get; set; }
		public TransactionHolder Sender { get; set; }
		public TransactionHolder Recipient { get; set; }
		public DateTime Deadline { get; set; }
		public Interval ReccuringInterval { get; set; }
	}
}