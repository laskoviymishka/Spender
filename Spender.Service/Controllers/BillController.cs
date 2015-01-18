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
	public class BillController : TableController<Bill>
	{
		protected override void Initialize(HttpControllerContext controllerContext)
		{
			base.Initialize(controllerContext);
			MobileServiceContext context = new MobileServiceContext();
			DomainManager = new EntityDomainManager<Bill>(context, Request, Services);
		}

		// GET tables/Bill
		public IQueryable<Bill> GetAllBill()
		{
			return Query();
		}

		// GET tables/Bill/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public SingleResult<Bill> GetBill(string id)
		{
			return Lookup(id);
		}

		// PATCH tables/Bill/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public Task<Bill> PatchBill(string id, Delta<Bill> patch)
		{
			return UpdateAsync(id, patch);
		}

		// POST tables/Bill
		public async Task<IHttpActionResult> PostBill(Bill item)
		{
			Bill current = await InsertAsync(item);
			return CreatedAtRoute("Tables", new {id = current.Id}, current);
		}

		// DELETE tables/Bill/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public Task DeleteBill(string id)
		{
			return DeleteAsync(id);
		}
	}
}