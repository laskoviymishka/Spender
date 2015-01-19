using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Spender.Shared.Contracts;

namespace Spender.Shared.Controllers
{
	public class BaseController<TItem> : IBaseController<TItem> where TItem : EntityData
	{
		protected MobileServiceClient MobileServiceClient { get; set; }

		protected IMobileServiceSyncTable<TItem> MobileServiceSyncTable { get; set; }

		protected string CurrentUserId
		{
			get { return Guid.NewGuid().ToString(); }
		}

		protected BaseController()
		{
			MobileServiceClient = new MobileServiceClient(
				"http://localhost:60532/",
				"jsqhMquRTfyQecmjvGAFekRtdTfWJF46");
			MobileServiceSyncTable = MobileServiceClient.GetSyncTable<TItem>();
		}

		public Task<IEnumerable<TItem>> QueryItem(Expression<Func<TItem, bool>> predicate)
		{
			return this.MobileServiceSyncTable.Where(predicate).ToEnumerableAsync();
		}

		public void UpdateItem(TItem item)
		{
			this.MobileServiceSyncTable.UpdateAsync(item);
		}

		public virtual void InsertItem(TItem item)
		{
			this.MobileServiceSyncTable.InsertAsync(item);
		}

		public void DeleteItem(TItem item)
		{
			this.MobileServiceSyncTable.DeleteAsync(item);
		}
	}
}