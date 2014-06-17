using System;
using System.Globalization;
using System.Windows.Data;

namespace Spender.WinPhone.Helpers
{
	public class StringToUpperConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
			{
				return value.ToString().ToUpper();
			}

			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}