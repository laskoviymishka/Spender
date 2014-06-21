using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Spender.WinPhone.DataService;
using Telerik.Windows.Controls;

namespace Spender.WinPhone.Views.SampleData
{
	public class OptionsInfoProvider : IGenericListFieldInfoProvider
	{
		public IEnumerable ItemsSource
		{
			get
			{
				return StaticDataHolder.Categories.Select(category => category.Name).ToList();
			}
		}

		public IGenericListValueConverter ValueConverter
		{
			get { return null; }
		}
	}
}