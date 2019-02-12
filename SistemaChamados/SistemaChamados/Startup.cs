using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaChamados.Startup))]
namespace SistemaChamados
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
