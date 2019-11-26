using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HUMAN_RESOURCES_v1.Startup))]
namespace HUMAN_RESOURCES_v1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
