using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
