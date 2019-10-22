using Ignis.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ignis.Startup))]
namespace Ignis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
        }

        private void CreateRoles()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            AddRoleIfNotExsists(roleManager, "admin");
            AddRoleIfNotExsists(roleManager, "cfo");
            AddRoleIfNotExsists(roleManager, "dfo");
            AddRoleIfNotExsists(roleManager, "rfo");
            AddRoleIfNotExsists(roleManager, "zfo");
            AddRoleIfNotExsists(roleManager, "ig");

            var user = new ApplicationUser();
            user.UserName = "admin@admin.com";
            user.Email = "admin@admin.com";

            string userPWD = "P@ssw0rd";

            var chkUser = UserManager.Create(user, userPWD);
            //var result1 = UserManager.AddToRole(user.Id, "admin");

        }

        private static void AddRoleIfNotExsists(RoleManager<IdentityRole> roleManager, string roleName)
        {

            if (!roleManager.RoleExists(roleName))
            {
                var role = new IdentityRole()
                {
                    Name = roleName
                };
                roleManager.Create(role);
            }
        }
    }
}


