// // -----------------------------------------------------------------------
// // <copyright file="KnownLocation.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Spender.Model.Entities
{
	#region Using

	#endregion

	public class KnownLocation : IEntity
	{
		public string Name { get; set; }
		public string Location { get; set; }
		public string Id { get; set; }
	}
}