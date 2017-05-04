using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComputerStore.Web.Startup))]
namespace ComputerStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
