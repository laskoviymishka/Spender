using System.Collections;
using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace Spender.WinPhone.Views.SampleData
{
	public class OptionsInfoProvider : IGenericListFieldInfoProvider
	{
		public IEnumerable ItemsSource
		{
			get { return new List<string> {"Test1", "Test2"}; }
		}

		public IGenericListValueConverter ValueConverter
		{
			get { return null; }
		}
	}
}