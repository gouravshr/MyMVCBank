using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Pratice.Startup))]
namespace MVC_Pratice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
