namespace Spender.Shared.Contracts
{
	public class Category : EntityData
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageURI { get; set; }
		public string UserId { get; set; }
		public bool IsCustom { get; set; }
	}
}