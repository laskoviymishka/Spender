using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace Spender.Common.Controllers
{
	public abstract class BaseController<TItem>
	{
		protected MobileServiceClient MobileServiceClient { get; set; }

		protected IMobileServiceSyncTable<TItem> MobileServiceSyncTable { get; set; }

		protected BaseController()
		{
			MobileServiceClient = new MobileServiceClient("","");
			MobileServiceSyncTable = MobileServiceClient.GetSyncTable<TItem>();
		}

		public abstract Task<TItem> GetItem(string id);

		protected Task<IEnumerable<TItem>> QueryItem(Expression<Func<TItem, bool>> predicate)
		{
			return this.MobileServiceSyncTable.Where(predicate).ToEnumerableAsync();
		}

		protected void UpdateItem(TItem item)
		{
			this.MobileServiceSyncTable.UpdateAsync(item);
		}

		protected void InsertItem(TItem item)
		{
			this.MobileServiceSyncTable.InsertAsync(item);
		}

		public void DeleteItem(TItem item)
		{
			this.MobileServiceSyncTable.DeleteAsync(item);
		}
	}
}