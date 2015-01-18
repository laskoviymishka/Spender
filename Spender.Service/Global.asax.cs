#region usings

using System.Web;

#endregion

namespace Spender.Service
{
	public class WebApiApplication : HttpApplication
	{
		protected void Application_Start()
		{
			WebApiConfig.Register();
		}
	}
}