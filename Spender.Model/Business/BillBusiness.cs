// // -----------------------------------------------------------------------
// // <copyright file="BillBusiness.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Spender.Model.Entities;
using Spender.Model.Repository;

namespace Spender.Model.Business
{
	#region Using

	

	#endregion

	public class BillBusiness : IBillBusiness
	{
		#region Private Fields

		private readonly IRepository<Bill> _billRepository;
		private readonly IRepository<Expense> _expenseRepository;

		#endregion

		public BillBusiness(IRepository<Bill> billRepository, IRepository<Expense> expenseRepository)
		{
			_billRepository = billRepository;
			_expenseRepository = expenseRepository;
		}

		public Bill GetBillById(string id)
		{
			return _billRepository.Query().Include(b => b.Category).FirstOrDefault(b => b.Id == id);
		}

		public IEnumerable<Bill> GetBills(ExpenseUser user)
		{
			return _billRepository.Query().Include(b => b.Category).Where(b => b.User.Id == user.Id);
		}

		public IEnumerable<Bill> GetBills(ExpenseUser user, Category category)
		{
			return
				_billRepository.Query().Include(b => b.Category).Where(b => b.User.Id == user.Id && b.Category.Id == category.Id);
		}

		public IEnumerable<Bill> GetBills(ExpenseUser user, DateTime deadline)
		{
			return _billRepository.Query().Include(b => b.Category).Where(b => b.User.Id == user.Id && b.Deadline >= deadline);
		}

		public IEnumerable<Bill> GetBills(ExpenseUser user, Category category, DateTime deadline)
		{
			return
				_billRepository.Query()
					.Include(b => b.Category)
					.Where(b => b.User.Id == user.Id && b.Deadline >= deadline && b.Category.Id == category.Id);
		}

		public void PayBill(Bill bill)
		{
			if (!string.IsNullOrEmpty(bill.Id)
			    && GetBillById(bill.Id) != null
			    && GetBillById(bill.Id).ReccuringInterval == Interval.None)
			{
				_billRepository.Remove(bill);
			}
			var expense = new Expense();
			expense.Amount = bill.Amount;
			expense.Date = DateTime.Now;
			expense.Category = bill.Category;
			expense.Name = bill.Name;
			expense.Location = bill.Location;
			expense.Note = bill.Note;
			_expenseRepository.Add(expense);
		}

		public void PayBill(IEnumerable<Bill> bills)
		{
			foreach (Bill bill in bills)
			{
				PayBill(bill);
			}
		}

		public void AddBill(Bill bill)
		{
			_billRepository.Add(bill);
		}

		public void AddBill(IEnumerable<Bill> bills)
		{
			foreach (Bill bill in bills)
			{
				AddBill(bill);
			}
		}
	}
}