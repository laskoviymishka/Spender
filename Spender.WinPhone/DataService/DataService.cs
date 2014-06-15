using System;

namespace Spender.WinPhone.Model
{
	public class BaseDataService : IDataService
	{
		public void GetData(Action<DataItem, Exception> callback)
		{
			// Use this to connect to the actual data service

			var item = new DataItem("Welcome to MVVM Light");
			callback(item, null);
		}
	}
}