// // -----------------------------------------------------------------------
// // <copyright file="MyInfoController.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Web.Mvc;

namespace Spender.Controllers
{
	#region Using

	

	#endregion

	[Authorize]
	public class MyInfoController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Calendar()
		{
			return View();
		}

		public ActionResult Expenses()
		{
			return PartialView();
		}

		public ActionResult Incomes()
		{
			return PartialView();
		}

		public ActionResult Bills()
		{
			return PartialView();
		}

		public ActionResult Budgets()
		{
			return PartialView();
		}

		public ActionResult Categories()
		{
			return PartialView();
		}

		public ActionResult AddCategory()
		{
			return PartialView();
		}

		public ActionResult AddBill()
		{
			return PartialView();
		}

		public ActionResult AddExpense()
		{
			return PartialView();
		}

		public ActionResult AddIncome()
		{
			return PartialView();
		}
	}
}