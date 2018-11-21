using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Canteen_Automation_System.Startup))]
namespace Canteen_Automation_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
