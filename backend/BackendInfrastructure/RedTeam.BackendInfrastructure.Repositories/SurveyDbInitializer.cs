using RedTeam.BackendInfrastructure.Foundation;
using System.Data.Entity;

namespace RedTeam.BackendInfrastructure.Repositories
{
    public sealed class SurveyDbInitializer : DropCreateDatabaseAlways<SurveyContext>
    {
        protected override void Seed(SurveyContext db)
        {
            db.Surveys.Add(new Survey { Name = "первый опрос" });
            db.Surveys.Add(new Survey { Name = "второй опрос" });
            db.Surveys.Add(new Survey { Name = "третий опрос" });

            base.Seed(db);
        }
    }
}
