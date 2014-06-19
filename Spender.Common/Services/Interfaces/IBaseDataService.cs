using System.Collections;
using System.Collections.Generic;

namespace Spender.Common.Services
{
	public interface IBaseDataService<T>
	{
		IEnumerable<T> GetItems();
		T UpdateItem(T item);
		T InsertItem(T item);
		void DeleteItem(T item);
	}
}