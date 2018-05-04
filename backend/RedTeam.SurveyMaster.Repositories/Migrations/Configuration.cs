using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.SurveyMaster.Repositories.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RedTeam.SurveyMaster.Repositories.SurveyMasterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RedTeam.SurveyMaster.Repositories.SurveyMasterDbContext context)
        {
            context.Roles.AddOrUpdate(x=>x.Id,
                new Role() { Id = 1, Name = "admin"},
                new Role() { Id = 2, Name = "user"}
                );

            context.Users.AddOrUpdate(x=>x.Id,
                new User() { Id = 1, Password = "userpassword",RoleId = 2,Username = "user@user.com"},
                new User() { Id = 2, Password = "adminpassword", RoleId = 1, Username = "admin@admin.com" }
                );
        }
    }
}
