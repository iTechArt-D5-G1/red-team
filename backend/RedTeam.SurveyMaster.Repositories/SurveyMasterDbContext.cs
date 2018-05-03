using System.Data.Entity;
using RedTeam.Repositories.Interfaces;
using RedTeam.SurveyMaster.Repositories.Models;

namespace RedTeam.SurveyMaster.Repositories
{
    public class SurveyMasterDbContext : DbContext, IDbContext
    {
        private const string ConnectionStringName = "SurveyRepository";


        public DbSet<Survey> Surveys { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }


        public SurveyMasterDbContext()
            : base(ConnectionStringName)
        {
            Configuration.LazyLoadingEnabled = false;
        }
    }
}