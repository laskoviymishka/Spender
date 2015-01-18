// // -----------------------------------------------------------------------
// // <copyright file="IUserBusiness.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using Spender.Model.Entities;

namespace Spender.Model.Business
{
	public interface IUserBusiness
	{
		ExpenseUser GetById(string id);
	}
}