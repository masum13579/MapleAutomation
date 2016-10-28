using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MapleAutomation.Startup))]
namespace MapleAutomation
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
