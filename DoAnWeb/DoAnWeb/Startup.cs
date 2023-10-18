using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoAnWeb.Startup))]
namespace DoAnWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
