using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using Spender.Service.DataObjects;
using Spender.Service.Models;

namespace Spender.Service.Controllers
{
	public class TransactionHolderController : TableController<TransactionHolder>
	{
		protected override void Initialize(HttpControllerContext controllerContext)
		{
			base.Initialize(controllerContext);
			MobileServiceContext context = new MobileServiceContext();
			DomainManager = new EntityDomainManager<TransactionHolder>(context, Request, Services);
		}

		// GET tables/TransactionHolder
		public IQueryable<TransactionHolder> GetAllTransactionHolder()
		{
			return Query();
		}

		// GET tables/TransactionHolder/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public SingleResult<TransactionHolder> GetTransactionHolder(string id)
		{
			return Lookup(id);
		}

		// PATCH tables/TransactionHolder/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public Task<TransactionHolder> PatchTransactionHolder(string id, Delta<TransactionHolder> patch)
		{
			return UpdateAsync(id, patch);
		}

		// POST tables/TransactionHolder
		public async Task<IHttpActionResult> PostTransactionHolder(TransactionHolder item)
		{
			TransactionHolder current = await InsertAsync(item);
			return CreatedAtRoute("Tables", new { id = current.Id }, current);
		}

		// DELETE tables/TransactionHolder/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public Task DeleteTransactionHolder(string id)
		{
			return DeleteAsync(id);
		}

	}
}