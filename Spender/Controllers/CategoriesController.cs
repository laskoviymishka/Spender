// // -----------------------------------------------------------------------
// // <copyright file="CategoriesController.cs"  company="One Call Care Management, Inc.">
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

	[Authorize]
	public class CategoriesController : ApiController
	{
		private readonly ICategoryBusiness _categoryBusiness;
		private readonly IUserBusiness _userBusiness;


		public CategoriesController()
		{
			var context = new ApplicationDbContext();
			_categoryBusiness = new CategoryBusiness(new EfRepository<Category>(context, context.Categories));
			_userBusiness = new UserBusiness(new EfRepository<ExpenseUser>(context, context.Users));
		}

		[HttpGet]
		[Route("api/Categories/GetIncomeCategories")]
		public IEnumerable<Category> GetIncomeCategories()
		{
			var user = new ExpenseUser { Id = User.Identity.GetUserId() };
			return _categoryBusiness.GetUserCategories(user, CategoryType.Income);
		}

		[HttpGet]
		[Route("api/Categories/GetUserCategories")]
		public IEnumerable<Category> GetAllCategories()
		{
			var user = new ExpenseUser { Id = User.Identity.GetUserId() };
			var result = new List<Category>();
			result.AddRange(_categoryBusiness.GetUserCategories(user, CategoryType.Income));
			result.AddRange(_categoryBusiness.GetUserCategories(user, CategoryType.Expense));
			return result;
		}

		[HttpGet]
		[Route("api/Categories/GetExpenseCategories")]
		public IEnumerable<Category> GetExpenseCategories()
		{
			var user = new ExpenseUser { Id = User.Identity.GetUserId() };
			return _categoryBusiness.GetUserCategories(user, CategoryType.Expense);
		}

		[HttpGet]
		[Route("api/Categories/GetCategory/{id}")]
		public Category GetCategory(string id)
		{
			return _categoryBusiness.GetCategoryById(id);
		}

		[HttpGet]
		[Route("api/Categories/RemoveCategory/{id}")]
		public void DeleteCategory(string id)
		{
			_categoryBusiness.RemoveCategory(GetCategory(id));
		}

		[HttpPost]
		[Route("api/Categories/PostFormData/{name}/{type}")]
		public async Task<HttpResponseMessage> PostFormData(string name, CategoryType type)
		{
			// Check if the request contains multipart/form-data.
			if (!Request.Content.IsMimeMultipartContent())
			{
				throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
			}
			string root = HttpContext.Current.Server.MapPath("~/App_Data");
			var rootUrl = Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.AbsolutePath, String.Empty);
			var provider = new MultipartFormDataStreamProvider(root);
			try
			{
				var user = new ExpenseUser { Id = User.Identity.GetUserId() };
				var category = new Category
				{
					Id = Guid.NewGuid().ToString(),
					Name = name,
					User = _userBusiness.GetById(user.Id),
					Type = type
				};

				try
				{
					// Read the form data.
					await Request.Content.ReadAsMultipartAsync(provider);
					var info = new FileInfo(provider.FileData[0].LocalFileName);
					category.Image = info.Name;
				}
				catch
				{
				}

				_categoryBusiness.SaveCategory(category);
				return Request.CreateResponse(HttpStatusCode.OK);
			}
			catch (Exception e)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
			}
		}
	}
}