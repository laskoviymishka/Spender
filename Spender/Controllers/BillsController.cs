// // -----------------------------------------------------------------------
// // <copyright file="BillsController.cs"  company="One Call Care Management, Inc.">
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

	[Authorize]
	public class BillsController : ApiController
	{
		#region Private Fields

		private readonly IBillBusiness _billBusiness;
		private readonly ICategoryBusiness _categoryBusiness;
		private readonly IUserBusiness _userBusiness;

		#endregion

		#region Contructor

		public BillsController()
		{
			var appcontext = new ApplicationDbContext();
			_billBusiness = new BillBusiness(
				new EfRepository<Bill>(appcontext, appcontext.Bills),
				new EfRepository<Expense>(appcontext, appcontext.Expenses));
			_userBusiness = new UserBusiness(
				new EfRepository<ExpenseUser>(appcontext, appcontext.Users));
			_categoryBusiness = new CategoryBusiness(
				new EfRepository<Category>(appcontext, appcontext.Categories));
		}

		#endregion

		#region Api Methods

		[Route("api/Bills/GetReccuring")]
		public IEnumerable<string> GetReccuring()
		{
			return Enum.GetNames(typeof (Interval));
		}

		[Route("api/Bills/getAll")]
		public IEnumerable<Bill> GetBills()
		{
			var user = new ExpenseUser {Id = User.Identity.GetUserId()};
			return _billBusiness.GetBills(user);
		}


		[Route("api/Bills/getByCategory/{categoryId}")]
		public IEnumerable<Bill> GetBills(string categoryId)
		{
			var user = new ExpenseUser {Id = User.Identity.GetUserId()};
			var category = new Category {Id = categoryId};
			return _billBusiness.GetBills(user, category);
		}

		[Route("api/Bills/getByCategoryAndTime/{categoryId}/{deadline}")]
		public IEnumerable<Bill> GetBills(string categoryId, string deadline)
		{
			var user = new ExpenseUser {Id = User.Identity.GetUserId()};
			var category = new Category {Id = categoryId};
			return _billBusiness.GetBills(user, category, DateTime.Parse(deadline));
		}

		[HttpPost]
		[Route("api/Bills/PostFormData/{name}&={note}&={categoryId}&={amount}&={deadline}&={reccuring}")]
		public async Task<HttpResponseMessage> PostFormData(
			string name, string note, string categoryId, decimal amount, string deadline, Interval reccuring)
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
				var bill = new Bill
				{
					Id = Guid.NewGuid().ToString(),
					Name = name,
					Category = _categoryBusiness.GetCategoryById(categoryId),
					Note = note,
					Amount = amount,
					Date = DateTime.Now,
					Deadline = DateTime.Parse(deadline),
					ReccuringInterval = reccuring,
					User = _userBusiness.GetById(user.Id)
				};
				try
				{
					// Read the form image.
					await Request.Content.ReadAsMultipartAsync(provider);
					var info = new FileInfo(provider.FileData[0].LocalFileName);
					bill.Image = info.Name;
				}
				catch
				{
				}

				_billBusiness.AddBill(bill);
				return Request.CreateResponse(HttpStatusCode.OK);
			}
			catch (Exception e)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
			}
		}

		[HttpPost]
		[Route("api/Bills/PayBill")]
		public void PayBill(Bill bill)
		{
			_billBusiness.PayBill(bill);
		}

		#endregion
	}
}