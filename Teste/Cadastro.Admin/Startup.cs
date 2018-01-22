using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cadastro.Admin.Startup))]
namespace Cadastro.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
