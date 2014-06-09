// // -----------------------------------------------------------------------
// // <copyright file="Category.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Spender.Model.Entities
{
	public class Category : IEntity
	{
		public string Name { get; set; }
		public string Image { get; set; }
		public CategoryType Type { get; set; }
		public ExpenseUser User { get; set; }
		public string Id { get; set; }
	}
}