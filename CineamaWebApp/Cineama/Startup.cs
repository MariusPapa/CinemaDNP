using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cineama.Startup))]
namespace Cineama
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
