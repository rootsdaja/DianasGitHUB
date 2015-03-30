using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirplaneTrafficManagement.Startup))]
namespace AirplaneTrafficManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
