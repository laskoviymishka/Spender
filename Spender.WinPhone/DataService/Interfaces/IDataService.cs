using System;

namespace Spender.WinPhone.Model
{
	public interface IDataService
	{
		void GetData(Action<DataItem, Exception> callback);
	}
}