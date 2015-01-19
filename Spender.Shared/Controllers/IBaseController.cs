#region usings

using Spender.Shared.Contracts;

#endregion

namespace Spender.Shared.Controllers
{
	public interface IBaseController<TItem> where TItem : EntityData
	{
		void DeleteItem(TItem item);
		void InsertItem(TItem item);
		Task<IEnumerable<TItem>> QueryItem(Expression<Func<TItem, bool>> predicate);
		void UpdateItem(TItem item);
	}
}