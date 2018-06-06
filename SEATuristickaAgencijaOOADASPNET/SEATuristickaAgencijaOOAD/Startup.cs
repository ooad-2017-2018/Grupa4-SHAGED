using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEATuristickaAgencijaOOAD.Startup))]
namespace SEATuristickaAgencijaOOAD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
