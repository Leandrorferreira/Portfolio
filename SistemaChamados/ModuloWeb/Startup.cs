using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ModuloWeb.Startup))]
namespace ModuloWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
