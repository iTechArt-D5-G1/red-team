using System.Data.Entity;
using RedTeam.Repositories.Interfaces;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.SurveyMaster.Repositories
{
    public class UserDbContext : DbContext, IDbContext
    {
        private const string ConnectionStringName = "UsersRepository";


        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }


        public UserDbContext()
            : base(ConnectionStringName)
        {
            Configuration.LazyLoadingEnabled = false;
        }

    }
}
