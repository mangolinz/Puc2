using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Puc2.Mvc.Startup))]
namespace Puc2.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
