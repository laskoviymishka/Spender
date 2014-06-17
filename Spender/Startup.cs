using Microsoft.Owin;
using Owin;
using Spender;

[assembly: OwinStartup(typeof (Startup))]

namespace Spender
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}