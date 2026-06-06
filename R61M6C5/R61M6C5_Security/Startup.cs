using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(R61M6C5_Security.Startup))]
namespace R61M6C5_Security
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
