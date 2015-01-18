using System;

namespace Spender.Shared.Contracts
{
	public class EntityData
	{
		public DateTimeOffset? CreatedAt { get; set; }
		public bool Deleted { get; set; }
		public string Id { get; set; }
		public DateTimeOffset? UpdatedAt { get; set; }
		public byte[] Version { get; set; }
	}
}