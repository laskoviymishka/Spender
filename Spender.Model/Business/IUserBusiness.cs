// // -----------------------------------------------------------------------
// // <copyright file="IUserBusiness.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
namespace Spender.Model.Business
{
	using Spender.Model.Entities;

	public interface IUserBusiness
	{
		ExpenseUser GetById(string id);
	}
}