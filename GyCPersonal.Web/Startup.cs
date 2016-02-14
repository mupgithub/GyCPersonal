using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GyCPersonal.Web.Startup))]
namespace GyCPersonal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
