using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormIdentity.Startup))]
namespace WebFormIdentity
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
