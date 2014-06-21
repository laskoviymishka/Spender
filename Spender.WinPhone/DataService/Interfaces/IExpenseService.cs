using System.Collections.Generic;
using Spender.Model.Entities;
using Spender.WinPhone.ViewModel;

namespace Spender.WinPhone.DataService.Interfaces
{
	public interface IExpenseService
	{
		IEnumerable<ExpenseListViewModel> GenerateExpenseList();
		void UpdateExpense(Expense expense);
		void AddExpense(Expense expense);
	}
}