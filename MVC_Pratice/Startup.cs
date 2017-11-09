
using Microsoft.Owin;
using MVC_Pratice.Models;
using Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using ATM.Data;
using ATM.Entity.Models;
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
            //MyBankDB ctx = new MyBankDB();
            //var userStore = new UserStore<ApplicationUser>(ctx);
            //var userManager = new UserManager<ApplicationUser>(userStore);

            //var rolStore = new RoleStore<UserRole>(ctx);
            //var roleManager = new RoleManager<UserRole>(roleStore);
            //ApplicationDbContext context = new ApplicationDbContext();

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore());



        }
    }
}
