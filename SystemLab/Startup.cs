using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SystemLab.Startup))]
namespace SystemLab
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
