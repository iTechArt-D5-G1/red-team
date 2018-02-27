namespace RedTeam.BackendInfrastructure.Repositories.Migrations
{
    using System.Data.Entity.Migrations;


    public sealed class Configuration : DbMigrationsConfiguration<Repositories.SurveyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "RedTeam.BackendInfrastructure.Repositories.Repositories.SurveyContext";

        }

        protected override void Seed(Repositories.SurveyContext context)
        {
             
        }
    }
}
