using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcIoc.Startup))]
namespace MvcIoc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
