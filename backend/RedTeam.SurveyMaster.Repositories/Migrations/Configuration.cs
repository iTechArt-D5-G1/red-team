using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.SurveyMaster.Repositories.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SurveyMasterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SurveyMasterDbContext context)
        {
            var passwordHasher = new PasswordHasher();

            var adminUser = new User
            {
                Id = "1",
                UserName = "admin@admin.com",
                PasswordHash = passwordHasher.HashPassword("adminpassword"),
                Email = "admin@admin.com"
            };
            var usualUser = new User
            {
                Id = "2",
                UserName = "user@user.com",
                PasswordHash = passwordHasher.HashPassword("userpassword"),
                Email = "user@user.com"
            };

            var adminRole = new Role{ Id = "1", Name = "admin" };
            var userRole = new Role{ Id = "2", Name = "user" };

            context.Roles.AddOrUpdate(
                adminRole,
                userRole
                );

            context.Users.AddOrUpdate(
                adminUser,
                usualUser
                );

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            userManager.AddToRole("1", adminRole.Name);
            userManager.AddToRole("2", userRole.Name);
        }
    }
}
