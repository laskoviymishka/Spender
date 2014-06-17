// // -----------------------------------------------------------------------
// // <copyright file="BillBusinessTests.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Spender.Model.Business;
using Spender.Model.Entities;
using Spender.Model.Repository;

namespace Spender.Tests.Business
{
	#region Using

	

	#endregion

	[TestClass]
	public class BillBusinessTests
	{
		#region Private Fields

		private readonly IList<Bill> _bills = new List<Bill>();
		private readonly IList<Expense> _expenses = new List<Expense>();
		private IBillBusiness _billBusiness;
		private Category _firstCategory;
		private Mock<IRepository<Bill>> _mockBillRepository;
		private Mock<IRepository<Expense>> _mockExpenseRepository;
		private Category _secondCategory;
		private ExpenseUser _user;

		#endregion

		#region Tests Initialization

		[TestInitialize]
		public void Init()
		{
			_firstCategory = new Category {Id = "1", Name = "Test", Type = CategoryType.Expense};
			_secondCategory = new Category {Id = "2", Name = "Test2", Type = CategoryType.Expense};
			_user = new ExpenseUser {Id = "1"};
			_mockExpenseRepository = new Mock<IRepository<Expense>>();
			_mockExpenseRepository.Setup(m => m.Add(It.IsAny<Expense>())).Callback<Expense>(b => _expenses.Add(b));
			_mockExpenseRepository.Setup(m => m.Remove(It.IsAny<Expense>())).Callback<Expense>(b => _expenses.Remove(b));
			_mockExpenseRepository.Setup(m => m.Query()).Returns(_expenses.AsQueryable());
			_mockBillRepository = new Mock<IRepository<Bill>>();
			_mockBillRepository.Setup(m => m.Add(It.IsAny<Bill>())).Callback<Bill>(b => _bills.Add(b));
			_mockBillRepository.Setup(m => m.Remove(It.IsAny<Bill>())).Callback<Bill>(b => _bills.Remove(b));
			_mockBillRepository.Setup(m => m.Query()).Returns(_bills.AsQueryable());

			_billBusiness = new BillBusiness(_mockBillRepository.Object, _mockExpenseRepository.Object);

			_expenses.Add(new Expense
			{
				Id = "Test",
				User = _user
			});
			_expenses.Add(new Expense
			{
				Id = "Test2",
				User = _user
			});

			_bills.Add(new Bill
			{
				Category = _secondCategory,
				Id = "Test",
				User = _user,
				Name = "Test",
				Amount = 10,
				Deadline = DateTime.Now.AddDays(20)
			});
			_bills.Add(new Bill
			{
				Category = _firstCategory,
				Id = "Test2",
				User = _user,
				Name = "Test2",
				Amount = 20,
				Deadline = DateTime.Now.AddDays(20)
			});
			_bills.Add(new Bill
			{
				Category = _firstCategory,
				Id = "Test3",
				User = _user,
				Name = "Test3",
				Amount = 20,
				Deadline = DateTime.Now.AddDays(-20)
			});
		}

		#endregion

		#region GetBills Tests

		[TestMethod]
		public void OnGetBills_with_only_user_should_return_all_bills()
		{
			List<Bill> results = _billBusiness.GetBills(_user).ToList();
			Assert.IsNotNull(results);
			Assert.IsTrue(results.Count == _bills.Count);
			foreach (Bill result in results)
			{
				Assert.IsTrue(result.User == _user);
			}
		}

		[TestMethod]
		public void OnGetBills_with_deadline_and_user_should_return_all_bills()
		{
			List<Bill> results = _billBusiness.GetBills(_user, DateTime.Now).ToList();
			Assert.IsNotNull(results);
			foreach (Bill result in results)
			{
				Assert.IsTrue(result.Deadline >= DateTime.Now);
				Assert.IsTrue(result.User == _user);
			}
		}

		[TestMethod]
		public void OnGetBills_with_category_and_user_should_return_all_bills()
		{
			List<Bill> results = _billBusiness.GetBills(_user, _firstCategory).ToList();
			Assert.IsNotNull(results);
			foreach (Bill result in results)
			{
				Assert.IsTrue(result.Category == _firstCategory);
				Assert.IsTrue(result.User == _user);
			}
		}

		[TestMethod]
		public void OnGetBills_with_category_and_user_and_deadline_should_return_all_bills()
		{
			List<Bill> results = _billBusiness.GetBills(_user, _firstCategory, DateTime.Now).ToList();
			Assert.IsNotNull(results);
			foreach (Bill result in results)
			{
				Assert.IsTrue(result.Category == _firstCategory);
				Assert.IsTrue(result.User == _user);
				Assert.IsTrue(result.Deadline >= DateTime.Now);
			}
		}

		#endregion

		#region PayBill Tests

		[TestMethod]
		public void OnPayBill_bill_one_shoudl_remove_and_add_expense()
		{
			Bill bill = _billBusiness.GetBillById("Test");
			_billBusiness.PayBill(bill);
			bill = _billBusiness.GetBillById("Test");
			Assert.IsNull(bill);
			Assert.IsTrue(_expenses.FirstOrDefault(e => e.Name == "Test") != null);
		}

		[TestMethod]
		public void OnPayBill_bill_many_shoudl_remove_and_add_expense()
		{
			var list = new List<Bill>();
			list.Add(_billBusiness.GetBillById("Test"));
			list.Add(_billBusiness.GetBillById("Test2"));
			_billBusiness.PayBill(list);
			Bill bill = _billBusiness.GetBillById("Test");
			Assert.IsNull(bill);
			bill = _billBusiness.GetBillById("Test2");
			Assert.IsNull(bill);
			Assert.IsTrue(_expenses.FirstOrDefault(e => e.Name == "Test") != null);
			Assert.IsTrue(_expenses.FirstOrDefault(e => e.Name == "Test2") != null);
		}

		#endregion

		#region AddBill tests

		[TestMethod]
		public void OnAddBill_with_one_should_add_many()
		{
			var bil = new Bill
			{
				Category = _secondCategory,
				Id = "Test5",
				User = _user,
				Name = "Test5",
				Amount = 10,
				Deadline = DateTime.Now.AddDays(20)
			};
			_billBusiness.AddBill(bil);
			Assert.IsNotNull(_billBusiness.GetBillById("Test5"));
		}

		[TestMethod]
		public void OnAddBill_with_many_should_add_many()
		{
			var list = new List<Bill>();
			list.Add(new Bill
			{
				Category = _secondCategory,
				Id = "Test5",
				User = _user,
				Name = "Test5",
				Amount = 10,
				Deadline = DateTime.Now.AddDays(20)
			});
			list.Add(new Bill
			{
				Category = _firstCategory,
				Id = "Test6",
				User = _user,
				Name = "Test6",
				Amount = 20,
				Deadline = DateTime.Now.AddDays(20)
			});
			_billBusiness.AddBill(list);
			Assert.IsNotNull(_billBusiness.GetBillById("Test5"));
			Assert.IsNotNull(_billBusiness.GetBillById("Test6"));
		}

		#endregion
	}
}