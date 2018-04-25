//////using System;

using System.Data.Entity;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.SurveyMaster.Repositories.DbInitializers
{
    public class UserDbInitializer : DropCreateDatabaseAlways<UserDbContext>
    {
        protected override void Seed(UserDbContext dbContext)
        {
            Role adminRole = new Role {Name = "admin"};
            Role userRole = new Role {Name = "user"};

            dbContext.Roles.Add(adminRole);
            dbContext.Roles.Add(userRole);

            dbContext.Users.Add(new User
            {
                Password = "admin",
                Username = "admin@admin.com",
                Role = adminRole
            });

            dbContext.Users.Add(new User
            {
                Password = "user",
                Username = "user@user.com",
                Role = userRole
            });

            base.Seed(dbContext);
        }

    }
}
