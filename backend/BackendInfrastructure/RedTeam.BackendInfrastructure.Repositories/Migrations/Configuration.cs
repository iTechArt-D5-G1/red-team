using System.Data.Entity.Migrations;

namespace RedTeam.BackendInfrastructure.Repositories.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<SurveyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SurveyContext context)
        {
             
        }
    }
}
