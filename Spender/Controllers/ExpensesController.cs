// // -----------------------------------------------------------------------
// // <copyright file="ExpensesController.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Spender.Model.Business;
using Spender.Model.Entities;
using Spender.Model.Repository;
using Spender.Models;

namespace Spender.Controllers
{
	#region Using

	

	#endregion

	public class ExpensesController : ApiController
	{
		#region Private Fields

		private readonly ICategoryBusiness _categoryBusiness;
		private readonly IExpenseBusiness _expenseBusiness;
		private readonly IUserBusiness _userBusiness;

		#endregion

		#region Constructor

		public ExpensesController()
		{
			var appcontext = new ApplicationDbContext();
			_expenseBusiness = new ExpenseBusiness(new EfRepository<Expense>(appcontext, appcontext.Expenses));
			_categoryBusiness = new CategoryBusiness(new EfRepository<Category>(appcontext, appcontext.Categories));
			_userBusiness = new UserBusiness(new EfRepository<ExpenseUser>(appcontext, appcontext.Users));
		}

		#endregion

		#region Api Methods

		[HttpGet]
		[Route("api/Expenses/GetExpenses")]
		public IEnumerable<Expense> GetExpenses()
		{
			var user = new ExpenseUser {Id = User.Identity.GetUserId()};
			return _expenseBusiness.GetExpenses(user);
		}

		[HttpGet]
		[Route("api/Expenses/GetExpensesForCategory/{categoryId}")]
		public IEnumerable<Expense> GetExpenses(string categoryId)
		{
			var user = new ExpenseUser {Id = User.Identity.GetUserId()};
			Category category = _categoryBusiness.GetCategoryById(categoryId);
			return _expenseBusiness.GetExpenses(user, category);
		}

		[HttpGet]
		[Route("api/Expenses/GetExpensesForCategoryAndTime/{categoryId}&{startTime}&{endTime}")]
		public IEnumerable<Expense> GetExpenses(string categoryId, string startTime, string endTime)
		{
			var user = new ExpenseUser {Id = User.Identity.GetUserId()};
			Category category = _categoryBusiness.GetCategoryById(categoryId);
			return _expenseBusiness.GetExpenses(user, category, DateTime.Parse(startTime), DateTime.Parse(endTime));
		}

		[HttpGet]
		[Route("api/Expenses/GetExpensesById/{id}")]
		public Expense GetExpense(string id)
		{
			var user = new ExpenseUser {Id = User.Identity.GetUserId()};
			return _expenseBusiness.GetExpenseById(user, id);
		}

		[HttpPost]
		[Route("api/Expenses/PostFormData/{name}&={note}&={categoryId}&={amount}&={date}")]
		public async Task<HttpResponseMessage> PostFormData(
			string name, string note, string categoryId, decimal amount, string date)
		{
			// Check if the request contains multipart/form-data.
			if (!Request.Content.IsMimeMultipartContent())
			{
				throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
			}
			string root = HttpContext.Current.Server.MapPath("~/App_Data");
			var provider = new MultipartFormDataStreamProvider(root);
			try
			{
				var user = new ExpenseUser {Id = User.Identity.GetUserId()};
				var expense = new Expense
				{
					Id = Guid.NewGuid().ToString(),
					Name = name,
					Category = _categoryBusiness.GetCategoryById(categoryId),
					Note = note,
					Amount = amount,
					Date = DateTime.Parse(date),
					User = _userBusiness.GetById(user.Id)
				};
				try
				{
					// Read the form data.
					await Request.Content.ReadAsMultipartAsync(provider);
					var info = new FileInfo(provider.FileData[0].LocalFileName);
					expense.Image = info.Name;
				}
				catch
				{
				}

				_expenseBusiness.AddExpense(expense);
				return Request.CreateResponse(HttpStatusCode.OK);
			}
			catch (Exception e)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
			}
		}

		[HttpPost]
		[Route("api/Expenses/RemoveExpense")]
		public void RemoveExpense(Expense expense)
		{
			_expenseBusiness.RemoveExpense(expense);
		}

		#endregion
	}
}