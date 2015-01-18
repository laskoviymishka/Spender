using System.Data.Entity;
using Microsoft.WindowsAzure.Mobile.Service;

namespace Spender.Service
{
	public static class WebApiConfig
	{
		public static void Register()
		{
			var options = new ConfigOptions();

			var config = ServiceConfig.Initialize(new ConfigBuilder(options));

			Database.SetInitializer(new MobileServiceInitializer());
		}
	}
}