#region usings

using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using Spender.Service.DataObjects;
using Spender.Service.Models;

#endregion

namespace Spender.Service.Controllers
{
	public class PaymentTransactionController : TableController<PaymentTransaction>
	{
		protected override void Initialize(HttpControllerContext controllerContext)
		{
			base.Initialize(controllerContext);
			var context = new MobileServiceContext();
			DomainManager = new EntityDomainManager<PaymentTransaction>(context, Request, Services);
		}

		// GET tables/PaymentTransaction
		public IQueryable<PaymentTransaction> GetAllPaymentTransaction()
		{
			return Query();
		}

		// GET tables/PaymentTransaction/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public SingleResult<PaymentTransaction> GetPaymentTransaction(string id)
		{
			return Lookup(id);
		}

		// PATCH tables/PaymentTransaction/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public Task<PaymentTransaction> PatchPaymentTransaction(string id, Delta<PaymentTransaction> patch)
		{
			return UpdateAsync(id, patch);
		}

		// POST tables/PaymentTransaction
		public async Task<IHttpActionResult> PostPaymentTransaction(PaymentTransaction item)
		{
			var current = await InsertAsync(item);
			return CreatedAtRoute("Tables", new {id = current.Id}, current);
		}

		// DELETE tables/PaymentTransaction/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public Task DeletePaymentTransaction(string id)
		{
			return DeleteAsync(id);
		}
	}
}