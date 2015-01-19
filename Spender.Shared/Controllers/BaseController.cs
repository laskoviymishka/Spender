#region usings

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Spender.Shared.Contracts;

#endregion

namespace Spender.Shared.Controllers
{
	public class BaseController<TItem> : IBaseController<TItem> where TItem : EntityData
	{
		protected BaseController()
		{
			MobileServiceClient = new MobileServiceClient(
				"http://localhost:60532/",
				"jsqhMquRTfyQecmjvGAFekRtdTfWJF46");
			MobileServiceSyncTable = MobileServiceClient.GetSyncTable<TItem>();
		}

		protected MobileServiceClient MobileServiceClient { get; set; }
		protected IMobileServiceSyncTable<TItem> MobileServiceSyncTable { get; set; }

		protected string CurrentUserId
		{
			get { return Guid.NewGuid().ToString(); }
		}

		public Task<IEnumerable<TItem>> QueryItem(Expression<Func<TItem, bool>> predicate)
		{
			return MobileServiceSyncTable.Where(predicate).ToEnumerableAsync();
		}

		public void UpdateItem(TItem item)
		{
			MobileServiceSyncTable.UpdateAsync(item);
		}

		public virtual void InsertItem(TItem item)
		{
			MobileServiceSyncTable.InsertAsync(item);
		}

		public void DeleteItem(TItem item)
		{
			MobileServiceSyncTable.DeleteAsync(item);
		}
	}
}