﻿// // -----------------------------------------------------------------------
// // <copyright file="IncomeController.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Spender.Controllers
{
	#region Using

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

	#endregion

	public class IncomeController : ApiController
	{
		#region Private Fields

		private readonly ICategoryBusiness _categoryBusiness;
		private readonly IIncomeBusiness _incomeBusiness;
		private readonly IUserBusiness _userBusiness;

		#endregion

		#region Constructor

		public IncomeController()
		{
			var appcontext = new ApplicationDbContext();
			_incomeBusiness = new IncomeBusiness(
				new EfRepository<Income>(appcontext, appcontext.Incomes));
			_categoryBusiness = new CategoryBusiness(
				new EfRepository<Category>(appcontext, appcontext.Categories));
			_userBusiness = new UserBusiness(
				new EfRepository<ExpenseUser>(appcontext, appcontext.Users));
		}

		#endregion

		#region Api Methods

		[HttpGet]
		[Route("api/Income/GetIncomes")]
		public IEnumerable<Income> GetIncomes()
		{
			var user = new ExpenseUser { Id = User.Identity.GetUserId() };
			return _incomeBusiness.GetIncomes(user);
		}

		public IEnumerable<Income> GetIncomes(string categoryId)
		{
			var user = new ExpenseUser { Id = User.Identity.GetUserId() };
			var category = _categoryBusiness.GetCategoryById(categoryId);
			return _incomeBusiness.GetIncomes(user, category);
		}

		public IEnumerable<Income> GetIncomes(string categoryId, string startTime, string endTime)
		{
			var user = new ExpenseUser { Id = User.Identity.GetUserId() };
			var category = _categoryBusiness.GetCategoryById(categoryId);
			return _incomeBusiness.GetIncomes(user, category, DateTime.Parse(startTime), DateTime.Parse(endTime));
		}

		public Income GetIncome(string id)
		{
			var user = new ExpenseUser { Id = User.Identity.GetUserId() };
			return _incomeBusiness.GetIncomeById(user, id);
		}


		[HttpPost]
		[Route("api/Incomes/PostFormData/{name}&={note}&={categoryId}&={amount}&={date}")]
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
				var user = new ExpenseUser { Id = User.Identity.GetUserId() };
				var expense = new Income
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
				catch { }

				_incomeBusiness.AddIncome(expense);
				return Request.CreateResponse(HttpStatusCode.OK);
			}
			catch (Exception e)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
			}
		}

		public void RemoveIncome(Income income)
		{
			_incomeBusiness.AddIncome(income);
		}

		#endregion
	}
}