// // -----------------------------------------------------------------------
// // <copyright file="ExpenseUser.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using Spender.Common.Entities;

namespace Spender.Model.Entities
{
	#region Using

	

	#endregion

	public class ExpenseUser : IdentityUser, IEntity, IPclUser
	{
		public IEnumerable<Category> Categories { get; set; }
	}
}