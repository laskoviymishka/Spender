#region usings

using System.Collections.Generic;

#endregion

namespace Spender.Shared.Contracts
{
	public class TransactionHolder : EntityData
	{
		public string UserId { get; set; }
		public string Title { get; set; }
		public IEnumerable<Category> Categories { get; set; }
		public Location Location { get; set; }
	}
}