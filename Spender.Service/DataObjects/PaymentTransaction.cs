#region usings

using System;
using Microsoft.WindowsAzure.Mobile.Service;

#endregion

namespace Spender.Service.DataObjects
{
	public class PaymentTransaction : EntityData
	{
		public string UserID { get; set; }
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
		public TransactionHolder Sender { get; set; }
		public TransactionHolder Recipient { get; set; }
		public object ResourceName { get; set; }
		public string ImageUri { get; set; }
		public string SasQueryString { get; set; }
		public string ContainerName { get; set; }
		public string Description { get; set; }
	}
}