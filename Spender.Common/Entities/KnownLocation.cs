// // -----------------------------------------------------------------------
// // <copyright file="KnownLocation.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using Spender.Common.Entities;

namespace Spender.Model.Entities
{

	#region Using

	#endregion

	public class KnownLocation : IEntity
	{
		public string Name { get; set; }
		public Location Location { get; set; }
		public string Id { get; set; }
	}
}