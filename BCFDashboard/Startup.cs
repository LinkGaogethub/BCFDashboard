using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BCFDashboard.Startup))]
namespace BCFDashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
