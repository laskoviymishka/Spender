// // -----------------------------------------------------------------------
// // <copyright file="UserBusiness.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------
namespace Spender.Model.Business
{
	using System.Linq;
	using Spender.Model.Entities;
	using Spender.Model.Repository;

	public class UserBusiness : IUserBusiness
	{
		private readonly IRepository<ExpenseUser> _repository;

		public UserBusiness(IRepository<ExpenseUser> repository)
		{
			_repository = repository;
		}

		public ExpenseUser GetById(string id)
		{
			return _repository.Query().FirstOrDefault(u => u.Id == id);
		}
	}
}