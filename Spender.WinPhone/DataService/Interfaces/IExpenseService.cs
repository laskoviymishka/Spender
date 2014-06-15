using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spender.WinPhone.ViewModel;
using Spender.WinPhone.ViewModels;

namespace Spender.WinPhone.DataService.Interfaces
{
	public interface IExpenseService
	{
		IEnumerable<ExpenseListItemViewModel> GenerateExpenseList();
		void UpdateExpense();
		void AddExpense();
	}
}
