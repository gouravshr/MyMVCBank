
using Microsoft.Owin;
using MVC_Pratice.Models;
using Owin;
using Microsoft.AspNet.Identity;

[assembly: OwinStartupAttribute(typeof(MVC_Pratice.Startup))]
namespace MVC_Pratice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUsersAndRoles();
        }

        public void CreateUsersAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore());



        }
    }
}
