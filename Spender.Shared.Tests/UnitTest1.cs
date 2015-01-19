#region usings

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spender.Shared.Contracts;
using Spender.Shared.Controllers;

#endregion

namespace Spender.Shared.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var payment = new PaymentTransaction
			{
				Amount = 2,
				Date = DateTime.Now,
				Sender = new TransactionHolder
				{
					Title = "Shop",
					Categories = new List<Category>
					{
						new Category
						{
							Description = "Shopping",
							Name = "Shopping",
							IsCustom = false
						}
					}
				},
				Recipient = new TransactionHolder
				{
					Title = "Shop",
					Categories = new List<Category>
					{
						new Category
						{
							Description = "Shopping",
							Name = "Shopping",
							IsCustom = false
						}
					}
				},
				Description = "Description"
			};

			var controller = new PaymentTransactionController(null);
			controller.InsertItem(payment);
		}
	}
}