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
		public IEnumerable<ExpenseListViewModel> GenerateExpenseList()
		{
			var result = new List<ExpenseListViewModel>();

			var dayElementa = new ExpenseListViewModel("today");
			var yesterdayElementa = new ExpenseListViewModel("yerstoday");
			var weekElementa = new ExpenseListViewModel("week");
			var monthElementa = new ExpenseListViewModel("month");
			var yearElementa = new ExpenseListViewModel("year");
			var allElementa = new ExpenseListViewModel("all");


			foreach (Expense item in StaticDataHolder.Expenses)
			{
				if (item.Date >= DateTime.Now.AddDays(-1))
				{
					dayElementa.Total += item.Amount;
					dayElementa.Items.Add(new ExpenseViewModel
					{
						Title = item.Name,
						Group = item.Category.Name,
						Information = string.Format("{0} : {1}", item.Date.ToShortDateString(), item.Amount),
						ImageSource = new Uri(item.Category.Image),
						Note =  item.Note,
						CheckImageSource = item.Image,
						Location = item.Location
					});
				}

				if (item.Date >= DateTime.Now.AddDays(-2))
				{
					yesterdayElementa.Total += item.Amount;
					yesterdayElementa.Items.Add(new ExpenseViewModel
					{
						Title = item.Name,
						Group = item.Category.Name,
						Information = string.Format("{0} = {1}", item.Date.ToShortDateString(), item.Amount),
						ImageSource = new Uri(item.Category.Image),
						Note = item.Note,
						CheckImageSource = item.Image,
						Location = item.Location
					});
				}

				if (item.Date >= DateTime.Now.AddDays(-7))
				{
					weekElementa.Total += item.Amount;
					weekElementa.Items.Add(new ExpenseViewModel
					{
						Title = item.Name,
						Group = item.Category.Name,
						Information = string.Format("{0} = {1}", item.Date.ToShortDateString(), item.Amount),
						ImageSource = new Uri(item.Category.Image),
						Note = item.Note,
						CheckImageSource = item.Image,
						Location = item.Location
					});
				}

				if (item.Date >= DateTime.Now.AddDays(-31))
				{
					monthElementa.Total += item.Amount;
					monthElementa.Items.Add(new ExpenseViewModel
					{
						Title = item.Name,
						Group = item.Category.Name,
						Information = string.Format("{0} = {1}", item.Date.ToShortDateString(), item.Amount),
						ImageSource = new Uri(item.Category.Image),
						Note = item.Note,
						CheckImageSource = item.Image,
						Location = item.Location
					});
				}

				if (item.Date >= DateTime.Now.AddDays(-365))
				{
					yearElementa.Total += item.Amount;
					yearElementa.Items.Add(new ExpenseViewModel
					{
						Title = item.Name,
						Group = item.Category.Name,
						Information = string.Format("{0} = {1}", item.Date.ToShortDateString(), item.Amount),
						ImageSource = new Uri(item.Category.Image),
						Note = item.Note,
						CheckImageSource = item.Image,
						Location = item.Location
					});
				}

				if (item.Date > DateTime.Now.AddDays(-365))
				{
					allElementa.Total += item.Amount;
					allElementa.Items.Add(new ExpenseViewModel
					{
						Title = item.Name,
						Group = item.Category.Name,
						Information = string.Format("{0} = {1}", item.Date.ToShortDateString(), item.Amount),
						ImageSource = new Uri(item.Category.Image),
						Note = item.Note,
						CheckImageSource = item.Image,
						Location = item.Location
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

		public void UpdateExpense(Expense expense)
		{
			StaticDataHolder.Expenses.RemoveAll(e => e.Id == expense.Id);
			StaticDataHolder.Expenses.Add(expense);
		}

		public void AddExpense(Expense expense)
		{
			StaticDataHolder.Expenses.Add(expense);
		}
	}
}