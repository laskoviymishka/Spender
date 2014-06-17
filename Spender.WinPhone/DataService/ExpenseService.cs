using System;
using System.Collections.Generic;
using Spender.Model.Entities;
using Spender.WinPhone.DataService.Interfaces;
using Spender.WinPhone.ViewModel;
using Spender.WinPhone.ViewModels;

namespace Spender.WinPhone.DataService
{
	public class ExpenseService : IExpenseService
	{
		public IEnumerable<ExpenseListItemViewModel> GenerateExpenseList()
		{
			var result = new List<ExpenseListItemViewModel>();

			var dayElementa = new ExpenseListItemViewModel("today");
			var yesterdayElementa = new ExpenseListItemViewModel("yerstoday");
			var weekElementa = new ExpenseListItemViewModel("week");
			var monthElementa = new ExpenseListItemViewModel("month");
			var yearElementa = new ExpenseListItemViewModel("year");
			var allElementa = new ExpenseListItemViewModel("all");


			foreach (Expense item in GetMockExpenses())
			{
				if (item.Date >= DateTime.Now.AddDays(-1))
				{
					dayElementa.Total += item.Amount;
					dayElementa.Items.Add(new ExpenseItemViewModel
					{
						Title = item.Name,
						Group = item.Category.Name,
						Information = string.Format("{0} = {1}", item.Date.ToShortDateString(), item.Amount),
						ImageSource = new Uri(item.Category.Image),
					});
				}

				if (item.Date >= DateTime.Now.AddDays(-2))
				{
					yesterdayElementa.Total += item.Amount;
					yesterdayElementa.Items.Add(new ExpenseItemViewModel
					{
						Title = item.Name,
						Group = item.Category.Name,
						Information = string.Format("{0} = {1}", item.Date.ToShortDateString(), item.Amount),
						ImageSource = new Uri(item.Category.Image),
					});
				}

				if (item.Date >= DateTime.Now.AddDays(-7))
				{
					weekElementa.Total += item.Amount;
					weekElementa.Items.Add(new ExpenseItemViewModel
					{
						Title = item.Name,
						Group = item.Category.Name,
						Information = string.Format("{0} = {1}", item.Date.ToShortDateString(), item.Amount),
						ImageSource = new Uri(item.Category.Image),
					});
				}

				if (item.Date >= DateTime.Now.AddDays(-31))
				{
					monthElementa.Total += item.Amount;
					monthElementa.Items.Add(new ExpenseItemViewModel
					{
						Title = item.Name,
						Group = item.Category.Name,
						Information = string.Format("{0} = {1}", item.Date.ToShortDateString(), item.Amount),
						ImageSource = new Uri(item.Category.Image),
					});
				}

				if (item.Date >= DateTime.Now.AddDays(-365))
				{
					yearElementa.Total += item.Amount;
					yearElementa.Items.Add(new ExpenseItemViewModel
					{
						Title = item.Name,
						Group = item.Category.Name,
						Information = string.Format("{0} = {1}", item.Date.ToShortDateString(), item.Amount),
						ImageSource = new Uri(item.Category.Image),
					});
				}

				if (item.Date > DateTime.Now.AddDays(-365))
				{
					allElementa.Total += item.Amount;
					allElementa.Items.Add(new ExpenseItemViewModel
					{
						Title = item.Name,
						Group = item.Category.Name,
						Information = string.Format("{0} = {1}", item.Date.ToShortDateString(), item.Amount),
						ImageSource = new Uri(item.Category.Image),
					});
				}
			}

			result.Add(dayElementa);
			result.Add(yesterdayElementa);
			result.Add(weekElementa);
			result.Add(monthElementa);
			result.Add(yearElementa);
			result.Add(allElementa);
			return result;
		}

		public void UpdateExpense()
		{
			throw new NotImplementedException();
		}

		public void AddExpense()
		{
			throw new NotImplementedException();
		}

		private List<Expense> GetMockExpenses()
		{
			var _user = new ExpenseUser {Id = "1"};
			var _firstCategory = new Category
			{
				Id = "1",
				Name = "Test",
				Type = CategoryType.Expense,
				Image = @"http://cdn0.iconfinder.com/data/icons/simple-seo-and-internet-icons/512/links_building_add-512.png"
			};
			var _secondCategory = new Category
			{
				Id = "2",
				Name = "Test2",
				Type = CategoryType.Expense,
				Image = @"https://cdn4.iconfinder.com/data/icons/eldorado-mobile/40/link_3-512.png"
			};
			var result = new List<Expense>();
			result.Add(new Expense
			{
				Id = "1",
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now
			});
			result.Add(new Expense
			{
				Id = "11",
				Name = "test expense",
				Category = _firstCategory,
				Amount = 12,
				User = _user,
				Date = DateTime.Now
			});
			result.Add(new Expense
			{
				Id = "21",
				Name = "test expense",
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-1)
			});
			result.Add(new Expense
			{
				Id = "21",
				Name = "test expense",
				Category = _firstCategory,
				Amount = 12,
				User = _user,
				Date = DateTime.Now.AddDays(-1)
			});
			result.Add(new Expense
			{
				Id = "2",
				Name = "test expense",
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-5)
			});
			result.Add(new Expense
			{
				Id = "3",
				Name = "test expense",
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-25)
			});
			result.Add(new Expense
			{
				Id = "4",
				Name = "test expense",
				Category = _secondCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-55)
			});
			result.Add(new Expense
			{
				Id = "5",
				Name = "test expense",
				Category = _secondCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-254)
			});
			result.Add(new Expense
			{
				Id = "6",
				Name = "test expense",
				Category = _firstCategory,
				Amount = 10,
				User = _user,
				Date = DateTime.Now.AddDays(-3)
			});
			return result;
		}
	}
}