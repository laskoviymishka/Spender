// // -----------------------------------------------------------------------
// // <copyright file="UserBusiness.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Linq;
using Spender.Model.Entities;
using Spender.Model.Repository;

namespace Spender.Model.Business
{
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