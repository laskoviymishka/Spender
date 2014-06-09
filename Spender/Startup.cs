using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Spender.Startup))]
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
