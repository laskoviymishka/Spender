using System;
using System.Collections.Generic;
using Spender.Model.Entities;

namespace Spender.Common.Services
{
	public interface IExpenseService : IBaseDataService<Expense>
	{
		IEnumerable<Expense> GetItems(DateTime starTime, DateTime endTime);
	}
}