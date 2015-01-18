using System.Collections.Generic;
using Microsoft.WindowsAzure.Mobile.Service;

namespace Spender.Service.DataObjects
{
	public class TransactionHolder : EntityData
	{
		public string UserId { get; set; }
		public string Title { get; set; }
		public IEnumerable<Category> Categories { get; set; }
		public Location Location { get; set; }
	}
}