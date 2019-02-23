using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MC_prj.Startup))]
namespace MC_prj
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
