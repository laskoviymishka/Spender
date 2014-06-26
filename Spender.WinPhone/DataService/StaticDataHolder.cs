using System;
using System.Collections.Generic;
using Spender.Model.Entities;
using Spender.WinPhone.ViewModels;

namespace Spender.WinPhone.DataService
{
	public class StaticDataHolder
	{
		public static ExpenseUser User { get; set; }
		public static List<Expense> Expenses { get; set; }
		public static List<Income> Incomes { get; set; }
		public static List<Bill> Bills { get; set; }
		public static List<Category> Categories { get; set; }
		public static ExpenseViewModel SelectedExpenseViewModel { get; set; }
		public static Category SelectedCategory { get; set; }
		public static string SelectedImage { get; set; }
		public static Expense SelectedExpense { get; set; }


		static StaticDataHolder()
		{
			User = new ExpenseUser { Id = "1" };
			Expenses = new List<Expense>();
			Incomes = new List<Income>();
			Bills = new List<Bill>();
			Categories = new List<Category>();

			Categories.Add(new Category
			{
				Id = "1",
				Name = "Test",
				Type = CategoryType.Expense,
				Image = @"\Assets\banking\Employee.png"
			});
			Categories.Add(new Category
			{
				Id = "2",
				Name = "Test2",
				Type = CategoryType.Expense,
				Image = @"\Assets\banking\Scanner.png"
			});
			Expenses.Add(new Expense
			{
				Name = "test expense",
				Id = "1",
				Category = Categories[0],
				Amount = 10,
				User = User,
				Date = DateTime.Now,
				Note = "note note note",
				Image = @"http://www.askkt.ru/news/images/chek.jpg"
			});
			Expenses.Add(new Expense
			{
				Id = "11",
				Name = "test expense",
				Category = Categories[0],
				Amount = 12,
				User = User,
				Date = DateTime.Now,
				Note = "note note note",
				Image = @"http://www.askkt.ru/news/images/chek.jpg"
			});
			Expenses.Add(new Expense
			{
				Id = "21",
				Name = "test expense",
				Category = Categories[1],
				Amount = 10,
				User = User,
				Date = DateTime.Now.AddDays(-1),
				Note = "note note note",
				Image = @"http://www.askkt.ru/news/images/chek.jpg"
			});
			Expenses.Add(new Expense
			{
				Id = "21",
				Name = "test expense",
				Category = Categories[0],
				Amount = 12,
				User = User,
				Date = DateTime.Now.AddDays(-1),
				Note = "note note note",
				Image = @"http://www.askkt.ru/news/images/chek.jpg"
			});
			Expenses.Add(new Expense
			{
				Id = "2",
				Name = "test expense",
				Category = Categories[0],
				Amount = 10,
				User = User,
				Date = DateTime.Now.AddDays(-5),
				Note = "note note note",
				Image = @"http://www.askkt.ru/news/images/chek.jpg"
			});
			Expenses.Add(new Expense
			{
				Id = "3",
				Name = "test expense",
				Category = Categories[1],
				Amount = 10,
				User = User,
				Date = DateTime.Now.AddDays(-25),
				Note = "note note note",
				Image = @"http://www.askkt.ru/news/images/chek.jpg"
			});
			Expenses.Add(new Expense
			{
				Id = "4",
				Name = "test expense",
				Category = Categories[0],
				Amount = 10,
				User = User,
				Date = DateTime.Now.AddDays(-55),
				Note = "note note note",
				Image = @"http://www.askkt.ru/news/images/chek.jpg"
			});
			Expenses.Add(new Expense
			{
				Id = "5",
				Name = "test expense",
				Category = Categories[0],
				Amount = 10,
				User = User,
				Date = DateTime.Now.AddDays(-254),
				Note = "note note note",
				Image = @"http://www.askkt.ru/news/images/chek.jpg"
			});
			Expenses.Add(new Expense
			{
				Id = "6",
				Name = "test expense",
				Category = Categories[1],
				Amount = 10,
				User = User,
				Date = DateTime.Now.AddDays(-3),
				Note = "note note note",
				Image = @"http://www.askkt.ru/news/images/chek.jpg"
			});
		}
	}
}