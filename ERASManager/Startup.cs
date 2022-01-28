using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ERASManager.Startup))]
namespace ERASManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
