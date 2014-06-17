using System.Collections.Generic;
using Spender.WinPhone.ViewModel;

namespace Spender.WinPhone.DataService.Interfaces
{
	public interface IExpenseService
	{
		IEnumerable<ExpenseListItemViewModel> GenerateExpenseList();
		void UpdateExpense();
		void AddExpense();
	}
}