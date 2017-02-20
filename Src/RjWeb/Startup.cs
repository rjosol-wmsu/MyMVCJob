using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RjWeb.Startup))]
namespace RjWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
